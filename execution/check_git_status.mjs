#!/usr/bin/env node
// Integration check for GET /v1/admin/git/status.
//
// Builds the authoring API, starts it against a throwaway Git checkout, and checks that
// the endpoint answers 401 without a pass, reports a clean checkout after a commit, and
// reports the unsynced file after a write. The author pass is signed with a key pair
// generated here, so no Press keys are needed. Run from this directory:
//
//     node check_git_status.mjs
//
// Needs dotnet, git, and Node 18+ (fetch, crypto.sign with ieee-p1363).

import { spawn, execFileSync } from 'node:child_process';
import { createHash, generateKeyPairSync, sign } from 'node:crypto';
import { mkdtempSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { fileURLToPath } from 'node:url';

const here = fileURLToPath(new URL('.', import.meta.url));
const port = 18080 + Math.floor(Math.random() * 1000);
const baseUrl = `http://127.0.0.1:${port}`;

const base64url = buffer => Buffer.from(buffer).toString('base64').replace(/=+$/, '').replace(/\+/g, '-').replace(/\//g, '_');

// Key pair and author pass in Press's format (shared/PressPassVerifier.cs).
const { publicKey, privateKey } = generateKeyPairSync('ec', { namedCurve: 'prime256v1' });
const spki = publicKey.export({ type: 'spki', format: 'der' });
const kid = base64url(createHash('sha256').update(spki).digest()).slice(0, 16);
const now = Math.floor(Date.now() / 1000);
const header = base64url(JSON.stringify({ alg: 'ES256', kid }));
const claims = base64url(JSON.stringify({
    aud: 'cscs-authoring', book: 'cscs', tier: 'author', sub: 'check', email: 'check@example.test',
    can_edit: true, can_publish: true, iat: now, exp: now + 600
}));
const signature = sign('sha256', Buffer.from(`${header}.${claims}`), { key: privateKey, dsaEncoding: 'ieee-p1363' });
const pass = `${header}.${claims}.${base64url(signature)}`;

// Throwaway checkout with one commit.
const checkout = mkdtempSync(join(tmpdir(), 'cscs-git-status-'));
const git = (...args) => execFileSync('git', ['-c', 'user.name=check', '-c', 'user.email=check@example.test', ...args], { cwd: checkout, encoding: 'utf8' }).trim();
git('init', '-q', '-b', 'main');
writeFileSync(join(checkout, 'README.md'), 'check\n');
git('add', 'README.md');
git('commit', '-q', '-m', 'initial');
const head = git('rev-parse', '--short', 'HEAD');

execFileSync('dotnet', ['build', '-nologo', '-v', 'q'], { cwd: here, stdio: 'inherit' });

const api = spawn('dotnet', ['run', '--no-build', '--project', join(here, 'execution.csproj')], {
    cwd: here,
    env: {
        ...process.env,
        CSCS_BOOK_ROOT: checkout,
        CSCS_AUTHORING_URLS: baseUrl,
        CSCS_RUN_PASS_PUBLIC_KEYS: spki.toString('base64')
    },
    stdio: ['ignore', 'pipe', 'pipe']
});
let apiLog = '';
api.stdout.on('data', chunk => { apiLog += chunk; });
api.stderr.on('data', chunk => { apiLog += chunk; });

let failed = false;
function check(condition, label, detail) {
    console.log(`${condition ? 'ok  ' : 'FAIL'} ${label}${condition ? '' : `: ${JSON.stringify(detail)}`}`);
    if (!condition) failed = true;
}

async function status(withPass = true) {
    const response = await fetch(`${baseUrl}/v1/admin/git/status`, {
        headers: withPass ? { Authorization: `Bearer ${pass}` } : {}
    });
    return { status: response.status, body: await response.json().catch(() => null) };
}

try {
    const deadline = Date.now() + 30000;
    let up = false;
    while (Date.now() < deadline && !up) {
        up = await fetch(`${baseUrl}/health`).then(r => r.ok).catch(() => false);
        if (!up) await new Promise(resolve => setTimeout(resolve, 250));
    }
    if (!up) throw new Error(`API did not start:\n${apiLog}`);

    const unauthenticated = await status(false);
    check(unauthenticated.status === 401, 'status without a pass is 401', unauthenticated);

    const clean = await status();
    check(clean.status === 200 && clean.body?.dirty === false && clean.body?.files?.length === 0 && clean.body?.head === head,
        `clean checkout reports dirty=false at ${head}`, clean);

    writeFileSync(join(checkout, 'notes.ipynb'), '{}\n');
    writeFileSync(join(checkout, 'README.md'), 'changed\n');
    const dirty = await status();
    const files = dirty.body?.files ?? [];
    check(dirty.status === 200 && dirty.body?.dirty === true && files.includes('notes.ipynb') && files.includes('README.md') && files.length === 2,
        'unsynced writes report dirty=true with both paths', dirty);
} catch (error) {
    failed = true;
    console.error(error.message);
} finally {
    api.kill('SIGTERM');
    rmSync(checkout, { recursive: true, force: true });
}
process.exit(failed ? 1 : 0);
