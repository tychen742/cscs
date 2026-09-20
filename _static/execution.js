function initializeCsharpExecution() {
    const apiBaseUrl = localStorage.getItem("CSCS_EXECUTION_API") ||
        window.CSCS_EXECUTION_API ||
        (location.hostname.endsWith("thinkcscs.org") ? "https://thinkcscs.org/cscs-exec" : "http://localhost:8080");
    const taskId = createTaskId(window.location.pathname);

    const cells = Array.from(document.querySelectorAll("div.cell"));

    cells.forEach((cell, cellIndex) => {
        const codeElement = cell.querySelector(".cell_input pre");
        if (!codeElement || cell.dataset.cscsExecutionReady === "true") return;

        const executableCode = normalizeCode(getExecutableCodeText(codeElement));
        if (isCsharpSetupOnly(executableCode)) return;

        cell.dataset.cscsExecutionReady = "true";
        const originalCodeHtml = codeElement.innerHTML;
        const editor = document.createElement("textarea");
        editor.className = "cscs-code-editor";
        editor.value = executableCode;
        editor.spellcheck = false;
        editor.hidden = true;
        codeElement.closest(".cell_input").appendChild(editor);
        const isExercise = /exercise-id\s*:/i.test(editor.value);
        let isStudentCopy = false;

        const controls = document.createElement("div");
        controls.className = "cscs-execution-controls";

        const editButton = document.createElement("button");
        editButton.type = "button";
        editButton.className = "cscs-edit-button";
        editButton.textContent = "Edit";

        const inlineButton = document.createElement("button");
        inlineButton.type = "button";
        inlineButton.className = "cscs-inline-button";
        inlineButton.textContent = "Inline";

        const resetButton = document.createElement("button");
        resetButton.type = "button";
        resetButton.className = "cscs-reset-button";
        resetButton.textContent = "Reset";
        resetButton.hidden = true;

        const runButton = document.createElement("button");
        runButton.type = "button";
        runButton.className = "cscs-run-button";
        runButton.textContent = "Run";

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

        controls.append(editButton, inlineButton, resetButton, runButton, stdinPanel);
        cell.appendChild(controls);
        cell.appendChild(output);
        let stdinRequested = false;
        let editMode = "view";

        const updateStdinVisibility = () => {
            if (!usesConsoleInput(editor.value)) {
                stdinRequested = false;
                stdinPanel.hidden = true;
            }
        };
        updateStdinVisibility();

        editButton.addEventListener("click", () => {
            if (isStudentCopy) {
                const copy = controls.closest(".cscs-student-copy");
                editor.hidden = true;
                codeElement.closest(".cell_input").appendChild(editor);
                cell.append(controls, output);
                copy?.remove();
                isStudentCopy = false;
                setEditMode("view");
                return;
            }
            if (!isExercise && editor.hidden) {
                const copy = document.createElement("div");
                copy.className = "cscs-student-copy";
                const copyLabel = document.createElement("div");
                copyLabel.className = "cscs-student-copy-label";
                copyLabel.textContent = "Your version";
                copy.appendChild(copyLabel);
                copy.append(editor, controls, output);
                cell.after(copy);
                editor.hidden = false;
                isStudentCopy = true;
                codeElement.closest(".highlight-csharp").hidden = false;
                setEditMode("edit");
                const staticCodeHeight = codeElement.closest(".cell_input")?.offsetHeight || codeElement.offsetHeight;
                editor.style.height = `${staticCodeHeight + 32}px`;
                return;
            }
            const editing = editor.hidden;
            if (editing) {
                const staticCodeHeight = codeElement.closest(".cell_input")?.offsetHeight || codeElement.offsetHeight;
                editor.style.height = `${staticCodeHeight + 32}px`;
            }
            editor.hidden = !editing;
            codeElement.closest(".highlight-csharp").hidden = editing;
            setEditMode(editing ? "edit" : "view");
        });

        inlineButton.addEventListener("click", () => {
            const opening = editMode !== "inline";

            if (opening) {
                editor.hidden = true;
                codeElement.closest(".highlight-csharp").hidden = false;
                setEditMode("inline");
                codeElement.contentEditable = "true";
                codeElement.classList.add("cscs-inline-editing");
                codeElement.querySelectorAll(".linenos").forEach((lineNumber) => {
                    lineNumber.contentEditable = "false";
                });
                codeElement.focus();
                return;
            }

            syncEditorFromInline();
            setEditMode("view");
        });

        resetButton.addEventListener("click", () => {
            editor.value = normalizeCode(getExecutableCodeText(codeElement));
            if (editMode === "inline") {
                codeElement.innerHTML = originalCodeHtml;
                codeElement.querySelectorAll(".linenos").forEach((lineNumber) => {
                    lineNumber.contentEditable = "false";
                });
            }
            editor.value = executableCode;
            stdinRequested = false;
            updateStdinVisibility();
        });

        editor.addEventListener("input", () => {
            stdinRequested = false;
            updateStdinVisibility();
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
            renderStdinFields(countConsoleInputs(editor.value));
            stdinPanel.hidden = false;
            stdinFields.querySelector("input")?.focus();
        }

        async function runCurrentCode() {
            runButton.disabled = true;
            setStdinFieldsDisabled(true);
            runButton.textContent = "Running...";
            output.hidden = false;
            output.className = "cscs-execution-output is-running";
            output.textContent = "";

            try {
                const currentCode = editor.value;
                const response = await fetch(`${apiBaseUrl}/v1/tasks/${taskId}/execute`, {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        code: currentCode,
                        stdin: collectStdin()
                    })
                });
                const result = await response.json();
                if (!response.ok) throw new Error(result.error || "The execution request failed.");

                const messages = [result.output, result.error].filter(Boolean);
                output.textContent = messages.join("\n");
                output.className = result.exitCode === 0
                    ? "cscs-execution-output is-success"
                    : "cscs-execution-output is-error";
            } catch (error) {
                output.textContent = error.message;
                output.className = "cscs-execution-output is-error";
            } finally {
                runButton.disabled = false;
                setStdinFieldsDisabled(false);
                runButton.textContent = "Run";
            }
        }

        function setEditMode(mode) {
            editMode = mode;
            const isEditing = mode !== "view";

            editButton.hidden = mode === "inline";
            inlineButton.hidden = mode === "edit";
            resetButton.hidden = !isEditing;

            editButton.textContent = mode === "edit" ? "Done" : "Edit";
            inlineButton.textContent = mode === "inline" ? "Done" : "Inline";
            editor.dataset.inlineOpen = String(mode === "inline");
            editor.classList.toggle("is-inline", mode === "inline");

            if (mode !== "inline") {
                codeElement.contentEditable = "false";
                codeElement.classList.remove("cscs-inline-editing");
            }
        }

        function syncEditorFromInline() {
            if (editMode !== "inline") return;
            editor.value = normalizeCode(getExecutableCodeText(codeElement));
        }

        function renderStdinFields(count) {
            const previousValues = Array.from(stdinFields.querySelectorAll("input")).map((input) => input.value);
            stdinFields.replaceChildren();

            for (let index = 0; index < count; index += 1) {
                const label = document.createElement("label");
                label.className = "cscs-stdin-label";
                label.textContent = count === 1 ? "Line 1" : `Line ${index + 1}`;

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

    function createTaskId(pathname) {
        const slug = pathname
            .split("/")
            .filter(Boolean)
            .join("-")
            .replace(/[^a-zA-Z0-9_-]/g, "-")
            .replace(/-+/g, "-")
            .replace(/^-|-$/g, "")
            .toLowerCase();
        return encodeURIComponent(slug || "home");
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
