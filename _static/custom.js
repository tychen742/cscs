// Provide fallback globals expected by sphinx-togglebutton and sphinx-thebe.
// These are set once here to avoid duplicate inline declarations in <head>.
(function setSphinxInteractiveGlobals() {
    if (typeof window.togglebuttonSelector === 'undefined') {
        window.togglebuttonSelector = '.toggle, .admonition.dropdown';
    }
    if (typeof window.THEBE_JS_URL === 'undefined') {
        window.THEBE_JS_URL = 'https://unpkg.com/thebe@0.8.2/lib/index.js';
    }
    if (typeof window.thebe_selector === 'undefined') {
        window.thebe_selector = 'div.cell';
    }
    if (typeof window.thebe_selector_input === 'undefined') {
        window.thebe_selector_input = 'div.cell_input';
    }
    if (typeof window.thebe_selector_output === 'undefined') {
        window.thebe_selector_output = 'div.cell_output';
    }
})();

console.log("Custom JS loaded!");

// Convert appendix chapter numbers to letters (A, B, C ...)
document.addEventListener('DOMContentLoaded', function () {
    function toAlpha(n) { return String.fromCharCode(64 + parseInt(n, 10)); }
    function convertNum(text) {
        return text.replace(/^(\d+)(\.)/, function(_, n, dot) { return toAlpha(n) + dot; });
    }

    // 1. Sidebar links under the "Appendices" caption — text is plain "1. Title"
    document.querySelectorAll('.caption-text').forEach(function(caption) {
        if (caption.textContent.trim() !== 'Appendices') return;
        var ul = caption.closest('p').nextElementSibling;
        if (!ul) return;
        ul.querySelectorAll('a.reference').forEach(function(a) {
            a.childNodes.forEach(function(node) {
                if (node.nodeType === Node.TEXT_NODE)
                    node.textContent = convertNum(node.textContent);
            });
        });
    });

    // Detect appendix page: active sidebar list is under "Appendices"
    var onAppendixPage = false;
    document.querySelectorAll('.caption-text').forEach(function(caption) {
        if (caption.textContent.trim() === 'Appendices') {
            var ul = caption.closest('p').nextElementSibling;
            if (ul && ul.classList.contains('current')) onAppendixPage = true;
        }
    });
    if (!onAppendixPage) return;

    // 2. Page headings: <span class="section-number">
    document.querySelectorAll('.section-number').forEach(function(span) {
        span.textContent = convertNum(span.textContent);
    });

    var headingSectionNumber = document.querySelector('h1 .section-number');
    var appendixLetterMatch = headingSectionNumber && headingSectionNumber.textContent.match(/^([A-Z])\./);
    if (appendixLetterMatch) {
        var appendixLetter = appendixLetterMatch[1];
        var figureLabelsByHash = {};
        var figureCount = 0;

        document.querySelectorAll('figure[id] figcaption .caption-number').forEach(function(span) {
            if (!span.textContent.trim().match(/^Fig\./)) return;
            var figure = span.closest('figure[id]');
            if (!figure) return;

            figureCount += 1;
            var label = 'Fig. ' + appendixLetter + '.' + figureCount;
            span.textContent = label + ' ';
            figureLabelsByHash['#' + figure.id] = label;
        });

        document.querySelectorAll('a.reference.internal[href] .std-numref').forEach(function(span) {
            var link = span.closest('a.reference.internal[href]');
            var url;
            try {
                url = new URL(link.getAttribute('href'), window.location.href);
            } catch (e) {
                return;
            }
            if (url.pathname !== window.location.pathname) return;
            if (!figureLabelsByHash[url.hash]) return;
            span.textContent = figureLabelsByHash[url.hash];
        });
    }

    // 3. Prev/next footer: only convert links pointing into /appendices/
    document.querySelectorAll('.left-prev[href], .right-next[href]').forEach(function(a) {
        if (a.href.includes('/appendices/'))
            a.querySelectorAll('.section-number').forEach(function(span) {
                span.textContent = convertNum(span.textContent);
            });
    });
});

// Filter noisy, non-actionable browser/extension errors from console output.
(function setupConsoleNoiseFilter() {
    const originalError = console.error.bind(console);
    const originalWarn = console.warn.bind(console);

    function toMessage(args) {
        return args.map(a => {
            if (typeof a === 'string') return a;
            if (a && a.message) return a.message;
            try {
                return JSON.stringify(a);
            } catch {
                return String(a);
            }
        }).join(' ');
    }

    function isKnownNoise(msg) {
        return (
            msg.includes("A listener indicated an asynchronous response by returning true") ||
            (msg.includes("WebSocket connection") && msg.includes("/ws/ws"))
        );
    }

    console.error = function (...args) {
        const msg = toMessage(args);
        if (isKnownNoise(msg)) {
            console.info("[filtered-noise]", msg);
            return;
        }
        originalError(...args);
    };

    console.warn = function (...args) {
        const msg = toMessage(args);
        if (isKnownNoise(msg)) {
            console.info("[filtered-noise]", msg);
            return;
        }
        originalWarn(...args);
    };
})();

/*
// Handle sidebar toggle using event delegation (more reliable)
document.addEventListener('click', function (e) {
    const toggleButton = e.target.closest('button.sidebar-toggle.primary-toggle');

    if (toggleButton) {
        e.preventDefault();
        e.stopPropagation();

        const sidebar = document.querySelector('.bd-sidebar-primary');
        if (sidebar) {
            sidebar.classList.toggle('show');
            document.body.classList.toggle('sidebar-visible');
            const isExpanded = sidebar.classList.contains('show');
            toggleButton.setAttribute('aria-expanded', isExpanded);
        }
        return false;
    }

    // Close sidebar when clicking outside
    const sidebar = document.querySelector('.bd-sidebar-primary');
    if (sidebar && document.body.classList.contains('sidebar-visible')) {
        if (!sidebar.contains(e.target) && !e.target.closest('button.sidebar-toggle.primary-toggle')) {
            sidebar.classList.remove('show');
            document.body.classList.remove('sidebar-visible');
        }
    }
}, true);
*/

