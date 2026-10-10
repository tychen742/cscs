# CSCS browser authoring service

This directory now hosts the temporary CSCS browser-authoring API
(`execution-api`). The active C# code runner moved to Press:

```text
/Users/tychen/workspace/press/runner/csharp
```

Press owns the runner services, run passes, accounts, and reading progress; see
`press/docs/RUN_PASSES.md` and `press/docs/PLATFORM_DECISIONS.md`. The legacy
CSCS runner files are retained here only as a rollback path.

## Run locally

From this directory:

```bash
docker compose -f compose.yml up --build -d execution-api
```

Check the authoring API:

```bash
curl http://127.0.0.1:8080/health
```

Run C# cells through the Press-owned runner gateway on port 8081:

```bash
curl -s http://127.0.0.1:8081/v1/tasks/ch06-regex/execute \
  -H 'Content-Type: application/json' \
  -d '{"code":"int answer = 6 * 7; Console.WriteLine(answer);"}'
```

Stop the service with:

```bash
docker compose -f compose.yml down
```

On `dev`, Apache routes `/cscs-exec/v1/tasks/` to the Press-owned runner gateway
and the rest of `/cscs-exec/` to this authoring API. Student code does not run
inside `execution-api`.

If you need the old runner for rollback testing, start it explicitly:

```bash
docker compose -f compose.yml --profile legacy-runner up --build -d cs-runner-gateway
```

Do not run the legacy gateway at the same time as the Press gateway; both bind
`127.0.0.1:8081`.

There is no CSCS database: accounts, sign-in, and reading progress live in Press
(since 2026-10-04). The old `cscs-postgres-data` volume may still exist on servers
until it is deleted by hand.

## Notebook validation

The first authoring endpoint validates notebook structure before any future save:

```text
POST /v1/admin/notebooks/validate
```

Send the notebook JSON as the request body. It checks JSON syntax, notebook
format fields, the cells array, cell types, and source values. File writes and
Git backup/rollback will be added only after this validation boundary.

Durable learner, course, assignment, and grading state belongs in Press, not in
this service.

## Admin notebook save

Authoring requests carry `Authorization: Bearer <author pass>`, a short-lived pass
signed by Press for accounts whose Press role is `admin`, `author`, `editor`,
`instructor`, or `ta` (`POST /api/author-pass` on Press; see
`press/docs/RUN_PASSES.md`). The API checks the pass with Press's public key
(`CSCS_RUN_PASS_PUBLIC_KEYS`), answers 401 without a valid pass and 403 for other
roles, and records the pass's email as the commit author. In the book, authors use
"Edit this page" in the account menu. Endpoints:

```text
POST /v1/admin/notebooks/save
```

with `{ "path": "chapters/09_collections/0902_list.ipynb", "content": "..." }`.
The API validates the notebook, restricts writes to `chapters/**/*.ipynb`,
copies the existing file to the backup directory, and atomically replaces it.
The book root is mounted at `/workspace` in development; backups are stored in
the persistent Docker volume.

The mounted book root must be a Git checkout of the content repository. Browser
authoring edits notebook files in that checkout, so online edits become normal
Git working-tree changes that can be reviewed, committed, pushed, and rebuilt.
Do not use a loose rsync-only mirror as the editable source of truth.

The matching source endpoint is:

```text
GET /v1/admin/notebooks/source?path=chapters/09_collections/0902_list.ipynb
```

Browser authoring also exposes a Git sync endpoint:

```text
POST /v1/admin/git/sync
```

The endpoint commits pending source changes in the mounted Git checkout, rebases
on `origin/main`, and pushes to GitHub. In production, the API container must be
able to run `git` and authenticate to GitHub. The current deployment mounts the
host SSH configuration read-only into the API container, so the container user
must be able to read that key without broadening SSH key permissions.

After a push to `main`, GitHub Actions builds the book, deploys the generated
HTML to `/var/www/cscs/`, and updates the server-side authoring checkout from
`origin/main` if that checkout is clean. If the checkout contains unsynced
browser-authored changes, the workflow stops so those changes can be synced or
resolved explicitly.

The book build adds stable `data-cscs-cell-id` and `data-cscs-cell-index`
attributes through `_ext/notebook_cell_metadata.py`, allowing the browser
editor to map rendered code and markdown cells back to the original notebook.
