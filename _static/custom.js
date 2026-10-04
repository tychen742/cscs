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

// Browser authoring for Press authors. Sign-in, sign-out, and the account menu come from
// Press's shared auth.js (loaded by thinkpress-config.js). This adds "Edit this page" to
// that menu for authoring roles; authoring requests carry a Press-signed author pass.
document.addEventListener('DOMContentLoaded', function () {
    const onSite = location.hostname.endsWith('thinkcscs.org');
    const apiBaseUrl = localStorage.getItem('CSCS_EXECUTION_API') ||
        window.CSCS_EXECUTION_API ||
        (onSite ? 'https://thinkcscs.org/cscs-exec' : 'http://localhost:8080');
    const runnerBaseUrl = localStorage.getItem('CSCS_RUNNER_API') ||
        window.CSCS_RUNNER_API ||
        (onSite ? 'https://thinkcscs.org/cscs-exec' : 'http://localhost:8081');
    // Press roles that may author; the authoring API enforces the same list.
    const authorRoles = new Set(['admin', 'author', 'editor', 'instructor', 'ta']);

    function addAuthorMenuItem(session) {
        if (!session?.authenticated || !authorRoles.has(session.user?.role)) return;
        const account = document.getElementById('thinkpress-account');
        const menu = account?.querySelector('nav');
        if (!menu || menu.querySelector('[data-cscs-author]')) return;
        const edit = document.createElement('a');
        edit.href = '#';
        edit.textContent = 'Edit this page';
        edit.dataset.cscsAuthor = 'true';
        edit.addEventListener('click', event => {
            event.preventDefault();
            account.open = false;
            enableAuthorMode();
        });
        menu.prepend(edit);
    }
    if (window.thinkpressSession) addAuthorMenuItem(window.thinkpressSession);
    document.addEventListener('thinkpress:session', event => addAuthorMenuItem(event.detail));

    async function authorHeaders(extra = {}) {
        const passHeader = window.cscsPress ? await window.cscsPress.authHeader('author') : {};
        return { ...extra, ...passHeader };
    }

    async function enableAuthorMode() {
        const path = window.location.pathname
            .replace(/^\//, '')
            .replace(/\.html$/, '.ipynb');
        try {
            const response = await fetch(`${apiBaseUrl}/v1/admin/notebooks/source?path=${encodeURIComponent(path)}`, {
                headers: await authorHeaders()
            });
            if (!response.ok) throw new Error('The notebook source could not be loaded.');
            const notebook = await response.json();
            const codeCells = Array.from(document.querySelectorAll('div.cscs-code-cell .cell_input pre'));
            const notebookCodeCells = [];
            const markdownCells = [];
            codeCells.map(element => {
                const cell = element.closest('.cscs-code-cell');
                const index = Number(cell?.dataset.cscsCellIndex);
                return { cell, element, index, sourceCell: notebook.cells[index], editor: cell?.querySelector('.cscs-code-editor') };
            }).forEach(({ cell, element, sourceCell, editor }) => {
                if (sourceCell && renderedCellMatchesSource(cell, sourceCell)) {
                    const cell = element.closest('.cell');
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
                    addAuthorCellControls(cell, editButton, editor, element, sourceCell, markdownCells, notebookCodeCells);
                    notebookCodeCells.push({ element, sourceCell, editor });
                } else if (cell) {
                    markAuthorCellOutOfSync(cell);
                }
            });
            const markdownGroups = new Map();
            document.querySelectorAll('[data-cscs-cell-type="markdown"]').forEach(element => {
                const index = Number(element.dataset.cscsCellIndex);
                const sourceCell = notebook.cells[index];
                if (!sourceCell || sourceCell.cell_type !== 'markdown' || element.dataset.cscsMarkdownReady === 'true') return;
                if (!renderedCellMatchesSource(element, sourceCell)) {
                    markAuthorMarkdownOutOfSync(element);
                    element.dataset.cscsMarkdownReady = 'out-of-sync';
                    return;
                }
                if (!markdownGroups.has(index)) {
                    markdownGroups.set(index, { index, sourceCell, elements: [] });
                }
                markdownGroups.get(index).elements.push(element);
                element.dataset.cscsMarkdownReady = 'true';
            });
            markdownGroups.forEach(group => {
                const { sourceCell, elements } = group;
                if (!elements.length) return;
                const source = Array.isArray(sourceCell.source) ? sourceCell.source.join('') : sourceCell.source;
                const renderedTextLength = elements.reduce((total, element) => total + element.textContent.trim().length, 0);
                const maxExpectedBlocks = estimateMarkdownBlockCount(source) + 3;
                if (elements.length > maxExpectedBlocks || renderedTextLength > source.length * 4 + 1000) {
                    console.warn('[cscs authoring] Skipping suspicious markdown cell mapping', {
                        sourceLength: source.length,
                        renderedTextLength,
                        renderedBlocks: elements.length,
                        maxExpectedBlocks
                    });
                    elements.forEach(element => { element.dataset.cscsMarkdownReady = 'suspicious'; });
                    return;
                }
                const editor = document.createElement('textarea');
                editor.className = 'cscs-markdown-editor';
                editor.value = source || '';
                const editCopy = document.createElement('div');
                editCopy.className = 'cscs-markdown-copy cscs-student-copy';
                editCopy.hidden = true;
                const editLabel = document.createElement('div');
                editLabel.className = 'cscs-student-copy-label';
                editLabel.textContent = 'Your version';
                editCopy.append(editLabel, editor);
                const preview = document.createElement('div');
                preview.className = 'cscs-markdown-preview';
                preview.hidden = true;
                const controls = document.createElement('div');
                controls.className = 'cscs-markdown-controls';
                controls.hidden = true;
                const editButton = document.createElement('button');
                editButton.className = 'cscs-markdown-edit';
                editButton.type = 'button';
                editButton.textContent = 'Edit';
                const inlineButton = document.createElement('button');
                inlineButton.className = 'cscs-markdown-inline';
                inlineButton.type = 'button';
                inlineButton.textContent = 'Inline';
                const resetButton = document.createElement('button');
                resetButton.className = 'cscs-markdown-reset';
                resetButton.type = 'button';
                resetButton.textContent = 'Reset';
                resetButton.hidden = true;
                const previewButton = document.createElement('button');
                previewButton.className = 'cscs-markdown-preview-button';
                previewButton.type = 'button';
                previewButton.textContent = 'Preview';
                previewButton.hidden = true;
                let markdownMode = null;
                const originalSource = source || '';
                const originalHtml = elements.map(element => element.innerHTML);
                const canInlineMarkdown = isMarkdownInlineSafe(originalSource, elements);
                const showRenderedElements = isVisible => {
                    elements.forEach(element => {
                        element.hidden = !isVisible;
                    });
                };
                const restoreOriginalRenderedElements = () => {
                    elements.forEach((element, index) => {
                        element.innerHTML = originalHtml[index] || '';
                    });
                    preview.hidden = true;
                    showRenderedElements(true);
                };
                const setInlineEditable = isEditable => {
                    elements.forEach(element => {
                        element.contentEditable = isEditable ? 'true' : 'false';
                        element.classList.toggle('cscs-markdown-inline-editing', isEditable);
                    });
                };
                const showDraftPreview = () => {
                    preview.innerHTML = renderMarkdownPreview(editor.value);
                    preview.hidden = false;
                    showRenderedElements(false);
                    editCopy.hidden = true;
                };
                const setDraftActionsVisible = isVisible => {
                    resetButton.hidden = !isVisible;
                    previewButton.hidden = !isVisible;
                };
                if (!canInlineMarkdown) {
                    inlineButton.disabled = true;
                    inlineButton.classList.add('is-disabled');
                    inlineButton.title = 'Inline editing is available for simple text markdown. Use Edit for code blocks, directives, tables, and other structured markdown.';
                }
                const closeMarkdownMode = () => {
                    if (markdownMode === 'inline') {
                        const inlineChanged = elements.some((element, index) => element.innerHTML !== (originalHtml[index] || ''));
                        editor.value = inlineChanged ? markdownFromRenderedElements(elements) : originalSource;
                    }
                    const isUnchanged = editor.value === originalSource;
                    markdownMode = null;
                    editCopy.hidden = true;
                    editor.classList.remove('is-inline');
                    setInlineEditable(false);
                    setDraftActionsVisible(false);
                    editButton.textContent = 'Edit';
                    inlineButton.textContent = 'Inline';
                    if (isUnchanged) {
                        restoreOriginalRenderedElements();
                    } else {
                        showDraftPreview();
                    }
                };
                const openMarkdownMode = mode => {
                    if (mode === 'inline' && !canInlineMarkdown) return;
                    markdownMode = mode;
                    editor.classList.toggle('is-inline', mode === 'inline');
                    editCopy.hidden = mode !== 'edit';
                    preview.hidden = true;
                    setDraftActionsVisible(true);
                    editButton.textContent = mode === 'edit' ? 'Done' : 'Edit';
                    inlineButton.textContent = mode === 'inline' ? 'Done' : 'Inline';
                    showRenderedElements(true);
                    setInlineEditable(mode === 'inline');
                    if (mode === 'inline') {
                        elements[0]?.focus();
                    } else {
                        editor.focus();
                    }
                };
                editButton.addEventListener('click', () => {
                    if (markdownMode === 'edit') {
                        closeMarkdownMode();
                    } else {
                        openMarkdownMode('edit');
                    }
                });
                inlineButton.addEventListener('click', () => {
                    if (markdownMode === 'inline') {
                        closeMarkdownMode();
                    } else {
                        openMarkdownMode('inline');
                    }
                });
                resetButton.addEventListener('click', () => {
                    editor.value = originalSource;
                    restoreOriginalRenderedElements();
                });
                previewButton.addEventListener('click', () => {
                    if (markdownMode === 'inline') {
                        editor.value = markdownFromRenderedElements(elements);
                    }
                    preview.innerHTML = renderMarkdownPreview(editor.value);
                    preview.hidden = false;
                });
                controls.append(editButton, inlineButton, resetButton, previewButton);
                elements[elements.length - 1].after(editCopy, preview, controls);
                markdownCells.push({ elements, editor, preview, sourceCell });
                addAuthorInsertControls(controls, sourceCell, markdownCells, notebookCodeCells);
            });
            window.cscsAuthorState = { path, notebook, notebookCodeCells, markdownCells, codeCells };
            document.body.classList.add('cscs-author-active');
            document.querySelectorAll('.cscs-markdown-controls').forEach(controls => { controls.hidden = false; });
            addAuthorSaveControl();
        } catch (error) {
            alert(error.message);
        }
    }

    function renderedCellMatchesSource(renderedElement, sourceCell) {
        const renderedId = renderedElement?.dataset?.cscsCellId || '';
        const sourceId = sourceCell?.id || sourceCell?.metadata?.id || '';
        return Boolean(renderedId && sourceId && renderedId === sourceId);
    }

    function markAuthorCellOutOfSync(cell) {
        if (!cell || cell.querySelector('.cscs-author-sync-warning')) return;
        const warning = document.createElement('div');
        warning.className = 'cscs-author-sync-warning';
        warning.textContent = 'Authoring unavailable: source out of sync. Rebuild before editing.';
        const controls = cell.querySelector('.cscs-execution-controls');
        (controls || cell).appendChild(warning);
    }

    function markAuthorMarkdownOutOfSync(element) {
        if (!element || element.nextElementSibling?.classList.contains('cscs-author-sync-warning')) return;
        const warning = document.createElement('div');
        warning.className = 'cscs-author-sync-warning';
        warning.textContent = 'Authoring unavailable: source out of sync. Rebuild before editing.';
        element.after(warning);
    }

    function addAuthorSaveControl() {
        if (document.querySelector('.cscs-author-save')) return;
        const save = document.createElement('button');
        save.className = 'cscs-author-save';
        save.type = 'button';
        save.textContent = 'Save notebook';
        const saveNotebook = async () => {
            save.textContent = 'Saving...';
            const state = window.cscsAuthorState;
            try {
                state.notebookCodeCells.forEach(({ element, sourceCell, editor }) => {
                    if (sourceCell) {
                        sourceCell.source = serializeNotebookSource(editor?.value ?? element.textContent, sourceCell.source);
                    }
                });
                state.markdownCells.forEach(({ elements, editor, sourceCell }) => {
                    if (elements?.some(element => element.classList.contains('cscs-markdown-inline-editing'))) {
                        editor.value = markdownFromRenderedElements(elements);
                    }
                    if (sourceCell) sourceCell.source = serializeNotebookSource(editor.value, sourceCell.source);
                });
                const response = await fetch(`${apiBaseUrl}/v1/admin/notebooks/save`, {
                    method: 'POST',
                    headers: await authorHeaders({ 'Content-Type': 'application/json' }),
                    body: JSON.stringify({ path: state.path, content: JSON.stringify(state.notebook, null, 1) })
                });
                const text = await response.text();
                let result = {};
                if (text) {
                    try {
                        result = JSON.parse(text);
                    } catch {
                        result = { message: text };
                    }
                }
                if (!response.ok) throw new Error(result.message || result.error || `Save failed (${response.status})`);
                save.textContent = 'Saved';
                closeInlineEditors();
            } catch (error) {
                save.textContent = error.message || 'Save failed';
            }
            window.setTimeout(() => { save.textContent = 'Save notebook'; }, 3500);
        };
        window.cscsSaveNotebook = saveNotebook;
        save.addEventListener('click', saveNotebook);
        document.body.appendChild(save);
        const sync = document.createElement('button');
        sync.className = 'cscs-author-sync';
        sync.type = 'button';
        sync.textContent = 'Sync';
        sync.addEventListener('click', async () => {
            sync.textContent = 'Syncing...';
            try {
                const response = await fetch(`${apiBaseUrl}/v1/admin/git/sync`, {
                    method: 'POST',
                    headers: await authorHeaders({ 'Content-Type': 'application/json' }),
                    body: JSON.stringify({ message: `Browser authoring updates from ${document.title || location.pathname}` })
                });
                const text = await response.text();
                let result = {};
                if (text) {
                    try {
                        result = JSON.parse(text);
                    } catch {
                        result = { message: text };
                    }
                }
                if (!response.ok) throw new Error(result.message || `Sync failed (${response.status})`);
                sync.textContent = result.head ? `Synced ${result.head}` : 'Synced';
            } catch (error) {
                sync.textContent = error.message || 'Sync failed';
            }
            window.setTimeout(() => { sync.textContent = 'Sync'; }, 4500);
        });
        document.body.appendChild(sync);
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

    function addAuthorCellControls(cell, editButton, editor, codeElement, sourceCell, markdownCells, notebookCodeCells) {
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
        addAuthorInsertControls(controls, sourceCell, markdownCells, notebookCodeCells);

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

    function addAuthorInsertControls(container, sourceCell, markdownCells, notebookCodeCells) {
        if (!container || !sourceCell || container.querySelector('.cscs-author-insert-controls')) return;
        let insertionAnchor = sourceCell;
        const insertControls = document.createElement('span');
        insertControls.className = 'cscs-author-insert-controls';

        const markdownButton = document.createElement('button');
        markdownButton.type = 'button';
        markdownButton.textContent = '+ Markdown';
        markdownButton.addEventListener('click', () => {
            const inserted = insertNotebookCellAfter(insertionAnchor, 'markdown');
            insertionAnchor = inserted.sourceCell;
            const panel = createNewMarkdownCellPanel(inserted.sourceCell, markdownCells);
            container.after(panel);
            panel.querySelector('textarea')?.focus();
        });

        const codeButton = document.createElement('button');
        codeButton.type = 'button';
        codeButton.textContent = '+ Code';
        codeButton.addEventListener('click', () => {
            const inserted = insertNotebookCellAfter(insertionAnchor, 'code');
            insertionAnchor = inserted.sourceCell;
            const panel = createNewCodeCellPanel(inserted.sourceCell, notebookCodeCells);
            container.after(panel);
            panel.querySelector('textarea')?.focus();
        });

        insertControls.append(markdownButton, codeButton);
        container.appendChild(insertControls);
    }

    function insertNotebookCellAfter(anchorCell, cellType) {
        const state = window.cscsAuthorState;
        const cells = state?.notebook?.cells;
        if (!Array.isArray(cells)) throw new Error('Notebook source is not loaded.');
        const anchorIndex = Math.max(0, cells.indexOf(anchorCell));
        const sourceCell = createNotebookCell(cellType);
        cells.splice(anchorIndex + 1, 0, sourceCell);
        return { sourceCell, index: anchorIndex + 1 };
    }

    function createNotebookCell(cellType) {
        const id = `cscs_${Date.now().toString(36)}_${Math.random().toString(16).slice(2, 8)}`;
        if (cellType === 'code') {
            return {
                cell_type: 'code',
                execution_count: null,
                id,
                metadata: {},
                outputs: [],
                source: ['']
            };
        }
        return {
            cell_type: 'markdown',
            id,
            metadata: {},
            source: ['']
        };
    }

    function createNewMarkdownCellPanel(sourceCell, markdownCells) {
        const panel = document.createElement('div');
        panel.className = 'cscs-new-cell cscs-new-markdown-cell cscs-student-copy';
        const label = document.createElement('div');
        label.className = 'cscs-student-copy-label';
        label.textContent = 'Your version: new markdown cell';
        const editor = document.createElement('textarea');
        editor.className = 'cscs-markdown-editor';
        editor.placeholder = 'Write markdown here...';
        const removeButton = document.createElement('button');
        removeButton.type = 'button';
        removeButton.className = 'cscs-new-cell-remove';
        removeButton.textContent = 'Remove';
        removeButton.addEventListener('click', () => removeInsertedCell(sourceCell, panel, markdownCells));
        const actions = document.createElement('div');
        actions.className = 'cscs-new-cell-actions';
        const doneButton = document.createElement('button');
        doneButton.type = 'button';
        doneButton.textContent = 'Done';
        const previewButton = document.createElement('button');
        previewButton.type = 'button';
        previewButton.textContent = 'Preview';
        const saveButton = document.createElement('button');
        saveButton.type = 'button';
        saveButton.textContent = 'Save notebook';
        saveButton.addEventListener('click', () => window.cscsSaveNotebook?.());
        const preview = document.createElement('div');
        preview.className = 'cscs-markdown-preview cscs-new-cell-preview';
        preview.hidden = true;
        doneButton.addEventListener('click', () => {
            preview.innerHTML = renderMarkdownPreview(editor.value);
            preview.hidden = false;
            editor.hidden = true;
            doneButton.hidden = true;
            previewButton.textContent = 'Edit';
            panel.classList.add('is-done');
            label.textContent = 'New markdown cell';
        });
        previewButton.addEventListener('click', () => {
            if (editor.hidden) {
                editor.hidden = false;
                preview.hidden = true;
                doneButton.hidden = false;
                previewButton.textContent = 'Preview';
                panel.classList.remove('is-done');
                label.textContent = 'Your version: new markdown cell';
                editor.focus();
            } else {
                preview.innerHTML = renderMarkdownPreview(editor.value);
                preview.hidden = false;
            }
        });
        actions.append(doneButton, previewButton, saveButton, removeButton);
        panel.append(label, editor, preview, actions);
        markdownCells.push({ elements: [], editor, preview: null, sourceCell });
        return panel;
    }

    function createNewCodeCellPanel(sourceCell, notebookCodeCells) {
        const panel = document.createElement('div');
        panel.className = 'cscs-new-cell cscs-new-code-cell cscs-student-copy';
        const label = document.createElement('div');
        label.className = 'cscs-student-copy-label';
        label.textContent = 'Your version: new code cell';
        const editor = document.createElement('textarea');
        editor.className = 'cscs-code-editor';
        editor.placeholder = 'Write C# code here...';
        const removeButton = document.createElement('button');
        removeButton.type = 'button';
        removeButton.className = 'cscs-new-cell-remove';
        removeButton.textContent = 'Remove';
        removeButton.addEventListener('click', () => removeInsertedCell(sourceCell, panel, notebookCodeCells));
        const actions = document.createElement('div');
        actions.className = 'cscs-new-cell-actions';
        const runButton = document.createElement('button');
        runButton.type = 'button';
        runButton.textContent = 'Run';
        const doneButton = document.createElement('button');
        doneButton.type = 'button';
        doneButton.textContent = 'Done';
        const saveButton = document.createElement('button');
        saveButton.type = 'button';
        saveButton.textContent = 'Save notebook';
        saveButton.addEventListener('click', () => window.cscsSaveNotebook?.());
        const output = document.createElement('pre');
        output.className = 'cscs-execution-output';
        output.hidden = true;
        runButton.addEventListener('click', async () => runInsertedCodeCell(editor, output, runButton));
        doneButton.addEventListener('click', () => {
            editor.hidden = !editor.hidden;
            doneButton.textContent = editor.hidden ? 'Edit' : 'Done';
        });
        actions.append(runButton, doneButton, saveButton, removeButton);
        panel.append(label, editor, actions, output);
        notebookCodeCells.push({ element: null, sourceCell, editor });
        return panel;
    }

    async function runInsertedCodeCell(editor, output, runButton) {
        runButton.disabled = true;
        runButton.textContent = 'Running...';
        output.hidden = false;
        output.textContent = '';
        try {
            const passHeader = window.cscsPress ? await window.cscsPress.authHeader('run') : {};
            const response = await fetch(`${runnerBaseUrl}/v1/tasks/browser-inserted-cell/execute`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json', ...passHeader },
                body: JSON.stringify({ code: editor.value })
            });
            const result = await response.json().catch(() => ({}));
            if (!response.ok) throw new Error(result.error || `Run failed (${response.status})`);
            output.textContent = [result.output, result.error].filter(Boolean).join('\n') || '(no output)';
        } catch (error) {
            output.textContent = error.message || 'Run failed.';
        } finally {
            runButton.disabled = false;
            runButton.textContent = 'Run';
        }
    }

    function removeInsertedCell(sourceCell, panel, trackedCells) {
        const state = window.cscsAuthorState;
        const cells = state?.notebook?.cells;
        if (Array.isArray(cells)) {
            const index = cells.indexOf(sourceCell);
            if (index >= 0) cells.splice(index, 1);
        }
        const trackedIndex = trackedCells.findIndex(item => item.sourceCell === sourceCell);
        if (trackedIndex >= 0) trackedCells.splice(trackedIndex, 1);
        panel.remove();
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

    function isMarkdownInlineSafe(source, elements) {
        const text = source || '';
        if (/^\s*```/m.test(text)) return false;
        if (/^\s*:::/m.test(text)) return false;
        if (/^\s*```[{a-zA-Z]/m.test(text)) return false;
        if (/^\s*\|.+\|\s*$/m.test(text)) return false;
        if (/^\s*[-*+]\s+/m.test(text)) return false;
        if (/^\s*\d+\.\s+/m.test(text)) return false;
        if (/^\s*>/m.test(text)) return false;
        if (/<[a-z][\s\S]*>/i.test(text)) return false;
        const unsafeSelector = [
            'pre',
            'table',
            'thead',
            'tbody',
            'tr',
            'td',
            'th',
            'figure',
            'img',
            'svg',
            'iframe',
            'details',
            'dl',
            '.highlight',
            '.literal-block',
            '.admonition',
            '.cscs-code-cell',
            '.cell_input',
            '.cell_output',
            '.math',
            '.mermaid'
        ].join(',');
        return !elements.some(element => element.matches?.(unsafeSelector) || element.querySelector?.(unsafeSelector));
    }

    function markdownFromRenderedElements(elements) {
        return elements
            .map(element => markdownFromRenderedBlock(element).trim())
            .filter(Boolean)
            .join('\n\n') + '\n';
    }

    function markdownFromRenderedBlock(element) {
        const tagName = element.tagName?.toLowerCase();
        if (/^h[1-6]$/.test(tagName)) {
            const level = Number(tagName.slice(1));
            return `${'#'.repeat(level)} ${markdownFromInlineNodes(element).replace(/^#+\s*/, '').trim()}`;
        }
        if (tagName === 'ul' || tagName === 'ol') {
            return Array.from(element.children)
                .filter(child => child.tagName?.toLowerCase() === 'li')
                .map((child, index) => {
                    const marker = tagName === 'ol' ? `${index + 1}.` : '-';
                    return `${marker} ${markdownFromInlineNodes(child).trim()}`;
                })
                .join('\n');
        }
        if (tagName === 'pre') {
            const code = element.querySelector('code')?.textContent || element.textContent || '';
            return `\`\`\`\n${code.replace(/\n$/, '')}\n\`\`\``;
        }
        if (tagName === 'blockquote') {
            return markdownFromInlineNodes(element)
                .split('\n')
                .map(line => `> ${line}`)
                .join('\n');
        }
        return markdownFromInlineNodes(element).trim();
    }

    function markdownFromInlineNodes(parent) {
        return Array.from(parent.childNodes).map(node => markdownFromInlineNode(node)).join('').replace(/\u00a0/g, ' ');
    }

    function markdownFromInlineNode(node) {
        if (node.nodeType === Node.TEXT_NODE) return node.textContent || '';
        if (node.nodeType !== Node.ELEMENT_NODE) return '';
        const element = node;
        const tagName = element.tagName.toLowerCase();
        const text = markdownFromInlineNodes(element);
        if (tagName === 'br') return '\n';
        if (tagName === 'code') return `\`${element.textContent || ''}\``;
        if (tagName === 'strong' || tagName === 'b') return `**${text}**`;
        if (tagName === 'em' || tagName === 'i') return `*${text}*`;
        if (tagName === 'a') {
            if (element.classList.contains('headerlink') || element.classList.contains('toc-backref')) return '';
            const href = element.getAttribute('href');
            return href ? `[${text}](${href})` : text;
        }
        if (tagName === 'span') return text;
        return text;
    }

    function estimateMarkdownBlockCount(source) {
        const text = source || '';
        const paragraphBlocks = text
            .split(/\n\s*\n/)
            .map(block => block.trim())
            .filter(Boolean).length;
        const structuralLines = text
            .split('\n')
            .filter(line => /^\s*(#{1,6}\s+|[-*]\s+|\d+\.\s+|```|\|)/.test(line)).length;
        return Math.max(1, paragraphBlocks + structuralLines);
    }

    function serializeNotebookSource(text, previousSource) {
        if (!Array.isArray(previousSource)) return text;
        if (!text) return [];
        return text.match(/[^\n]*\n|[^\n]+/g) || [];
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
    // Signed-in readers' progress is kept in Press; everyone also keeps a local copy.
    const pressBackend = window.cscsPress?.backend ?? '';
    const progressUrl = `${pressBackend}/api/books/${bookId}/progress`;
    const signedIn = () => Boolean(window.thinkpressSession?.authenticated);
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
            path !== '/chapters/home' &&
            !path.endsWith('/index.html') &&
            !path.endsWith('/chapters/preface.html') &&
            !path.endsWith('/chapters/home.html') &&
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
        if (!progress?.pageUrl || !isTrackablePageUrl(progress.pageUrl) || !signedIn()) return;
        try {
            const response = await fetch(progressUrl, {
                method: 'POST',
                credentials: 'include',
                keepalive: true,
                headers: { 'Content-Type': 'application/json', 'X-CSRFToken': window.thinkpressSession.csrf_token || '' },
                body: JSON.stringify({
                    page_url: progress.pageUrl,
                    page_title: progress.pageTitle,
                    scroll_position: Math.round(progress.scrollY || 0)
                })
            });
            if (response.ok) {
                const remote = fromPress((await response.json()).progress);
                if (remote) writeLocalProgress(remote);
            }
        } catch (_) {
            // Anonymous readers and offline local builds keep browser-local progress.
        }
    }

    // Press stores progress as {page_url, page_title, scroll_position, updated_at}.
    function fromPress(progress) {
        if (!progress?.page_url) return null;
        return normalizeProgress({
            bookId,
            pageUrl: progress.page_url,
            pageTitle: progress.page_title,
            scrollY: progress.scroll_position,
            updatedUtc: progress.updated_at
        });
    }

    async function loadRemoteProgress() {
        if (!signedIn()) return;
        try {
            const response = await fetch(progressUrl, { credentials: 'include', cache: 'no-store' });
            if (!response.ok) return;
            const remote = fromPress((await response.json()).progress);
            if (!remote || !isTrackablePageUrl(remote.pageUrl)) return;
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
    // Press's account script reports the session after the page loads; fetch the reader's
    // saved progress then (and right away if it is already known).
    loadRemoteProgress();
    document.addEventListener('thinkpress:session', () => loadRemoteProgress(), { once: true });
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