// ---- SINGLE DOMContentLoaded handler ----
document.addEventListener('DOMContentLoaded', function () {
    console.log("DOM ready!");

    // -----------------------------------------------------------
    // FIX A: tag_hide-input (exercise answer) cells
    //
    // Thebe wraps the entire .thebelab-cell inside <details>, hiding
    // everything. We watch each cell and move the jp-OutputArea wrapper
    // outside <details> the instant Thebe creates it.
    // -----------------------------------------------------------
    // // Thebe activation detection: watch for .thebelab-cell to be created inside <details>, then move output.
    function moveOutputOutsideDetails(cell) {
        var details = cell.querySelector('details');
        if (!details) return;
        var thebelabCell = details.querySelector('.thebelab-cell');
        if (!thebelabCell) return;

        var outputWrapper = null;
        thebelabCell.querySelectorAll(':scope > div').forEach(function (div) {
            if (div.querySelector('.jp-OutputArea')) outputWrapper = div;
        });

        if (outputWrapper && !outputWrapper.dataset.movedOut) {
            outputWrapper.dataset.movedOut = '1';
            details.after(outputWrapper);
            console.log("[fix A] Moved output outside <details> for", cell.id);
        }
    }

    function watchExerciseCell(cell) {
        var details = cell.querySelector('details');
        if (!details) return;

        var observer = new MutationObserver(function () {
            var thebelabCell = details.querySelector('.thebelab-cell');
            if (!thebelabCell) return;

            var outputObserver = new MutationObserver(function () {
                var outputWrapper = null;
                thebelabCell.querySelectorAll(':scope > div').forEach(function (div) {
                    if (div.querySelector('.jp-OutputArea')) outputWrapper = div;
                });
                if (outputWrapper && !outputWrapper.dataset.movedOut) {
                    outputWrapper.dataset.movedOut = '1';
                    details.after(outputWrapper);
                    console.log("[fix A] (delayed) Moved output outside <details> for", cell.id);
                    outputObserver.disconnect();
                }
            });
            outputObserver.observe(thebelabCell, { childList: true, subtree: true });
            moveOutputOutsideDetails(cell);
            observer.disconnect();
        });

        observer.observe(details, { childList: true, subtree: true });
    }

    document.querySelectorAll('.tag_hide-input').forEach(watchExerciseCell);

    // -----------------------------------------------------------
    // FIX B: Demo cells — hide jp-OutputArea when Thebe activates.
    //
    // Since body.thebelab-active is never set by Thebe 0.8.2,
    // we detect activation by watching for the first
    // .thebelab-run-button to appear in the DOM, then add our own
    // class 'thebe-is-active' to body so CSS can target it.
    //
    // NOTE: thinkpy uses predefinedOutput: true (default), so
    // static outputs are visible. No Fix A needed — exercise cell
    // outputs are not hidden by Thebe in this config.
    // -----------------------------------------------------------

    var thebeActivated = false;

    var activationObserver = new MutationObserver(function () {
        if (thebeActivated) return;
        if (document.querySelector('.thebelab-run-button')) {
            thebeActivated = true;
            activationObserver.disconnect();
            document.body.classList.add('thebe-is-active');
            console.log("[fix B] Thebe detected — added thebe-is-active to body");

            // Bind directly to every run button now that they exist
            document.querySelectorAll('.thebelab-run-button').forEach(function (btn) {
                btn.addEventListener('click', function () {
                    var cell = btn.closest('.cell');
                    if (cell && !cell.classList.contains('tag_hide-input')) {
                        cell.classList.add('cell-has-run');
                        console.log("[fix B] Marked cell-has-run for", cell.id);
                    }
                });
            });
        }
    });
    activationObserver.observe(document.body, { childList: true, subtree: true });

    // Exercise counter labels
    const exercises = document.querySelectorAll('div.cell.tag_thebe-interactive');
    const total = exercises.length;

    exercises.forEach((exercise, index) => {
        // Skip if label already exists
        if (exercise.querySelector('.exercise-label')) return;

        const counter = index + 1;
        const label = document.createElement('div');
        label.className = 'exercise-label';
        label.innerHTML = `✏️ Interactive Exercise ${counter}/${total}`;
        label.style.cssText = `
            display: block;
            font-size: 0.85em;
            color: #771212;
            font-weight: bold;
            margin-bottom: 8px;
        `;
        exercise.insertBefore(label, exercise.firstChild);
    });
});

