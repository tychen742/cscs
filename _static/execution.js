// The reader's cell state (code and last run per cell) lives in the book-agnostic store
// from cell_state.js, loaded before this file; see the record shape documented there.
// window.cscsCellState is this book's store and the sync hook for a later Press sync.
window.cscsCellState = window.cscsCellState
    || (window.thinkpressCellState ? window.thinkpressCellState.create({ book: "cscs" }) : null);
if (!window.cscsCellState) console.warn("cell_state.js did not load; this page will not remember runs.");

function initializeCsharpExecution() {
    // The C# runner (execution/runner). On the site, Apache routes /cscs-exec/v1/tasks/
    // to it on the same host; locally its gateway listens on port 8081.
    const local = ["localhost", "127.0.0.1"].includes(location.hostname);
    const runnerBaseUrl = localStorage.getItem("CSCS_RUNNER_API") ||
        window.CSCS_RUNNER_API ||
        (local ? "http://localhost:8081" : `${location.origin}/cscs-exec`);
    const taskId = createTaskId(window.location.pathname);
    // Reader state is keyed by the page path alone; see the record shape in cell_state.js.
    const pageUrl = window.location.pathname;
    const cellState = window.cscsCellState;
    const runnableCells = [];
    const pageHooks = { expectedChanged() {} };
    const press = createPressSync();

    async function executeCode(code, stdin = "", signal) {
        const passHeader = window.cscsPress ? await window.cscsPress.authHeader("run") : {};
        const response = await fetch(`${runnerBaseUrl}/v1/tasks/${taskId}/execute`, {
            method: "POST",
            headers: { "Content-Type": "application/json", ...passHeader },
            body: JSON.stringify({ code, stdin }), signal
        });
        const result = await response.json();
        if (!response.ok) throw new Error(result.error || "The execution request failed.");
        return result;
    }

    const cells = Array.from(document.querySelectorAll("div.cell"));

    cells.forEach((cell, cellIndex) => {
        const codeElement = cell.querySelector(".cell_input pre");
        if (!codeElement || cell.dataset.cscsExecutionReady === "true") return;
        // Notebook-only cells (e.g. Polyglot .Display() charts) cannot run in the console runner.
        if (cell.classList.contains("tag_no-run")) return;
        // Hidden answer cells show their saved output and revealable source,
        // rather than a second editable workspace for the exercise.
        if (cell.classList.contains("tag_hide-input")) return;

        const executableCode = normalizeCode(getExecutableCodeText(codeElement));
        if (isCsharpSetupOnly(executableCode)) return;

        cell.dataset.cscsExecutionReady = "true";
        const cellId = cell.dataset.cscsCellId
            || (cell.dataset.cscsCellIndex ? `index:${cell.dataset.cscsCellIndex}` : `pos:${cellIndex}`);
        // Press's key for this cell (progress and saved output): its place among the page's
        // runnable cells and a fingerprint of the book's code, as in Press's thebe-runner.js.
        const key = `cell:${runnableCells.length}:${fingerprint(executableCode)}`;
        const originalCodeHtml = codeElement.innerHTML;
        // The code to run. Readers edit the code in place (inline mode, kept in sync with this
        // textarea); the textarea itself is shown only by author mode's Edit (custom.js).
        const editor = document.createElement("textarea");
        editor.className = "cscs-code-editor";
        editor.value = executableCode;
        // Bounded section checks use the current editor without modifying its state.
        cell.cscsPractice = { getCode: () => currentCode(), execute: executeCode };
        editor.spellcheck = false;
        editor.hidden = true;
        codeElement.closest(".cell_input").appendChild(editor);
        const isExercise = /exercise-id\s*:/i.test(editor.value);
        let isStudentCopy = false;

        const controls = document.createElement("div");
        controls.className = "cscs-execution-controls thinkpress-cell-controls";

        // Author mode only: custom.js's Author and Done buttons click this hidden button to
        // open and close the textarea editor (a "Your version" copy, or in place for exercises).
        const editButton = document.createElement("button");
        editButton.type = "button";
        editButton.className = "cscs-edit-button";
        editButton.textContent = "Edit";
        editButton.hidden = true;

        const runButton = document.createElement("button");
        runButton.type = "button";
        runButton.className = "cscs-run-button";
        runButton.textContent = "Run";

        const resetButton = document.createElement("button");
        resetButton.type = "button";
        resetButton.className = "cscs-reset-button";
        resetButton.textContent = "Reset";
        resetButton.title = "Put back the book's code and forget your version";
        resetButton.hidden = true;

        // "✓ ran" once the reader ran this cell with its own Run button (not Run all).
        const ranMark = document.createElement("span");
        ranMark.className = "thinkpress-ran-mark";
        ranMark.textContent = "✓ ran";
        ranMark.hidden = true;

        const stdinPanel = document.createElement("div");
        stdinPanel.className = "cscs-stdin-panel";
        stdinPanel.hidden = true;

        const stdinHeading = document.createElement("div");
        stdinHeading.className = "cscs-stdin-heading";
        stdinHeading.textContent = "Input";

        const stdinHint = document.createElement("span");
        stdinHint.className = "cscs-stdin-hint";
        stdinHint.textContent = "Enter/Return to input";
        stdinHeading.appendChild(stdinHint);

        const stdinFields = document.createElement("div");
        stdinFields.className = "cscs-stdin-fields";
        stdinPanel.append(stdinHeading, stdinFields);

        const output = document.createElement("pre");
        output.className = "cscs-execution-output";
        output.hidden = true;
        output.setAttribute("aria-live", "polite");

        // Where trace_viewer.js renders the stepper for an output holding @@trace lines.
        const traceHost = document.createElement("div");
        traceHost.className = "cscs-trace-host";
        traceHost.hidden = true;

        // The notebook's saved output starts collapsed so
        // the reader runs the cell to see output; this disclosure reveals it on demand.
        const storedOutput = cell.querySelector(":scope > .cell_output");
        const expectedToggle = document.createElement("button");
        expectedToggle.type = "button";
        expectedToggle.className = "cscs-expected-toggle";
        expectedToggle.hidden = !storedOutput;

        controls.append(runButton, resetButton, expectedToggle, ranMark, editButton, stdinPanel);
        placeCellTail();
        let stdinRequested = false;
        let editMode = "view";
        let expectedShown = false;
        // When the reader last ran this cell on its own (an ISO string), from the stored
        // record or from Press; Run all keeps it.
        let ownRanAt = null;
        // Key of the stored record this cell currently shows, so store changes made elsewhere
        // (another tab, a Press sync) can be applied without re-applying our own writes.
        let lastApplied = null;
        let suppressChange = false;

        function placeCellTail() {
            cell.append(controls, output, traceHost);
            if (storedOutput) cell.appendChild(storedOutput);
        }

        const setExpectedShown = (shown) => {
            expectedShown = Boolean(shown) && Boolean(storedOutput);
            if (storedOutput) storedOutput.hidden = !expectedShown;
            expectedToggle.textContent = expectedShown ? "Hide saved output" : "Show saved output";
            expectedToggle.setAttribute("aria-expanded", String(expectedShown));
            pageHooks.expectedChanged();
        };
        setExpectedShown(false);
        expectedToggle.addEventListener("click", () => setExpectedShown(!expectedShown));
        // A student copy keeps its own live output; the original cell's saved output
        // stays as the reader left it. A run in place collapses it so the live result replaces it.
        const syncStoredOutput = () => {
            if (!isStudentCopy && !output.hidden) setExpectedShown(false);
        };

        const updateStdinVisibility = () => {
            if (!usesConsoleInput(editor.value)) {
                stdinRequested = false;
                stdinPanel.hidden = true;
            }
        };
        updateStdinVisibility();

        // Author mode's textarea editor. Closing it returns to editing in place.
        editButton.addEventListener("click", () => {
            if (isStudentCopy) {
                const copy = controls.closest(".cscs-student-copy");
                editor.hidden = true;
                codeElement.closest(".cell_input").appendChild(editor);
                placeCellTail();
                copy?.remove();
                isStudentCopy = false;
                syncStoredOutput();
                editInPlace();
                return;
            }
            if (editMode === "edit") {
                editor.hidden = true;
                codeElement.closest(".highlight-csharp").hidden = false;
                editInPlace();
                return;
            }
            syncEditorFromInline();
            const staticCodeHeight = codeElement.closest(".cell_input")?.offsetHeight || codeElement.offsetHeight;
            if (!isExercise) {
                const copy = document.createElement("div");
                copy.className = "cscs-student-copy";
                const copyLabel = document.createElement("div");
                copyLabel.className = "cscs-student-copy-label";
                copyLabel.textContent = "Your version";
                copy.appendChild(copyLabel);
                copy.append(editor, controls, output, traceHost);
                cell.after(copy);
                isStudentCopy = true;
                syncStoredOutput();
            } else {
                codeElement.closest(".highlight-csharp").hidden = true;
            }
            editor.hidden = false;
            editor.style.height = `${staticCodeHeight + 32}px`;
            setEditMode("edit");
        });

        // Reset: the book's code back in the cell, and the reader's version forgotten.
        resetButton.addEventListener("click", () => {
            editor.value = executableCode;
            if (editMode === "inline") showCodeInPlace(null);
            output.hidden = true;
            output.textContent = "";
            output.className = "cscs-execution-output";
            notifyOutput();
            forgetEditedCode();
            press.forgetOutput(key);
            stdinRequested = false;
            updateStdinVisibility();
            refreshEdited();
        });

        editor.addEventListener("input", () => {
            stdinRequested = false;
            updateStdinVisibility();
            refreshEdited();
        });

        codeElement.addEventListener("input", () => {
            if (editMode !== "inline") return;
            syncEditorFromInline();
            stdinRequested = false;
            updateStdinVisibility();
        });

        runButton.addEventListener("click", async () => {
            syncEditorFromInline();
            if (usesConsoleInput(editor.value) && !stdinRequested) {
                requestStdin();
                return;
            }
            await runCurrentCode();
        });

        function requestStdin() {
            stdinRequested = true;
            renderStdinFields(consoleInputPrompts(editor.value));
            stdinPanel.hidden = false;
            stdinFields.querySelector("input")?.focus();
        }

        // Resolves to "ok", "error", or "aborted" (Run all was stopped while this cell ran).
        // bulk marks a run started by Run all: it fills the output but is not the reader's own run.
        async function runCurrentCode({ signal, bulk = false } = {}) {
            runButton.disabled = true;
            setStdinFieldsDisabled(true);
            runButton.textContent = "Running...";
            output.hidden = false;
            output.className = "cscs-execution-output is-running";
            output.textContent = "";
            syncStoredOutput();

            const currentCode = editor.value;
            try {
                // A Press run pass gives signed-in readers priority and a longer timeout;
                // without one (signed out, or Press unreachable) the run is a guest run.
                const result = await executeCode(currentCode, collectStdin(), signal);

                const messages = [result.output, result.error].filter(Boolean);
                output.textContent = messages.join("\n");
                output.className = result.exitCode === 0
                    ? "cscs-execution-output is-success"
                    : "cscs-execution-output is-error";
                recordRun(currentCode, Number.isInteger(result.exitCode) ? result.exitCode : null, output.textContent, bulk);
                notifyOutput();
                return "ok";
            } catch (error) {
                if (error.name === "AbortError") {
                    output.hidden = true;
                    output.textContent = "";
                    output.className = "cscs-execution-output";
                    const previous = cellState?.get(pageUrl, cellId);
                    if (previous && hasOutput(previous)) showRecordedOutput(previous);
                    else notifyOutput();
                    return "aborted";
                }
                output.textContent = error.message;
                output.className = "cscs-execution-output is-error";
                recordRun(currentCode, null, output.textContent, bulk);
                notifyOutput();
                return "error";
            } finally {
                runButton.disabled = false;
                setStdinFieldsDisabled(false);
                runButton.textContent = "Run";
            }
        }

        // Run all skips a cell that reads input until the reader has entered it: running it
        // with empty input would only show a parsing error in place of the program's output.
        async function runForRunAll(signal) {
            syncEditorFromInline();
            if (usesConsoleInput(editor.value) && stdinPanel.hidden) {
                stdinRequested = true;
                renderStdinFields(consoleInputPrompts(editor.value));
                stdinPanel.hidden = false;
                output.hidden = false;
                output.className = "cscs-execution-output is-skipped";
                output.textContent = "Run all skipped this cell because it reads input. Enter the input above, then press Run.";
                notifyOutput();
                return "skipped";
            }
            return runCurrentCode({ signal, bulk: true });
        }

        function recordKey(record) {
            return `${record.ranAt}\u0000${record.code}\u0000${record.output}\u0000${record.ownRanAt}`;
        }

        // A record whose output was forgotten by Reset keeps only the "ran" state.
        function hasOutput(record) {
            return Boolean(record.output) || record.exitCode !== null;
        }

        function writeRecord(record) {
            if (!cellState) return;
            suppressChange = true;
            try {
                lastApplied = recordKey(cellState.set({ pageUrl, cellId, ...record }));
            } catch (_) {
                lastApplied = null;
            } finally {
                suppressChange = false;
            }
        }

        function recordRun(code, exitCode, text, bulk) {
            const ranAt = new Date().toISOString();
            if (!bulk) showRan(ranAt);
            writeRecord({ ranAt, exitCode, output: text, code, edited: !sameCode(code, executableCode), ownRanAt });
            press.reportRun({ key, code, text, exitCode, bulk });
        }

        // Reset forgets the reader's code and output but not that they ran the cell; a record
        // that only came from Run all is removed. ranAt moves to now so an older Press copy of
        // the edited run does not come back on the next visit; Reset also deletes the Press
        // copy (press.forgetOutput) so other devices do not restore it.
        function forgetEditedCode() {
            const record = cellState?.get(pageUrl, cellId);
            if (!record) return;
            if (record.ownRanAt) {
                writeRecord({ ranAt: new Date().toISOString(), exitCode: null, output: "", code: executableCode, edited: false, ownRanAt: record.ownRanAt });
                return;
            }
            lastApplied = null;
            suppressChange = true;
            try {
                cellState.remove(pageUrl, cellId);
            } finally {
                suppressChange = false;
            }
        }

        function showRan(at) {
            if (!at) return;
            if (!ownRanAt || Date.parse(at) > Date.parse(ownRanAt)) ownRanAt = at;
            ranMark.hidden = false;
            ranMark.title = `You ran this cell (last ${formatRanAt(ownRanAt)}).`;
            cell.classList.add("thinkpress-cell-ran");
        }

        // thinkpress-cell-edited and the Reset button follow whether the code is the book's.
        function refreshEdited() {
            const edited = !sameCode(editor.value, executableCode);
            cell.classList.toggle("thinkpress-cell-edited", edited);
            resetButton.hidden = !edited;
        }

        function showRecordedOutput(record) {
            output.hidden = false;
            output.textContent = record.output || "";
            output.className = record.exitCode === 0
                ? "cscs-execution-output is-success"
                : "cscs-execution-output is-error";
            notifyOutput();
        }

        // Tell trace_viewer.js (when loaded) that this cell's live output changed. The
        // event carries the full text; the viewer strips trace lines from the element.
        function notifyOutput() {
            cell.dispatchEvent(new CustomEvent("cscs:output", {
                bubbles: true,
                detail: { cell, cellId, output, host: traceHost, text: output.textContent }
            }));
        }

        function formatRanAt(ranAt) {
            const date = new Date(ranAt);
            return Number.isNaN(date.getTime()) ? "an earlier visit" : date.toLocaleString();
        }

        // Put a stored record on screen: the reader's code in the cell when they changed it,
        // their last output under the cell, and the "ran" mark when they ran it on its own.
        function applyRecord(record) {
            lastApplied = recordKey(record);
            const code = record.edited && !sameCode(record.code, executableCode) ? record.code : null;
            if (isStudentCopy || editMode === "edit") {
                if (code !== null) editor.value = code;
                fitEditorToContent();
            } else {
                editor.value = code ?? executableCode;
                showCodeInPlace(code);
            }
            refreshEdited();
            stdinRequested = false;
            updateStdinVisibility();
            if (hasOutput(record)) showRecordedOutput(record);
            showRan(record.ownRanAt);
        }

        // Size the editor from its line count: at page load the layout is not settled enough
        // for scrollHeight or the static code's height to be trusted.
        function fitEditorToContent() {
            if (editor.hidden) return;
            const style = getComputedStyle(editor);
            const lineHeight = parseFloat(style.lineHeight) || (parseFloat(style.fontSize) || 13) * 1.45;
            const padding = (parseFloat(style.paddingTop) || 0) + (parseFloat(style.paddingBottom) || 0);
            const lines = editor.value.split("\n").length + 1;
            editor.style.height = `${Math.ceil(lines * lineHeight + padding + 4)}px`;
        }

        // Back to the book (the record was removed elsewhere): the book's code and no output.
        function restoreBookState() {
            if (isStudentCopy || editMode === "edit") editButton.click();
            editor.value = executableCode;
            showCodeInPlace(null);
            output.hidden = true;
            output.textContent = "";
            output.className = "cscs-execution-output";
            notifyOutput();
            refreshEdited();
            setExpectedShown(false);
            stdinRequested = false;
            stdinPanel.hidden = true;
            updateStdinVisibility();
        }

        // Every runnable cell is edited in place from the start.
        editInPlace({ focus: false });

        const initialRecord = cellState?.get(pageUrl, cellId);
        if (initialRecord) applyRecord(initialRecord);

        cellState?.onChange((event) => {
            if (suppressChange || event.pageUrl !== pageUrl) return;
            if (event.cellId && event.cellId !== cellId) return;
            const record = cellState.get(pageUrl, cellId);
            if (record) {
                if (recordKey(record) !== lastApplied) applyRecord(record);
            } else if (lastApplied) {
                lastApplied = null;
                restoreBookState();
            }
        });

        runnableCells.push({
            cell,
            key,
            run: runForRunAll,
            hasExpected: Boolean(storedOutput),
            isExpectedShown: () => expectedShown,
            setExpectedShown,
            showRan,
            // A Press copy of the cell's last run, kept when it is newer than this browser's.
            applySavedOutput(saved, pressRanAt) {
                if (!cellState || !saved || typeof saved.code !== "string") return;
                const local = cellState.get(pageUrl, cellId);
                if (local && !(Date.parse(saved.ran_at) > Date.parse(local.ranAt))) return;
                const result = saved.output || {};
                cellState.set({
                    pageUrl,
                    cellId,
                    ranAt: saved.ran_at,
                    exitCode: Number.isInteger(result.exit_code) ? result.exit_code : null,
                    output: [result.output, result.error].filter(Boolean).join("\n"),
                    code: saved.code,
                    edited: !sameCode(saved.code, executableCode),
                    ownRanAt: local?.ownRanAt || pressRanAt || ownRanAt
                });
            }
        });

        function currentCode() {
            syncEditorFromInline();
            return editor.value;
        }

        function editInPlace({ focus = true } = {}) {
            const changed = !sameCode(editor.value, executableCode);
            setEditMode("inline");
            showCodeInPlace(changed ? editor.value : null, { focus });
            refreshEdited();
        }

        // Show code in the in-place editor: null for the book's (highlighted) code, else the
        // reader's code as plain text.
        function showCodeInPlace(code, { focus = false } = {}) {
            if (code === null) codeElement.innerHTML = originalCodeHtml;
            else codeElement.textContent = code;
            if (editMode === "inline") activateInlineCodeEditor({ focus });
        }

        function setEditMode(mode) {
            editMode = mode;
            const isEditing = mode !== "view";

            cell.classList.toggle("cscs-is-editing", isEditing);
            cell.dataset.cscsEditMode = mode;
            editor.dataset.inlineOpen = String(mode === "inline");
            editor.classList.toggle("is-inline", mode === "inline");

            if (mode !== "inline") {
                codeElement.contentEditable = "false";
                codeElement.classList.remove("cscs-inline-editing");
                codeElement.querySelectorAll(".cscs-code-line-content").forEach((line) => {
                    line.contentEditable = "false";
                });
            }
        }

        // Copy the in-place code into the editor. Code that matches the editor's apart from
        // trailing whitespace is left alone, so an unedited cell keeps the book's exact text.
        function syncEditorFromInline() {
            if (editMode !== "inline") return;
            const lineContents = Array.from(codeElement.querySelectorAll(".cscs-code-line-content"));
            const code = lineContents.length
                ? lineContents.map((line) => line.textContent || "").join("\n")
                : normalizeCode(getExecutableCodeText(codeElement));
            if (!sameCode(code, editor.value)) editor.value = code;
            refreshEdited();
        }

        function activateInlineCodeEditor({ focus = true } = {}) {
            if (!codeElement.querySelector(".cscs-code-line-content")) {
                structureCodeLines();
            }
            codeElement.contentEditable = "false";
            codeElement.classList.add("cscs-inline-editing");
            codeElement.querySelectorAll(".linenos").forEach((lineNumber) => {
                lineNumber.contentEditable = "false";
            });
            codeElement.querySelectorAll(".cscs-code-line-content").forEach((line) => {
                prepareInlineEditableContent(line);
            });
            if (focus) (codeElement.querySelector(".cscs-code-line-content") || codeElement).focus();
        }

        function structureCodeLines() {
            const rawLines = splitCodeElementLines(codeElement);
            const lineCountWidth = String(rawLines.length).length;
            const fragment = document.createDocumentFragment();

            rawLines.forEach((nodes, index) => {
                const line = document.createElement("span");
                line.className = "cscs-code-line";

                const lineNumber = document.createElement("span");
                lineNumber.className = "linenos";
                lineNumber.textContent = String(index + 1).padStart(lineCountWidth, " ");
                lineNumber.contentEditable = "false";

                const content = document.createElement("span");
                content.className = "cscs-code-line-content";
                prepareInlineEditableContent(content);
                nodes.forEach((node) => content.appendChild(node));
                if (!content.childNodes.length) content.appendChild(document.createTextNode(""));

                line.append(lineNumber, content);
                fragment.appendChild(line);
            });

            codeElement.replaceChildren(fragment);
        }

        codeElement.addEventListener("mousedown", (event) => {
            if (editMode !== "inline") return;
            const content = event.target.closest?.(".cscs-code-line-content")
                || event.target.closest?.(".cscs-code-line")?.querySelector(".cscs-code-line-content");
            if (!content) return;

            requestAnimationFrame(() => {
                if (document.activeElement !== content) {
                    setCaretOffset(content, Math.min(getCaretOffset(content), content.textContent.length));
                }
            });
        });

        function prepareInlineEditableContent(content) {
            content.contentEditable = "plaintext-only";
            if (content.contentEditable !== "plaintext-only") {
                content.contentEditable = "true";
            }
            content.spellcheck = false;
            content.setAttribute("role", "textbox");
            content.setAttribute("aria-multiline", "false");
            if (!content.dataset.cscsInlineReady) {
                content.addEventListener("keydown", handleInlineLineKeydown);
                content.dataset.cscsInlineReady = "true";
            }
        }

        function splitCodeElementLines(sourceElement) {
            const lines = [[]];
            const appendTextPart = (part) => {
                if (part) lines[lines.length - 1].push(document.createTextNode(part));
            };

            sourceElement.childNodes.forEach((node) => {
                if (node.nodeType === Node.ELEMENT_NODE && node.classList?.contains("linenos")) return;

                if (node.nodeType === Node.TEXT_NODE) {
                    const parts = node.textContent.split("\n");
                    parts.forEach((part, index) => {
                        if (index > 0) lines.push([]);
                        appendTextPart(part);
                    });
                    return;
                }

                lines[lines.length - 1].push(node.cloneNode(true));
            });

            // The final newline of the highlighted code would otherwise add an empty last line.
            if (lines.length > 1 && !lines[lines.length - 1].length) lines.pop();
            return lines;
        }

        function handleInlineLineKeydown(event) {
            event.stopPropagation();

            if (event.key === "Tab") {
                event.preventDefault();
                insertInlineTextAtCaret(event.currentTarget, "    ");
                syncEditorFromInline();
                return;
            }

            if (event.key === "ArrowUp" || event.key === "ArrowDown") {
                event.preventDefault();
                moveInlineCaretVertically(event.currentTarget, event.key === "ArrowUp" ? -1 : 1);
                return;
            }

            if (event.key === "ArrowLeft" && shouldMoveToPreviousLineEnd(event.currentTarget)) {
                event.preventDefault();
                moveInlineCaretHorizontally(event.currentTarget, -1);
                return;
            }

            if (event.key === "ArrowRight" && shouldMoveToNextLineStart(event.currentTarget)) {
                event.preventDefault();
                moveInlineCaretHorizontally(event.currentTarget, 1);
                return;
            }

            if (event.key === "Backspace" && shouldMergeWithPreviousLine(event.currentTarget)) {
                event.preventDefault();
                mergeInlineLineWithPrevious(event.currentTarget);
                syncEditorFromInline();
                return;
            }

            if (event.key === "Delete" && shouldMergeWithNextLine(event.currentTarget)) {
                event.preventDefault();
                mergeInlineLineWithNext(event.currentTarget);
                syncEditorFromInline();
                return;
            }

            if (event.key === "Enter" && event.shiftKey) {
                event.preventDefault();
                runButton.click();
                return;
            }

            if (event.key === "Enter") {
                event.preventDefault();
                splitInlineLineAtCaret(event.currentTarget);
                syncEditorFromInline();
            }
        }

        function splitInlineLineAtCaret(currentContent) {
            const currentLine = currentContent.closest(".cscs-code-line");
            if (!currentLine) return;

            const nextLine = document.createElement("span");
            nextLine.className = "cscs-code-line";

            const lineNumber = document.createElement("span");
            lineNumber.className = "linenos";
            lineNumber.contentEditable = "false";

            const content = document.createElement("span");
            content.className = "cscs-code-line-content";
            prepareInlineEditableContent(content);

            const selection = window.getSelection();
            if (selection && selection.rangeCount > 0) {
                const range = selection.getRangeAt(0);
                if (currentContent.contains(range.startContainer)) {
                    if (!range.collapsed) range.deleteContents();

                    const tailRange = document.createRange();
                    tailRange.selectNodeContents(currentContent);
                    tailRange.setStart(range.startContainer, range.startOffset);
                    const trailingContent = tailRange.extractContents();
                    content.appendChild(trailingContent);
                }
            }

            if (!currentContent.childNodes.length) currentContent.appendChild(document.createTextNode(""));
            if (!content.childNodes.length) content.appendChild(document.createTextNode(""));

            nextLine.append(lineNumber, content);
            currentLine.after(nextLine);
            renumberInlineLines();
            setCaretOffset(content, 0);
        }

        function insertInlineTextAtCaret(currentContent, text) {
            const range = getCurrentLineSelectionRange(currentContent);
            if (!range) return;

            if (!range.collapsed) range.deleteContents();

            const insertedNode = document.createTextNode(text);
            range.insertNode(insertedNode);
            placeCaret(insertedNode, text.length);
        }

        function shouldMoveToPreviousLineEnd(currentContent) {
            const range = getCurrentLineSelectionRange(currentContent);
            return Boolean(range?.collapsed && getCaretOffset(currentContent) === 0);
        }

        function shouldMoveToNextLineStart(currentContent) {
            const range = getCurrentLineSelectionRange(currentContent);
            return Boolean(range?.collapsed && getCaretOffset(currentContent) === currentContent.textContent.length);
        }

        function shouldMergeWithPreviousLine(currentContent) {
            const range = getCurrentLineSelectionRange(currentContent);
            return Boolean(range?.collapsed && getCaretOffset(currentContent) === 0);
        }

        function shouldMergeWithNextLine(currentContent) {
            const range = getCurrentLineSelectionRange(currentContent);
            return Boolean(range?.collapsed && getCaretOffset(currentContent) === currentContent.textContent.length);
        }

        function mergeInlineLineWithPrevious(currentContent) {
            const currentLine = currentContent.closest(".cscs-code-line");
            const previousLine = currentLine?.previousElementSibling;
            const previousContent = previousLine?.querySelector(".cscs-code-line-content");
            if (!currentLine || !previousContent) return;

            const targetOffset = previousContent.textContent.length;
            currentContent.childNodes.forEach((node) => previousContent.appendChild(node.cloneNode(true)));
            currentLine.remove();
            renumberInlineLines();
            setCaretOffset(previousContent, targetOffset);
        }

        function mergeInlineLineWithNext(currentContent) {
            const currentLine = currentContent.closest(".cscs-code-line");
            const nextLine = currentLine?.nextElementSibling;
            const nextContent = nextLine?.querySelector(".cscs-code-line-content");
            if (!nextLine || !nextContent) return;

            const targetOffset = currentContent.textContent.length;
            nextContent.childNodes.forEach((node) => currentContent.appendChild(node.cloneNode(true)));
            nextLine.remove();
            renumberInlineLines();
            setCaretOffset(currentContent, targetOffset);
        }

        function moveInlineCaretHorizontally(currentContent, direction) {
            const currentLine = currentContent.closest(".cscs-code-line");
            const targetLine = direction < 0
                ? currentLine?.previousElementSibling
                : currentLine?.nextElementSibling;
            const targetContent = targetLine?.querySelector(".cscs-code-line-content");
            if (!targetContent) return;

            const targetOffset = direction < 0 ? targetContent.textContent.length : 0;
            setCaretOffset(targetContent, targetOffset);
        }

        function getCurrentLineSelectionRange(currentContent) {
            const selection = window.getSelection();
            if (!selection || selection.rangeCount === 0) return null;

            const range = selection.getRangeAt(0);
            if (!currentContent.contains(range.startContainer) || !currentContent.contains(range.endContainer)) {
                return null;
            }
            return range;
        }

        function renumberInlineLines() {
            const lines = Array.from(codeElement.querySelectorAll(".cscs-code-line"));
            const lineCountWidth = String(lines.length).length;
            lines.forEach((line, index) => {
                const lineNumber = line.querySelector(".linenos");
                if (lineNumber) lineNumber.textContent = String(index + 1).padStart(lineCountWidth, " ");
            });
        }

        function moveInlineCaretVertically(currentContent, direction) {
            const currentLine = currentContent.closest(".cscs-code-line");
            const targetLine = direction < 0
                ? currentLine?.previousElementSibling
                : currentLine?.nextElementSibling;
            const targetContent = targetLine?.querySelector(".cscs-code-line-content");
            if (!targetContent) return;

            const column = getCaretOffset(currentContent);
            const targetColumn = Math.min(column, targetContent.textContent.length);
            setCaretOffset(targetContent, targetColumn);
        }

        function getCaretOffset(root) {
            const selection = window.getSelection();
            if (!selection || selection.rangeCount === 0) return 0;

            const range = selection.getRangeAt(0);
            const preRange = range.cloneRange();
            preRange.selectNodeContents(root);
            preRange.setEnd(range.endContainer, range.endOffset);
            return preRange.toString().length;
        }

        function setCaretOffset(root, offset) {
            root.focus();

            const walker = document.createTreeWalker(root, NodeFilter.SHOW_TEXT);
            let remaining = offset;
            let node = walker.nextNode();

            while (node) {
                if (remaining <= node.textContent.length) {
                    placeCaret(node, remaining);
                    return;
                }
                remaining -= node.textContent.length;
                node = walker.nextNode();
            }

            root.appendChild(document.createTextNode(""));
            placeCaret(root.lastChild, 0);
        }

        function placeCaret(node, offset) {
            const range = document.createRange();
            const selection = window.getSelection();
            range.setStart(node, offset);
            range.collapse(true);
            selection.removeAllRanges();
            selection.addRange(range);
        }

        // prompts: one entry per ReadLine, the text the program prints before it (or null).
        function renderStdinFields(prompts) {
            const count = prompts.length;
            const previousValues = Array.from(stdinFields.querySelectorAll("input")).map((input) => input.value);
            stdinFields.replaceChildren();

            for (let index = 0; index < count; index += 1) {
                const label = document.createElement("label");
                label.className = "cscs-stdin-label";
                label.textContent = prompts[index] || `Line ${index + 1}`;

                const input = document.createElement("input");
                input.type = "text";
                input.className = "cscs-stdin-input";
                input.spellcheck = false;
                input.autocomplete = "off";
                input.value = previousValues[index] || "";
                input.placeholder = `Input for ReadLine ${index + 1}`;
                input.addEventListener("keydown", async (event) => {
                    if (event.key !== "Enter") return;
                    event.preventDefault();
                    const nextInput = stdinFields.querySelectorAll("input")[index + 1];
                    if (nextInput) {
                        nextInput.focus();
                        return;
                    }
                    await runCurrentCode();
                });

                label.appendChild(input);
                stdinFields.appendChild(label);
            }
        }

        function collectStdin() {
            if (stdinPanel.hidden) return "";
            const lines = Array.from(stdinFields.querySelectorAll("input")).map((input) => input.value);
            return lines.length ? `${lines.join("\n")}\n` : "";
        }

        function setStdinFieldsDisabled(disabled) {
            stdinFields.querySelectorAll("input").forEach((input) => {
                input.disabled = disabled;
            });
        }
    });

    if (runnableCells.length) {
        installPageControls();
        press.start();
    }

    // "Run all", "Show all saved outputs", and (signed in, chapter pages) the progress line
    // at the top of the content area.
    function installPageControls() {
        const article = document.querySelector("article.bd-article")
            || document.querySelector("main")
            || document.body;
        const bar = document.createElement("div");
        bar.className = "cscs-page-controls thinkpress-page-controls";
        bar.setAttribute("role", "group");
        bar.setAttribute("aria-label", "Code cells on this page");

        const runAllButton = document.createElement("button");
        runAllButton.type = "button";
        runAllButton.className = "cscs-run-all-button";
        runAllButton.textContent = "Run all";

        const showAllButton = document.createElement("button");
        showAllButton.type = "button";
        showAllButton.className = "cscs-show-all-button";

        const status = document.createElement("span");
        status.className = "cscs-page-controls-status";
        status.setAttribute("aria-live", "polite");

        bar.append(runAllButton, showAllButton, status);
        press.progressHost = bar;
        const heading = article.querySelector("h1");
        if (heading && article.contains(heading)) {
            heading.after(bar);
        } else {
            article.prepend(bar);
        }

        const withExpected = () => runnableCells.filter((entry) => entry.hasExpected);
        const allExpectedShown = () => {
            const entries = withExpected();
            return entries.length > 0 && entries.every((entry) => entry.isExpectedShown());
        };
        const refreshShowAll = () => {
            const shown = allExpectedShown();
            showAllButton.hidden = withExpected().length === 0;
            showAllButton.textContent = shown ? "Hide all saved outputs" : "Show all saved outputs";
            showAllButton.setAttribute("aria-pressed", String(shown));
        };
        pageHooks.expectedChanged = refreshShowAll;
        refreshShowAll();
        showAllButton.addEventListener("click", () => {
            const shown = allExpectedShown();
            withExpected().forEach((entry) => entry.setExpectedShown(!shown));
        });

        // Run all: document order, two cells at a time; a second click stops it.
        let activeRun = null;
        runAllButton.addEventListener("click", async () => {
            if (activeRun) {
                activeRun.cancelled = true;
                activeRun.controller.abort();
                runAllButton.textContent = "Stopping...";
                runAllButton.disabled = true;
                return;
            }
            const run = { controller: new AbortController(), cancelled: false };
            activeRun = run;
            const total = runnableCells.length;
            const counts = { done: 0, ran: 0, skipped: 0, aborted: 0 };
            const ranKeys = [];
            let next = 0;
            const showProgress = () => {
                runAllButton.textContent = `Running ${counts.done}/${total}`;
            };
            runAllButton.setAttribute("aria-pressed", "true");
            runAllButton.title = "Click again to stop";
            status.textContent = "";
            showProgress();

            const worker = async () => {
                while (!run.cancelled && next < total) {
                    const entry = runnableCells[next];
                    next += 1;
                    let outcome = "error";
                    try {
                        outcome = await entry.run(run.controller.signal);
                    } catch (error) {
                        console.error(error);
                    }
                    counts.done += 1;
                    if (outcome === "skipped") counts.skipped += 1;
                    else if (outcome === "aborted") counts.aborted += 1;
                    else {
                        counts.ran += 1;
                        ranKeys.push(entry.key);
                    }
                    if (!run.cancelled) showProgress();
                }
            };
            await Promise.all([worker(), worker()]);
            press.finishRunAll(ranKeys);

            activeRun = null;
            runAllButton.disabled = false;
            runAllButton.textContent = "Run all";
            runAllButton.title = "";
            runAllButton.removeAttribute("aria-pressed");
            const parts = [];
            parts.push(run.cancelled
                ? `Stopped: ${counts.ran} of ${total} cells ran.`
                : `${counts.ran} of ${total} cells ran.`);
            if (counts.skipped) parts.push(`${counts.skipped} need input.`);
            status.textContent = parts.join(" ");
        });
    }

    // Press integration for signed-in readers (press/docs/UI.md, Code Cell Controls).
    // Chapter pages report their cells and each run to /api/cell-progress/cscs, which
    // restores the "ran" marks and the progress line; every page saves each cell's last
    // output to /api/cell-output/cscs, restored into the cell-state store on load. Run all
    // is reported as bulk: it saves outputs but does not count as running the cells. Reset
    // deletes the cell's saved output ({key, output: null}).
    // Signed-out readers keep the browser-only cell state.
    function createPressSync() {
        const page = location.pathname.replace(/^\/+/, "").replace(/\.html$/, "").toLowerCase().slice(0, 255);
        const validPage = /^[a-z0-9][a-z0-9/_.-]{0,254}$/.test(page);
        const chapterPage = /^chapters\/[^/]+\//.test(page) && !page.includes("/assignments/");
        const OUTPUT_BATCH = 60;
        const TEXT_MAX = 20000;
        const CODE_MAX = 50000;
        const ran = new Map();
        const pendingOutputs = [];
        let signedIn = false;
        let activeMs = 0;
        let line = null;

        const backend = () => window.cscsPress?.backend ?? "";

        async function post(path, body) {
            try {
                const response = await fetch(`${backend()}${path}`, {
                    method: "POST",
                    credentials: "include",
                    headers: { "Content-Type": "application/json", "X-CSRFToken": await window.cscsPress.csrfToken() },
                    body: JSON.stringify({ page, ...body })
                });
                if (!response.ok) console.warn(`Press did not accept ${path} (${response.status}).`);
            } catch (_) {
                // Press unreachable: the browser copy still has the run.
            }
        }

        async function getJson(path) {
            const response = await fetch(`${backend()}${path}?page=${encodeURIComponent(page)}`, {
                credentials: "include",
                cache: "no-store"
            });
            return response.ok ? response.json() : null;
        }

        function postOutputs(items) {
            for (let start = 0; start < items.length; start += OUTPUT_BATCH) {
                post("/api/cell-output/cscs", { outputs: items.slice(start, start + OUTPUT_BATCH) });
            }
        }

        function minutesText(ms) {
            const minutes = ms / 60000;
            return minutes < 10 ? `${minutes.toFixed(1)} min` : `${Math.round(minutes)} min`;
        }

        function renderProgress() {
            const host = sync.progressHost;
            if (!signedIn || !chapterPage || !host) return;
            if (!line) {
                line = document.createElement("span");
                line.className = "thinkpress-progress";
                line.setAttribute("aria-live", "polite");
                host.appendChild(line);
            }
            const total = runnableCells.length;
            const count = runnableCells.filter((entry) => ran.has(entry.key)).length;
            const percent = total ? Math.round((100 * count) / total) : 0;
            const time = activeMs >= 6000 ? ` \u00b7 ${minutesText(activeMs)} active on this page` : "";
            const link = document.createElement("a");
            link.href = `${backend()}/accounts/dashboard/progress/?return=${encodeURIComponent(location.href)}`;
            link.textContent = "My progress";
            line.replaceChildren(`Code cells run: ${count} of ${total} (${percent}%)${time} \u00b7 `, link);
        }

        async function connect() {
            if (signedIn || !validPage || !window.cscsPress) return;
            signedIn = true;
            if (chapterPage) {
                const title = document.title.split(" \u2014 ")[0].trim();
                post("/api/cell-progress/cscs", { title, cells: runnableCells.map((entry) => entry.key).slice(0, 400) });
                try {
                    const saved = await getJson("/api/cell-progress/cscs");
                    if (saved) {
                        activeMs = saved.active_ms || 0;
                        runnableCells.forEach((entry) => {
                            const at = saved.ran?.[entry.key];
                            if (!at) return;
                            ran.set(entry.key, at);
                            entry.showRan(at);
                        });
                    }
                } catch (_) {
                    // Progress unavailable: marks appear as the reader runs cells.
                }
                renderProgress();
            }
            try {
                const saved = await getJson("/api/cell-output/cscs");
                runnableCells.forEach((entry) => {
                    const output = saved?.outputs?.[entry.key];
                    if (output) entry.applySavedOutput(output, ran.get(entry.key));
                });
            } catch (_) {
                // Saved output unavailable: the browser copy stands.
            }
        }

        function disconnect() {
            signedIn = false;
            line?.remove();
            line = null;
        }

        const sync = {
            progressHost: null,
            start() {
                const onSession = (session) => {
                    if (session?.authenticated) connect();
                    else if (session) disconnect();
                };
                document.addEventListener("thinkpress:session", (event) => onSession(event.detail));
                if (window.thinkpressSession) onSession(window.thinkpressSession);
            },
            // After every run: its output, and for a cell's own run the progress report.
            reportRun({ key, code, text, exitCode, bulk }) {
                if (!signedIn || !validPage) return;
                if (code.length <= CODE_MAX) {
                    const item = { key, code, output: { output: text.slice(0, TEXT_MAX), exit_code: exitCode } };
                    if (bulk) pendingOutputs.push(item);
                    else postOutputs([item]);
                }
                if (bulk || !chapterPage) return;
                ran.set(key, new Date().toISOString());
                post("/api/cell-progress/cscs", { ran: [key] });
                renderProgress();
            },
            // After Reset: delete the saved run so another device does not restore its code.
            forgetOutput(key) {
                if (signedIn && validPage) postOutputs([{ key, output: null }]);
            },
            // After Run all: its outputs in batches, and its runs as bulk (not counted).
            finishRunAll(keys) {
                const items = pendingOutputs.splice(0);
                if (!signedIn) return;
                if (items.length) postOutputs(items);
                if (chapterPage && keys.length) post("/api/cell-progress/cscs", { ran: keys.slice(0, 400), bulk: true });
            }
        };
        return sync;
    }

    // FNV-1a, as in Press's thebe-runner.js: ties a cell's Press key to the book's code.
    function fingerprint(text) {
        let hash = 0x811c9dc5;
        for (let i = 0; i < text.length; i += 1) {
            hash ^= text.charCodeAt(i);
            hash = Math.imul(hash, 0x01000193) >>> 0;
        }
        return hash.toString(16).padStart(8, "0");
    }

    // Code is the same when it differs only in trailing whitespace (the in-place editor
    // drops the highlighted code's final newline).
    function sameCode(a, b) {
        return String(a).replace(/\s+$/, "") === String(b).replace(/\s+$/, "");
    }

    function createTaskId(pathname) {
        const slug = pathname
            .split("/")
            .filter(Boolean)
            .join("-")
            .replace(/[^a-zA-Z0-9_-]/g, "-")
            .replace(/-+/g, "-")
            .replace(/^-|-$/g, "")
            .toLowerCase();
        // The runner accepts at most 64 characters. Keep a stable suffix so
        // pages sharing a long prefix do not collapse to the same task ID.
        if (slug.length <= 64) return slug || "home";
        let hash = 0xcbf29ce484222325n;
        for (const character of pathname) {
            hash ^= BigInt(character.codePointAt(0));
            hash = BigInt.asUintN(64, hash * 0x100000001b3n);
        }
        return `${slug.slice(0, 47)}-${hash.toString(16).padStart(16, "0")}`;
    }

    function normalizeCode(source) {
        return source.replace(/^\s*%{1,2}csharp\s*\r?\n/i, "");
    }

    function getExecutableCodeText(codeElement) {
        const clone = codeElement.cloneNode(true);
        clone.querySelectorAll(".linenos").forEach((lineNumber) => lineNumber.remove());
        return clone.textContent || "";
    }

    function usesConsoleInput(source) {
        return countConsoleInputs(source) > 0;
    }

    function countConsoleInputs(source) {
        return stripCsharpComments(source).match(/\bConsole\s*\.\s*ReadLine\s*\(/g)?.length || 0;
    }

    // Input is collected before the program runs, so label each input with the prompt the
    // program prints just before that ReadLine: the last Console.Write/WriteLine string
    // literal since the previous ReadLine. Null when there is none (e.g. a computed prompt).
    function consoleInputPrompts(source) {
        const code = stripCsharpComments(source);
        const readLine = /\bConsole\s*\.\s*ReadLine\s*\(/g;
        const write = /\bConsole\s*\.\s*Write(?:Line)?\s*\(\s*\$?@?"((?:[^"\\\n]|\\.)*)"/g;
        const prompts = [];
        let previousEnd = 0;
        for (const match of code.matchAll(readLine)) {
            const writes = Array.from(code.slice(previousEnd, match.index).matchAll(write));
            const text = writes.length
                ? writes[writes.length - 1][1].replace(/\\(["\\])/g, "$1").replace(/\\[nrt]/g, " ").trim()
                : "";
            prompts.push(text || null);
            previousEnd = match.index + match[0].length;
        }
        return prompts;
    }

    function stripCsharpComments(source) {
        return source
            .replace(/\/\*[\s\S]*?\*\//g, "")
            .split("\n")
            .map((line) => line.replace(/\/\/.*$/, ""))
            .join("\n");
    }

    function isCsharpSetupOnly(source) {
        const lines = stripCsharpComments(source)
            .split("\n")
            .map((line) => line.trim())
            .filter(Boolean);

        return lines.length > 0 && lines.every((line) => {
            return /^using\s+(static\s+)?[\w.]+(\s*=\s*[\w.]+)?\s*;$/.test(line) ||
                /^#\w+/.test(line);
        });
    }

}

if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", initializeCsharpExecution);
} else {
    initializeCsharpExecution();
}
