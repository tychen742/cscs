// Press integration for the CSCS book. Loaded before custom.js and execution.js.
//
// Accounts live in Press (press/docs/RUN_PASSES.md). This file tells Press's shared
// account script where Press is for this site, loads that script and its styles, and
// fetches short-lived Press-signed passes: run passes for the C# runner and author
// passes for browser authoring.
(function () {
    function setting(name) {
        try {
            return localStorage.getItem(name);
        } catch (_) {
            return null;
        }
    }

    // thinkcscs.org proxies Press's /api/, /accounts/, and /static/thinkpress/, so the
    // session cookie belongs to thinkcscs.org. Locally, Press runs on port 8001.
    const onSite = location.hostname.endsWith('thinkcscs.org');
    const backend = setting('CSCS_PRESS_API') ?? (onSite ? '' : 'http://localhost:8001');
    window.THINKPRESS_BACKEND = backend;

    const stylesheet = document.createElement('link');
    stylesheet.rel = 'stylesheet';
    stylesheet.href = `${backend}/static/thinkpress/auth.css`;
    document.head.appendChild(stylesheet);
    const accountScript = document.createElement('script');
    accountScript.src = `${backend}/static/thinkpress/auth.js`;
    accountScript.defer = true;
    document.head.appendChild(accountScript);

    const passes = {};

    async function csrfToken() {
        if (window.thinkpressSession?.csrf_token) return window.thinkpressSession.csrf_token;
        const response = await fetch(`${backend}/api/me`, { credentials: 'include', cache: 'no-store' });
        return response.ok ? (await response.json()).csrf_token || '' : '';
    }

    // kind is 'run' or 'author'. Returns null for signed-out readers, readers without an
    // author role, or when Press is unreachable; callers then fall back to guest behavior.
    async function fetchPass(kind) {
        const cached = passes[kind];
        if (cached && cached.expiresAt * 1000 - Date.now() > 60000) return cached.pass;
        if (window.thinkpressSession && !window.thinkpressSession.authenticated) return null;
        try {
            const response = await fetch(`${backend}/api/${kind}-pass`, {
                method: 'POST',
                credentials: 'include',
                headers: { 'Content-Type': 'application/json', 'X-CSRFToken': await csrfToken() },
                body: JSON.stringify({ book: 'cscs' })
            });
            if (!response.ok) return null;
            passes[kind] = await response.json();
            return passes[kind].pass;
        } catch (_) {
            return null;
        }
    }

    window.cscsPress = {
        backend,
        csrfToken,
        // Headers to add to a request: an Authorization header when a pass is available.
        async authHeader(kind) {
            const pass = await fetchPass(kind);
            return pass ? { Authorization: `Bearer ${pass}` } : {};
        }
    };
})();