// Account menu and development login UI for the database-backed API.
document.addEventListener('DOMContentLoaded', function () {
    const apiBaseUrl = localStorage.getItem('CSCS_EXECUTION_API') ||
        window.CSCS_EXECUTION_API ||
        (location.hostname.endsWith('thinkcscs.org') ? 'https://thinkcscs.org/cscs-exec' : 'http://localhost:8080');
    const sidebar = document.querySelector('.bd-sidebar-primary');
    const accountHost =
        document.querySelector('.article-header-buttons') ||
        document.querySelector('.header-article-items__end') ||
        sidebar?.querySelector('.sidebar-primary-items__end') ||
        sidebar?.querySelector('.sidebar-primary-items__start') ||
        sidebar;
    if (!accountHost || document.querySelector('.cscs-account')) return;

    const account = document.createElement('div');
    account.className = 'cscs-account cscs-account-topbar';
    account.innerHTML = `
        <button class="cscs-avatar" type="button" aria-label="Account" aria-expanded="false">
            <span aria-hidden="true">●</span>
        </button>
        <div class="cscs-account-menu" hidden>
            <button type="button" data-auth-action="login">Sign in</button>
            <button type="button" data-auth-action="register">Sign up</button>
        </div>`;
    accountHost.appendChild(account);

    const modal = document.createElement('div');
    modal.className = 'cscs-auth-modal-backdrop';
    modal.hidden = true;
    modal.innerHTML = `
        <section class="cscs-auth-modal" role="dialog" aria-modal="true" aria-labelledby="cscs-auth-title">
            <header class="cscs-auth-header">
                <h2 id="cscs-auth-title">Course account</h2>
                <button type="button" class="cscs-auth-close" aria-label="Close">&times;</button>
            </header>
            <div class="cscs-auth-tabs" role="tablist">
                <button type="button" data-auth-tab="login" role="tab">Sign in</button>
                <button type="button" data-auth-tab="register" role="tab">Sign up</button>
            </div>
            <form class="cscs-auth-form" data-auth-form="login">
                <label>University ID or email<input name="email" type="email" autocomplete="username" required></label>
                <label>Password<input name="password" type="password" autocomplete="current-password" required></label>
                <button class="cscs-auth-link-button" type="button" data-auth-action="forgot-password">Forgot password?</button>
                <button class="cscs-auth-submit" type="submit">Sign in</button>
            </form>
            <form class="cscs-auth-form" data-auth-form="register" hidden>
                <label>Display name<input name="displayName" autocomplete="name" required></label>
                <label>Email<input name="email" type="email" autocomplete="email" required></label>
                <label>Password<input name="password" type="password" minlength="8" autocomplete="new-password" required></label>
                <label>Confirm password<input name="passwordConfirm" type="password" minlength="8" autocomplete="new-password" required></label>
                <button class="cscs-auth-submit" type="submit">Create account</button>
            </form>
            <form class="cscs-auth-form" data-auth-form="reset-request" hidden>
                <label>Email<input name="email" type="email" autocomplete="username" required></label>
                <button class="cscs-auth-submit" type="submit">Send reset link</button>
                <button class="cscs-auth-link-button cscs-auth-secondary" type="button" data-auth-mode="login">Back to sign in</button>
            </form>
            <form class="cscs-auth-form" data-auth-form="reset-complete" hidden>
                <input name="token" type="hidden">
                <label>New password<input name="password" type="password" minlength="8" autocomplete="new-password" required></label>
                <button class="cscs-auth-submit" type="submit">Reset password</button>
                <button class="cscs-auth-link-button cscs-auth-secondary" type="button" data-auth-mode="login">Back to sign in</button>
            </form>
            <section class="cscs-auth-form cscs-verification-panel" data-auth-form="verification" hidden>
                <p class="cscs-verification-message">Verifying your email...</p>
                <button class="cscs-auth-submit" type="button" data-auth-mode="login">Sign in</button>
            </section>
            <form class="cscs-auth-form" data-auth-form="profile" hidden>
                <label>Display name<input name="displayName" autocomplete="name" required></label>
                <label>Email<input name="email" type="email" disabled></label>
                <label>Institution<input name="institution" disabled></label>
                <label>Institution ID<input name="institutionId" disabled></label>
                <label>Academic year<input name="academicYear" disabled></label>
                <label>Semester<input name="semester" disabled></label>
                <label>Role<input name="role" disabled></label>
                <button class="cscs-auth-submit" type="submit">Save profile</button>
                <button class="cscs-auth-link-button cscs-auth-secondary" type="button" data-auth-mode="change-password">Change password</button>
            </form>
            <form class="cscs-auth-form" data-auth-form="change-password" hidden>
                <label>Current password<input name="currentPassword" type="password" autocomplete="current-password" required></label>
                <label>New password<input name="newPassword" type="password" minlength="8" autocomplete="new-password" required></label>
                <label>Confirm new password<input name="newPasswordConfirm" type="password" minlength="8" autocomplete="new-password" required></label>
                <button class="cscs-auth-submit" type="submit">Change password</button>
                <button class="cscs-auth-link-button cscs-auth-secondary" type="button" data-auth-mode="profile">Back to profile</button>
            </form>
            <section class="cscs-auth-form cscs-users-panel" data-auth-form="users" hidden>
                <div class="cscs-users-list" aria-live="polite"></div>
            </section>
            <p class="cscs-auth-status" aria-live="polite"></p>
        </section>`;
    document.body.appendChild(modal);

    const avatar = account.querySelector('.cscs-avatar');
    const menu = account.querySelector('.cscs-account-menu');
    const status = modal.querySelector('.cscs-auth-status');
    let currentUser = null;

    async function updateAccountMenu() {
        try {
            const response = await fetch(`${apiBaseUrl}/v1/auth/me`, { credentials: 'include' });
            if (!response.ok) return;
            const user = await response.json();
            currentUser = user;
            const initials = user.displayName.split(/\s+/).map(part => part[0]).join('').slice(0, 2).toUpperCase();
            avatar.querySelector('span').textContent = initials;
            avatar.classList.add('is-signed-in');
            account.querySelector('.cscs-account-menu').innerHTML = `
                <button type="button" data-account-action="Profile">Profile</button>
                ${user.canAuthor ? '<button type="button" data-account-action="Author">Author</button>' : ''}
                <button type="button" data-account-action="Attempts">Attempts</button>
                <button type="button" data-account-action="Score Report">Score Report</button>
                ${user.canManageUsers ? '<button type="button" data-account-action="Users">Users</button>' : ''}
                <button type="button" data-account-action="Assignments">Assignments</button>
                <button type="button" data-account-action="Log out">Log out</button>`;
            account.querySelectorAll('[data-account-action]').forEach(button => {
                button.addEventListener('click', async () => {
                    if (button.dataset.accountAction !== 'Log out') {
                        if (button.dataset.accountAction === 'Profile') {
                            await showProfile();
                            return;
                        }
                        if (button.dataset.accountAction === 'Author') {
                            await enableAuthorMode();
                            return;
                        }
                        if (button.dataset.accountAction === 'Users') {
                            openAdminWorkspace('users');
                            return;
                        }
                        status.textContent = `${button.dataset.accountAction} is not available yet.`;
                        showModal('login');
                        return;
                    }
                    await fetch(`${apiBaseUrl}/v1/auth/logout`, { method: 'POST', credentials: 'include' });
                    window.location.reload();
                });
            });
        } catch (_) {
            // The book remains usable when the local API is offline.
        }
    }

    function showModal(mode) {
        modal.hidden = false;
        menu.hidden = true;
        avatar.setAttribute('aria-expanded', 'false');
        setMode(mode);
    }

    function setMode(mode) {
        modal.querySelector('.cscs-auth-modal').classList.toggle('cscs-auth-modal-wide', mode === 'users');
        modal.querySelectorAll('[data-auth-tab]').forEach(tab => {
            tab.classList.toggle('is-active', tab.dataset.authTab === mode);
            tab.setAttribute('aria-selected', tab.dataset.authTab === mode ? 'true' : 'false');
        });
        modal.querySelectorAll('[data-auth-form]').forEach(form => {
            form.hidden = form.dataset.authForm !== mode;
        });
        status.textContent = '';
    }

    function setStatus(message) {
        status.textContent = message || '';
    }

    function openAdminWorkspace(section) {
        const url = new URL(window.location.href);
        url.searchParams.set('cscsAdmin', section);
        url.hash = '';
        window.open(url.toString(), '_blank', 'noopener');
        menu.hidden = true;
        avatar.setAttribute('aria-expanded', 'false');
    }

    function getSearchToken(...names) {
        const params = new URLSearchParams(window.location.search);
        for (const name of names) {
            const value = params.get(name);
            if (value) return { name, value };
        }
        return null;
    }

    function removeSearchTokens(...names) {
        const cleanUrl = new URL(window.location.href);
        names.forEach(name => cleanUrl.searchParams.delete(name));
        window.history.replaceState({}, '', cleanUrl);
    }

    async function confirmEmailVerification(token) {
        const message = modal.querySelector('.cscs-verification-message');
        showModal('verification');
        message.textContent = 'Verifying your email...';
        setStatus('');
        try {
            const response = await fetch(`${apiBaseUrl}/v1/auth/email-verification/confirm`, {
                method: 'POST',
                credentials: 'include',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ token })
            });
            const result = await response.json().catch(() => ({}));
            if (!response.ok) throw new Error(result.error || 'Email verification failed.');
            message.textContent = result.message || 'Email verified. You can sign in now.';
        } catch (error) {
            message.textContent = error.message;
        }
    }

    avatar.addEventListener('click', () => {
        menu.hidden = !menu.hidden;
        avatar.setAttribute('aria-expanded', String(!menu.hidden));
    });
    account.querySelectorAll('[data-auth-action]').forEach(button => {
        button.addEventListener('click', () => {
            const action = button.dataset.authAction;
            showModal(action);
        });
    });
    modal.querySelector('[data-auth-action="forgot-password"]').addEventListener('click', () => {
        const loginEmail = modal.querySelector('[data-auth-form="login"] input[name="email"]').value;
        modal.querySelector('[data-auth-form="reset-request"] input[name="email"]').value = loginEmail;
        setMode('reset-request');
    });
    modal.querySelectorAll('[data-auth-mode]').forEach(button => {
        button.addEventListener('click', () => setMode(button.dataset.authMode));
    });
    modal.querySelector('.cscs-auth-close').addEventListener('click', () => { modal.hidden = true; });
    modal.addEventListener('click', event => { if (event.target === modal) modal.hidden = true; });
    modal.querySelectorAll('[data-auth-tab]').forEach(tab => {
        tab.addEventListener('click', () => setMode(tab.dataset.authTab));
    });

    modal.querySelectorAll('[data-auth-form]').forEach(form => {
        form.addEventListener('submit', async event => {
            event.preventDefault();
            const formData = Object.fromEntries(new FormData(form));
            const mode = form.dataset.authForm;
            const isRegister = mode === 'register';
            const isLogin = mode === 'login';
            let endpoint = '/v1/auth/login';
            if (isRegister) endpoint = '/v1/auth/register';
            if (mode === 'profile') endpoint = '/v1/account/profile';
            if (mode === 'change-password') endpoint = '/v1/account/password';
            if (mode === 'reset-request') endpoint = '/v1/auth/password-reset/request';
            if (mode === 'reset-complete') endpoint = '/v1/auth/password-reset/complete';
            if (isRegister && formData.password !== formData.passwordConfirm) {
                status.textContent = 'Passwords do not match.';
                return;
            }
            if (mode === 'change-password' && formData.newPassword !== formData.newPasswordConfirm) {
                status.textContent = 'New passwords do not match.';
                return;
            }
            delete formData.passwordConfirm;
            delete formData.newPasswordConfirm;
            if (isRegister) formData.pageUrl = window.location.href;
            if (mode === 'reset-request') formData.pageUrl = window.location.href;
            const submit = form.querySelector('.cscs-auth-submit');
            submit.disabled = true;
            status.textContent = 'Working...';
            try {
                const response = await fetch(`${apiBaseUrl}${endpoint}`, {
                    method: mode === 'profile' || mode === 'change-password' ? 'PUT' : 'POST',
                    credentials: 'include',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(formData)
                });
                const result = await response.json().catch(() => ({}));
                if (!response.ok) throw new Error(result.error || 'The account request failed.');
                if (mode === 'reset-request') {
                    if (result.resetToken) {
                        modal.querySelector('[data-auth-form="reset-complete"] input[name="token"]').value = result.resetToken;
                        setMode('reset-complete');
                        status.textContent = 'Development reset link created. Enter a new password.';
                    } else {
                        status.textContent = result.message || 'If an account exists for that email, a password reset link has been created.';
                    }
                    return;
                }
                if (mode === 'reset-complete') {
                    setMode('login');
                    status.textContent = result.message || 'Password reset. Sign in with your new password.';
                    return;
                }
                if (mode === 'profile') {
                    currentUser = result;
                    avatar.querySelector('span').textContent = result.displayName.split(/\s+/).map(part => part[0]).join('').slice(0, 2).toUpperCase();
                    status.textContent = 'Profile saved.';
                    return;
                }
                if (mode === 'change-password') {
                    form.reset();
                    setMode('profile');
                    status.textContent = result.message || 'Password changed.';
                    return;
                }
                if (isRegister) {
                    setMode('login');
                    status.textContent = result.message || 'Account created. Check your email to verify your account before signing in.';
                    return;
                }
                status.textContent = 'Signed in.';
                if (isLogin) {
                    avatar.classList.add('is-signed-in');
                    await updateAccountMenu();
                    window.setTimeout(() => {
                        modal.hidden = true;
                    }, 450);
                }
            } catch (error) {
                status.textContent = error.message;
            } finally {
                submit.disabled = false;
            }
        });
    });

    const reset = getSearchToken('resetToken', 'passwordResetToken');
    if (reset) {
        modal.querySelector('[data-auth-form="reset-complete"] input[name="token"]').value = reset.value;
        showModal('reset-complete');
        status.textContent = 'Enter a new password to finish resetting your account.';
        removeSearchTokens('resetToken', 'passwordResetToken');
    }
    const verification = getSearchToken('verifyToken', 'verificationToken', 'emailVerificationToken');
    if (verification) {
        confirmEmailVerification(verification.value);
        removeSearchTokens('verifyToken', 'verificationToken', 'emailVerificationToken');
    }
    updateAccountMenu();
    const adminSection = new URLSearchParams(window.location.search).get('cscsAdmin');
    if (adminSection) {
        showAdminWorkspace(adminSection);
    }

    async function showProfile() {
        showModal('profile');
        setStatus('Loading profile...');
        try {
            const response = await fetch(`${apiBaseUrl}/v1/account/profile`, { credentials: 'include' });
            const user = await response.json().catch(() => ({}));
            if (!response.ok) throw new Error(user.error || 'Profile could not be loaded.');
            currentUser = user;
            const form = modal.querySelector('[data-auth-form="profile"]');
            form.elements.displayName.value = user.displayName || '';
            form.elements.email.value = user.email || '';
            form.elements.institution.value = formatInstitution(user.institution);
            form.elements.institutionId.value = user.institutionId || '';
            form.elements.academicYear.value = formatAcademicYear(user.academicYear);
            form.elements.semester.value = formatSemester(user.semester);
            form.elements.role.value = user.role || '';
            setStatus('');
        } catch (error) {
            setStatus(error.message);
        }
    }

    async function showUsers() {
        showModal('users');
        setStatus('Loading users...');
        const list = modal.querySelector('.cscs-users-list');
        list.textContent = '';
        try {
            const response = await fetch(`${apiBaseUrl}/v1/admin/users`, { credentials: 'include' });
            const users = await response.json().catch(() => []);
            if (!response.ok) throw new Error(users.error || 'Users could not be loaded.');
            renderUsers(users);
            setStatus('');
        } catch (error) {
            setStatus(error.message);
        }
    }

    function renderUsers(users) {
        const list = modal.querySelector('.cscs-users-list');
        const institutions = ['Unknown', 'MissouriST', 'UniversityOfMissouriSystem'];
        const semesters = ['Spring', 'Summer', 'Fall'];
        const roles = ['Student', 'TA', 'Instructor', 'Editor', 'Author', 'Admin'];
        list.innerHTML = users.map(user => `
            <div class="cscs-user-row" data-user-id="${user.id}">
                <div class="cscs-user-main">
                    <strong>${escapeHtml(user.displayName || user.email)}</strong>
                    <span>${escapeHtml(user.email)}</span>
                    <span>${formatInstitution(user.institution)}${user.institutionId ? ` (${escapeHtml(user.institutionId)})` : ''} · ${formatTerm(user.academicYear, user.semester)} · ${user.isEmailVerified ? 'Verified' : 'Unverified'}</span>
                </div>
                <div class="cscs-user-controls">
                    <select data-user-field="institution" aria-label="Institution for ${escapeHtml(user.email)}">
                        ${institutions.map(institution => `<option value="${institution}" ${institution === user.institution ? 'selected' : ''}>${formatInstitution(institution)}</option>`).join('')}
                    </select>
                    <input data-user-field="academicYear" value="${escapeHtml(user.academicYear || '')}" inputmode="numeric" maxlength="4" aria-label="Academic year for ${escapeHtml(user.email)}">
                    <select data-user-field="semester" aria-label="Semester for ${escapeHtml(user.email)}">
                        ${semesters.map(semester => `<option value="${semester}" ${semester === user.semester ? 'selected' : ''}>${formatSemester(semester)}</option>`).join('')}
                    </select>
                    <select data-user-field="role" aria-label="Role for ${escapeHtml(user.email)}">
                        ${roles.map(role => `<option value="${role}" ${role === user.role ? 'selected' : ''}>${role}</option>`).join('')}
                    </select>
                </div>
            </div>
        `).join('');
        list.querySelectorAll('.cscs-user-row select').forEach(select => {
            select.addEventListener('change', async () => {
                const row = select.closest('.cscs-user-row');
                const body = select.dataset.userField === 'institution'
                    ? { institution: select.value }
                    : select.dataset.userField === 'semester'
                        ? { semester: select.value }
                        : { role: select.value };
                select.disabled = true;
                setStatus('Saving user...');
                try {
                    const response = await fetch(`${apiBaseUrl}/v1/admin/users/${row.dataset.userId}`, {
                        method: 'PATCH',
                        credentials: 'include',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify(body)
                    });
                    const result = await response.json().catch(() => ({}));
                    if (!response.ok) throw new Error(result.error || 'User could not be saved.');
                    setStatus('User saved.');
                } catch (error) {
                    setStatus(error.message);
                } finally {
                    select.disabled = false;
                }
            });
        });
    }

    async function showAdminWorkspace(section) {
        let workspace = document.querySelector('.cscs-admin-workspace');
        if (!workspace) {
            workspace = document.createElement('div');
            workspace.className = 'cscs-admin-workspace';
            workspace.innerHTML = `
                <header class="cscs-admin-header">
                    <div>
                        <p class="cscs-admin-kicker">Course admin</p>
                        <h1>Users</h1>
                    </div>
                    <nav class="cscs-admin-nav" aria-label="Admin sections">
                        <button type="button" data-admin-section="users">Users</button>
                        <button type="button" disabled>Attempts</button>
                        <button type="button" disabled>Score Report</button>
                        <button type="button" disabled>Assignments</button>
                    </nav>
                    <button class="cscs-admin-close" type="button">Back to book</button>
                </header>
                <main class="cscs-admin-main">
                    <section class="cscs-admin-panel">
                        <div class="cscs-admin-toolbar">
                            <input type="search" placeholder="Filter users" aria-label="Filter users">
                            <span class="cscs-admin-status" aria-live="polite"></span>
                        </div>
                        <div class="cscs-admin-content"></div>
                    </section>
                </main>`;
            document.body.appendChild(workspace);
            workspace.querySelector('.cscs-admin-close').addEventListener('click', () => {
                const cleanUrl = new URL(window.location.href);
                cleanUrl.searchParams.delete('cscsAdmin');
                window.location.href = cleanUrl.toString();
            });
        }

        document.body.classList.add('cscs-admin-open');
        workspace.querySelectorAll('[data-admin-section]').forEach(button => {
            button.classList.toggle('is-active', button.dataset.adminSection === section);
        });
        if (section === 'users') {
            await loadAdminUsers(workspace);
        } else {
            workspace.querySelector('.cscs-admin-content').innerHTML = '<p class="cscs-admin-empty">This admin section is not available yet.</p>';
        }
    }

    async function loadAdminUsers(workspace) {
        const status = workspace.querySelector('.cscs-admin-status');
        const content = workspace.querySelector('.cscs-admin-content');
        const filter = workspace.querySelector('.cscs-admin-toolbar input');
        const institutions = ['Unknown', 'MissouriST', 'UniversityOfMissouriSystem'];
        const semesters = ['Spring', 'Summer', 'Fall'];
        const roles = ['Student', 'TA', 'Instructor', 'Editor', 'Author', 'Admin'];
        status.textContent = 'Loading users...';
        content.innerHTML = '';

        try {
            const response = await fetch(`${apiBaseUrl}/v1/admin/users`, { credentials: 'include' });
            const users = await response.json().catch(() => []);
            if (!response.ok) throw new Error(users.error || 'Users could not be loaded.');

            const render = () => {
                const query = filter.value.trim().toLowerCase();
                const visibleUsers = users.filter(user => {
                    const haystack = `${user.displayName || ''} ${user.email || ''} ${user.role || ''} ${formatInstitution(user.institution)} ${user.institutionId || ''} ${formatTerm(user.academicYear, user.semester)}`.toLowerCase();
                    return haystack.includes(query);
                });
                content.innerHTML = `
                    <div class="cscs-admin-users-table" role="table" aria-label="Course users">
                        <div class="cscs-admin-users-head" role="row">
                            <span role="columnheader">Name</span>
                            <span role="columnheader">Email</span>
                            <span role="columnheader">Institution</span>
                            <span role="columnheader">Institution ID</span>
                            <span role="columnheader">Academic Year</span>
                            <span role="columnheader">Semester</span>
                            <span role="columnheader">Role</span>
                            <span role="columnheader">Verified</span>
                            <span role="columnheader">Created</span>
                        </div>
                        ${visibleUsers.map(user => `
                            <div class="cscs-admin-user-row" role="row" data-user-id="${user.id}">
                                <span role="cell">${escapeHtml(user.displayName || '')}</span>
                                <span role="cell">${escapeHtml(user.email || '')}</span>
                                <span role="cell">
                                    <select data-user-field="institution" aria-label="Institution for ${escapeHtml(user.email || '')}">
                                        ${institutions.map(institution => `<option value="${institution}" ${institution === user.institution ? 'selected' : ''}>${formatInstitution(institution)}</option>`).join('')}
                                    </select>
                                </span>
                                <span role="cell">
                                    <input data-user-field="institutionId" value="${escapeHtml(user.institutionId || '')}" maxlength="64" aria-label="Institution ID for ${escapeHtml(user.email || '')}">
                                </span>
                                <span role="cell">
                                    <input data-user-field="academicYear" value="${escapeHtml(user.academicYear || '')}" inputmode="numeric" maxlength="4" aria-label="Academic year for ${escapeHtml(user.email || '')}">
                                </span>
                                <span role="cell">
                                    <select data-user-field="semester" aria-label="Semester for ${escapeHtml(user.email || '')}">
                                        ${semesters.map(semester => `<option value="${semester}" ${semester === user.semester ? 'selected' : ''}>${formatSemester(semester)}</option>`).join('')}
                                    </select>
                                </span>
                                <span role="cell">
                                    <select data-user-field="role" aria-label="Role for ${escapeHtml(user.email || '')}">
                                        ${roles.map(role => `<option value="${role}" ${role === user.role ? 'selected' : ''}>${role}</option>`).join('')}
                                    </select>
                                </span>
                                <span role="cell">${formatDate(user.emailVerifiedUtc)}</span>
                                <span role="cell">${formatDate(user.createdUtc)}</span>
                            </div>
                        `).join('')}
                    </div>`;
                if (!visibleUsers.length) {
                    content.innerHTML = '<p class="cscs-admin-empty">No users match that filter.</p>';
                }
                bindAdminRoleControls(workspace, users);
                status.textContent = `${visibleUsers.length} user${visibleUsers.length === 1 ? '' : 's'}`;
            };

            filter.oninput = render;
            render();
        } catch (error) {
            status.textContent = '';
            content.innerHTML = `<p class="cscs-admin-empty">${escapeHtml(error.message)}</p>`;
        }
    }

    function bindAdminRoleControls(workspace, users) {
        const status = workspace.querySelector('.cscs-admin-status');
        workspace.querySelectorAll('.cscs-admin-user-row select').forEach(select => {
            select.addEventListener('change', async () => {
                const row = select.closest('.cscs-admin-user-row');
                const user = users.find(candidate => String(candidate.id) === row.dataset.userId);
                const field = select.dataset.userField;
                const previousValue = field === 'institution' ? user?.institution : field === 'semester' ? user?.semester : user?.role;
                const body = field === 'institution'
                    ? { institution: select.value }
                    : field === 'semester'
                        ? { semester: select.value }
                    : { role: select.value };
                select.disabled = true;
                status.textContent = 'Saving user...';
                try {
                    const response = await fetch(`${apiBaseUrl}/v1/admin/users/${row.dataset.userId}`, {
                        method: 'PATCH',
                        credentials: 'include',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify(body)
                    });
                    const result = await response.json().catch(() => ({}));
                    if (!response.ok) throw new Error(result.error || 'User could not be saved.');
                    if (user && field === 'institution') {
                        user.institution = result.institution || select.value;
                        user.institutionId = result.institutionId || '';
                        const idInput = row.querySelector('input[data-user-field="institutionId"]');
                        if (idInput) idInput.value = user.institutionId;
                    }
                    if (user && field === 'role') user.role = select.value;
                    if (user && field === 'semester') user.semester = select.value;
                    status.textContent = 'User saved.';
                } catch (error) {
                    if (previousValue) select.value = previousValue;
                    status.textContent = error.message;
                } finally {
                    select.disabled = false;
                }
            });
        });
        workspace.querySelectorAll('.cscs-admin-user-row input[data-user-field="institutionId"]').forEach(input => {
            input.addEventListener('change', async () => {
                const row = input.closest('.cscs-admin-user-row');
                const user = users.find(candidate => String(candidate.id) === row.dataset.userId);
                const previousValue = user?.institutionId || '';
                input.disabled = true;
                status.textContent = 'Saving user...';
                try {
                    const response = await fetch(`${apiBaseUrl}/v1/admin/users/${row.dataset.userId}`, {
                        method: 'PATCH',
                        credentials: 'include',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ institutionId: input.value })
                    });
                    const result = await response.json().catch(() => ({}));
                    if (!response.ok) throw new Error(result.error || 'User could not be saved.');
                    if (user) user.institutionId = input.value.trim();
                    status.textContent = 'User saved.';
                } catch (error) {
                    input.value = previousValue;
                    status.textContent = error.message;
                } finally {
                    input.disabled = false;
                }
            });
        });
        workspace.querySelectorAll('.cscs-admin-user-row input[data-user-field="academicYear"]').forEach(input => {
            input.addEventListener('change', async () => {
                const row = input.closest('.cscs-admin-user-row');
                const user = users.find(candidate => String(candidate.id) === row.dataset.userId);
                const previousValue = String(user?.academicYear || '');
                input.disabled = true;
                status.textContent = 'Saving user...';
                try {
                    const response = await fetch(`${apiBaseUrl}/v1/admin/users/${row.dataset.userId}`, {
                        method: 'PATCH',
                        credentials: 'include',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify({ academicYear: Number(input.value) })
                    });
                    const result = await response.json().catch(() => ({}));
                    if (!response.ok) throw new Error(result.error || 'User could not be saved.');
                    if (user) user.academicYear = Number(input.value);
                    status.textContent = 'User saved.';
                } catch (error) {
                    input.value = previousValue;
                    status.textContent = error.message;
                } finally {
                    input.disabled = false;
                }
            });
        });
    }

    function escapeHtml(value) {
        return String(value).replace(/[&<>"']/g, char => ({
            '&': '&amp;',
            '<': '&lt;',
            '>': '&gt;',
            '"': '&quot;',
            "'": '&#39;'
        }[char]));
    }

    function formatInstitution(value) {
        const labels = {
            Unknown: 'Unknown',
            MissouriST: 'Missouri S&T',
            UniversityOfMissouriSystem: 'UM System'
        };
        return labels[value] || value || 'Unknown';
    }

    function formatDate(value) {
        if (!value) return 'Not yet';
        const date = new Date(value);
        if (Number.isNaN(date.getTime())) return 'Not yet';
        return date.toLocaleDateString(undefined, { year: 'numeric', month: 'short', day: 'numeric' });
    }

    function formatAcademicYear(value) {
        const year = Number(value);
        if (!Number.isInteger(year) || year <= 0) return '';
        return `${year}-${String(year + 1).slice(-2)}`;
    }

    function formatSemester(value) {
        return value || 'Unknown';
    }

    function formatTerm(academicYear, semester) {
        const year = formatAcademicYear(academicYear);
        const label = formatSemester(semester);
        return year ? `${label} ${year}` : label;
    }

    async function enableAuthorMode() {
        const path = window.location.pathname
            .replace(/^\//, '')
            .replace(/\.html$/, '.ipynb');
        try {
            const response = await fetch(`${apiBaseUrl}/v1/admin/notebooks/source?path=${encodeURIComponent(path)}`, {
                credentials: 'include'
            });
            if (!response.ok) throw new Error('The notebook source could not be loaded.');
            const notebook = await response.json();
            const codeCells = Array.from(document.querySelectorAll('div.cscs-code-cell .cell_input pre'));
            const notebookCodeCells = codeCells.map(element => {
                const cell = element.closest('.cscs-code-cell');
                const index = Number(cell?.dataset.cscsCellIndex);
                return { element, index, sourceCell: notebook.cells[index], editor: cell?.querySelector('.cscs-code-editor') };
            });
            notebookCodeCells.forEach(({ element, sourceCell }) => {
                if (sourceCell) {
                    const cell = element.closest('.cell');
                    const editor = cell?.querySelector('.cscs-code-editor');
                    const editButton = cell?.querySelector('.cscs-edit-button');
                    const resetButton = cell?.querySelector('.cscs-reset-button');
                    const sourceText = Array.isArray(sourceCell.source)
                        ? sourceCell.source.join('')
                        : sourceCell.source;
                    if (editor && typeof sourceText === 'string') {
                        editor.value = normalizeCode(sourceText);
                    }
                    sourceCell.source = sourceText;
                    if (editButton) editButton.hidden = false;
                    if (resetButton) resetButton.hidden = true;
                    addAuthorCellControls(cell, editButton, editor, element);
                }
            });
            const markdownGroups = new Map();
            document.querySelectorAll('[data-cscs-cell-type="markdown"]').forEach(element => {
                const index = Number(element.dataset.cscsCellIndex);
                const sourceCell = notebook.cells[index];
                if (!sourceCell || sourceCell.cell_type !== 'markdown' || element.dataset.cscsMarkdownReady === 'true') return;
                if (!markdownGroups.has(index)) {
                    markdownGroups.set(index, { index, sourceCell, elements: [] });
                }
                markdownGroups.get(index).elements.push(element);
                element.dataset.cscsMarkdownReady = 'true';
            });
            const markdownCells = [];
            markdownGroups.forEach(group => {
                const { sourceCell, elements } = group;
                if (!elements.length) return;
                const source = Array.isArray(sourceCell.source) ? sourceCell.source.join('') : sourceCell.source;
                const editor = document.createElement('textarea');
                editor.className = 'cscs-markdown-editor';
                editor.value = source || '';
                editor.hidden = true;
                const preview = document.createElement('div');
                preview.className = 'cscs-markdown-preview';
                preview.hidden = true;
                const button = document.createElement('button');
                button.className = 'cscs-markdown-edit';
                button.type = 'button';
                button.textContent = 'Edit markdown';
                button.hidden = true;
                button.addEventListener('click', () => {
                    const opening = editor.hidden;
                    editor.hidden = !opening;
                    preview.hidden = true;
                    elements.forEach(element => {
                        element.hidden = true;
                    });
                    if (!opening) {
                        preview.innerHTML = renderMarkdownPreview(editor.value);
                        preview.hidden = false;
                    }
                    button.textContent = opening ? 'Done markdown' : 'Edit markdown';
                });
                const previewButton = document.createElement('button');
                previewButton.className = 'cscs-markdown-preview-button';
                previewButton.type = 'button';
                previewButton.textContent = 'Preview markdown';
                previewButton.hidden = true;
                previewButton.addEventListener('click', () => {
                    preview.innerHTML = renderMarkdownPreview(editor.value);
                    preview.hidden = false;
                });
                elements[0].before(editor, preview);
                elements[elements.length - 1].after(button, previewButton);
                markdownCells.push({ elements, editor, preview, sourceCell });
            });
            window.cscsAuthorState = { path, notebook, notebookCodeCells, markdownCells, codeCells };
            document.body.classList.add('cscs-author-active');
            document.querySelectorAll('.cscs-markdown-edit, .cscs-markdown-preview-button').forEach(button => { button.hidden = false; });
            addAuthorSaveControl();
        } catch (error) {
            alert(error.message);
        }
    }

    function addAuthorSaveControl() {
        if (document.querySelector('.cscs-author-save')) return;
        const save = document.createElement('button');
        save.className = 'cscs-author-save';
        save.type = 'button';
        save.textContent = 'Save notebook';
        const saveNotebook = async () => {
            const state = window.cscsAuthorState;
            state.notebookCodeCells.forEach(({ element, sourceCell, editor }) => {
                if (sourceCell) sourceCell.source = editor?.value ?? element.textContent;
            });
            state.markdownCells.forEach(({ editor, sourceCell }) => {
                if (sourceCell) sourceCell.source = editor.value;
            });
            const response = await fetch(`${apiBaseUrl}/v1/admin/notebooks/save`, {
                method: 'POST',
                credentials: 'include',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ path: state.path, content: JSON.stringify(state.notebook, null, 1) })
            });
            const result = await response.json();
            save.textContent = response.ok ? 'Saved' : (result.message || 'Save failed');
            if (response.ok) closeInlineEditors();
            window.setTimeout(() => { save.textContent = 'Save notebook'; }, 2500);
        };
        window.cscsSaveNotebook = saveNotebook;
        save.addEventListener('click', saveNotebook);
        document.body.appendChild(save);
        document.querySelectorAll('.cscs-student-copy').forEach(copy => {
            if (copy.querySelector('.cscs-author-copy-save')) return;
            const copySave = document.createElement('button');
            copySave.type = 'button';
            copySave.className = 'cscs-author-copy-save';
            copySave.textContent = 'Save notebook';
            copySave.addEventListener('click', () => save.click());
            copy.appendChild(copySave);
        });
    }

    function addAuthorCellControls(cell, editButton, editor, codeElement) {
        if (!cell || cell.querySelector('.cscs-author-cell-controls')) return;
        const runButton = cell.querySelector('.cscs-run-button');
        const controls = cell.querySelector('.cscs-execution-controls');
        if (!runButton || !controls) return;

        if (editButton) editButton.hidden = true;
        const authorControls = document.createElement('span');
        authorControls.className = 'cscs-author-cell-controls';

        const authorButton = document.createElement('button');
        authorButton.type = 'button';
        authorButton.textContent = 'Author';
        authorButton.addEventListener('click', () => editButton?.click());

        const doneButton = document.createElement('button');
        doneButton.type = 'button';
        doneButton.textContent = 'Done';
        doneButton.hidden = true;
        doneButton.addEventListener('click', () => editButton?.click());

        const saveButton = document.createElement('button');
        saveButton.type = 'button';
        saveButton.textContent = 'Save';
        saveButton.addEventListener('click', () => window.cscsSaveNotebook?.());

        authorControls.append(authorButton, doneButton, saveButton);
        controls.appendChild(authorControls);

        const originalEdit = editButton;
        originalEdit.addEventListener('click', () => {
            const copy = controls.closest('.cscs-student-copy');
            if (copy) {
                authorButton.hidden = true;
                doneButton.hidden = false;
            } else {
                authorButton.hidden = false;
                doneButton.hidden = true;
            }
        });
    }

    function closeInlineEditors() {
        document.querySelectorAll('.cscs-code-editor[data-inline-open="true"]').forEach(editor => {
            const cell = editor.closest('.cell');
            const inlineButton = cell?.querySelector('.cscs-inline-button');
            if (inlineButton && inlineButton.textContent.trim() === 'Done') {
                inlineButton.click();
            }
        });
    }

    function renderMarkdownPreview(source) {
        const escaped = source.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
        const lines = escaped.split('\n');
        let inCode = false;
        let inList = false;
        const output = [];
        const closeList = () => {
            if (inList) {
                output.push('</ul>');
                inList = false;
            }
        };
        lines.forEach(line => {
            if (line.trim().startsWith('```')) {
                closeList();
                output.push(inCode ? '</code></pre>' : '<pre><code>');
                inCode = !inCode;
            } else if (inCode) {
                output.push(line);
            } else if (/^###\s+/.test(line)) {
                closeList();
                output.push(`<h3>${line.replace(/^###\s+/, '')}</h3>`);
            } else if (/^##\s+/.test(line)) {
                closeList();
                output.push(`<h2>${line.replace(/^##\s+/, '')}</h2>`);
            } else if (/^#\s+/.test(line)) {
                closeList();
                output.push(`<h1>${line.replace(/^#\s+/, '')}</h1>`);
            } else if (/^[-*]\s+/.test(line)) {
                if (!inList) {
                    output.push('<ul>');
                    inList = true;
                }
                output.push(`<li>${line.replace(/^[-*]\s+/, '')}</li>`);
            } else if (line.trim()) {
                closeList();
                output.push(`<p>${line.replace(/`([^`]+)`/g, '<code>$1</code>')}</p>`);
            } else {
                closeList();
            }
        });
        closeList();
        return output.join('');
    }

    function normalizeCode(source) {
        return source.replace(/^\s*%{1,2}csharp\s*\r?\n/i, '');
    }
});

// Reading continuity: localStorage first, database sync when signed in.
document.addEventListener('DOMContentLoaded', function () {
    const storageKey = 'cscs:lastReadingPage';
    const pendingScrollKey = 'cscs:pendingScroll';
    const bookId = 'cscs';
    const apiBaseUrl = localStorage.getItem('CSCS_EXECUTION_API') ||
        window.CSCS_EXECUTION_API ||
        (location.hostname.endsWith('thinkcscs.org') ? 'https://thinkcscs.org/cscs-exec' : 'http://localhost:8080');
    function currentPageUrl() {
        return window.location.pathname + window.location.search + window.location.hash;
    }

    function currentPageTitle() {
        const heading = document.querySelector('main h1') || document.querySelector('h1');
        return (heading?.textContent || document.title || 'Current page').replace(/\s+/g, ' ').trim();
    }

    function shouldTrackPage() {
        return isTrackablePageUrl(currentPageUrl());
    }

    function isTrackablePageUrl(pageUrl) {
        let path = pageUrl || '';
        try {
            path = new URL(pageUrl, window.location.href).pathname;
        } catch (_) {
            path = pageUrl.split(/[?#]/)[0];
        }
        path = path.replace(/\/+$/, '');
        return (
            (path.endsWith('.html') || path === '') &&
            path !== '' &&
            path !== '/' &&
            path !== '/chapters/preface' &&
            !path.endsWith('/index.html') &&
            !path.endsWith('/chapters/preface.html') &&
            !path.endsWith('/genindex.html') &&
            !path.endsWith('/search.html')
        );
    }

    function safeJson(value) {
        try {
            return JSON.parse(value);
        } catch (_) {
            return null;
        }
    }

    function readLocalProgress() {
        const progress = safeJson(localStorage.getItem(storageKey));
        if (progress?.pageUrl && !isTrackablePageUrl(progress.pageUrl)) {
            localStorage.removeItem(storageKey);
            return null;
        }
        return progress;
    }

    function writeLocalProgress(progress) {
        if (!progress?.pageUrl || !isTrackablePageUrl(progress.pageUrl)) return;
        localStorage.setItem(storageKey, JSON.stringify(progress));
        renderContinueReading(progress);
    }

    function makeProgress() {
        return {
            bookId,
            pageUrl: currentPageUrl(),
            pageTitle: currentPageTitle(),
            scrollY: Math.max(0, Math.round(window.scrollY || 0)),
            updatedUtc: new Date().toISOString()
        };
    }

    function saveLocalProgress() {
        if (!shouldTrackPage()) return null;
        const progress = makeProgress();
        writeLocalProgress(progress);
        return progress;
    }

    async function syncProgress(progress) {
        if (!progress?.pageUrl || !isTrackablePageUrl(progress.pageUrl)) return;
        try {
            const response = await fetch(`${apiBaseUrl}/v1/progress/reading`, {
                method: 'POST',
                credentials: 'include',
                keepalive: true,
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(progress)
            });
            if (response.ok) {
                const remote = await response.json();
                writeLocalProgress(normalizeProgress(remote));
            }
        } catch (_) {
            // Anonymous readers and offline local builds keep browser-local progress.
        }
    }

    async function loadRemoteProgress() {
        try {
            const response = await fetch(`${apiBaseUrl}/v1/progress/reading`, { credentials: 'include' });
            if (response.status === 204 || response.status === 401 || response.status === 403) return;
            if (!response.ok) return;
            const remote = normalizeProgress(await response.json());
            if (!isTrackablePageUrl(remote.pageUrl)) return;
            const local = readLocalProgress();
            if (!local || Date.parse(remote.updatedUtc) > Date.parse(local.updatedUtc || 0)) {
                writeLocalProgress(remote);
            }
        } catch (_) {
            // The API is optional for static/local reading.
        }
    }

    function normalizeProgress(progress) {
        return {
            bookId: progress.bookId || progress.BookId || bookId,
            pageUrl: progress.pageUrl || progress.PageUrl || '/',
            pageTitle: progress.pageTitle || progress.PageTitle || 'Continue reading',
            scrollY: Number(progress.scrollY ?? progress.ScrollY ?? 0),
            updatedUtc: progress.updatedUtc || progress.UpdatedUtc || new Date().toISOString()
        };
    }

    function renderContinueReading(progress) {
        if (!progress?.pageUrl) return;
        let panel = document.querySelector('.cscs-continue-reading');
        if (!isTrackablePageUrl(progress.pageUrl)) {
            panel?.remove();
            return;
        }
        if (progress.pageUrl === currentPageUrl()) {
            panel?.remove();
            return;
        }
        if (!panel) {
            panel = document.createElement('div');
            panel.className = 'cscs-continue-reading';
            document.body.appendChild(panel);
        }
        const label = progress.pageTitle || 'Continue reading';
        panel.innerHTML = `
            <p>Continue Reading</p>
            <button type="button">
                <span></span>
                <svg aria-hidden="true" viewBox="0 0 24 24">
                    <path d="M6 4.75A2.75 2.75 0 0 1 8.75 2h6.5A2.75 2.75 0 0 1 18 4.75v16.1a.75.75 0 0 1-1.17.62L12 18.22l-4.83 3.25A.75.75 0 0 1 6 20.85V4.75Z"></path>
                </svg>
            </button>`;
        const button = panel.querySelector('button');
        button.querySelector('span').textContent = label;
        button.addEventListener('click', () => {
            localStorage.setItem(pendingScrollKey, JSON.stringify({
                pageUrl: progress.pageUrl,
                scrollY: progress.scrollY || 0
            }));
            if (progress.pageUrl === currentPageUrl()) {
                restorePendingScroll();
            } else {
                window.location.href = progress.pageUrl;
            }
        });
    }

    function restorePendingScroll() {
        const pending = safeJson(localStorage.getItem(pendingScrollKey));
        if (!pending || pending.pageUrl !== currentPageUrl()) return;
        localStorage.removeItem(pendingScrollKey);
        window.setTimeout(() => {
            window.scrollTo({ top: Math.max(0, Number(pending.scrollY || 0)), behavior: 'smooth' });
        }, 100);
    }

    function throttle(fn, wait) {
        let timeout = null;
        return function () {
            if (timeout) return;
            timeout = window.setTimeout(() => {
                timeout = null;
                fn();
            }, wait);
        };
    }

    const initialLocal = readLocalProgress();
    if (initialLocal) renderContinueReading(initialLocal);
    restorePendingScroll();

    const saveAndSync = throttle(() => {
        if (!shouldTrackPage()) return;
        const progress = saveLocalProgress();
        syncProgress(progress);
    }, 3000);

    if (shouldTrackPage()) {
        window.addEventListener('scroll', saveAndSync, { passive: true });
        window.addEventListener('pagehide', () => {
            const progress = saveLocalProgress();
            syncProgress(progress);
        });

        const progress = saveLocalProgress();
        syncProgress(progress);
    }
    loadRemoteProgress();
});


// Override Thebe config to use JupyterHub instead of Binder
// Override Thebe config BEFORE it loads
// (function() {
//     const observer = new MutationObserver(function() {
//         const thebeConfig = document.querySelector('script[type="text/x-thebe-config"]');
//         if (thebeConfig) {
//             thebeConfig.textContent = JSON.stringify({
//                 requestKernel: true,
//                 jupyterhubUrl: "https://thinkcscs.org",
//                 token: "11b92943ad141088b548a87952ea88ea7567c66406934fdc4032947b6fdeb80c",
//                 kernelOptions: {
//                     name: ".net-csharp"
//                 },
//                 predefinedOutput: true
//             });
//             observer.disconnect();
//         }
//     });
//     observer.observe(document.documentElement, {childList: true, subtree: true});
// })();
