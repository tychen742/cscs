function initializeCsharpExecution() {
    const apiBaseUrl = window.CSCS_EXECUTION_API || "http://localhost:8080";
    const taskId = createTaskId(window.location.pathname);

    const cells = Array.from(document.querySelectorAll("div.cell"));

    cells.forEach((cell, cellIndex) => {
        const codeElement = cell.querySelector(".cell_input pre");
        if (!codeElement || cell.dataset.cscsExecutionReady === "true") return;

        cell.dataset.cscsExecutionReady = "true";
        const editor = document.createElement("textarea");
        editor.className = "cscs-code-editor";
        editor.value = normalizeCode(codeElement.textContent);
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

        const resetButton = document.createElement("button");
        resetButton.type = "button";
        resetButton.className = "cscs-reset-button";
        resetButton.textContent = "Reset";
        resetButton.hidden = true;

        const runButton = document.createElement("button");
        runButton.type = "button";
        runButton.className = "cscs-run-button";
        runButton.textContent = "Run C#";

        const output = document.createElement("pre");
        output.className = "cscs-execution-output";
        output.hidden = true;
        output.setAttribute("aria-live", "polite");

        controls.append(editButton, resetButton, runButton);
        cell.appendChild(controls);
        cell.appendChild(output);

        editButton.addEventListener("click", () => {
            if (isStudentCopy) {
                const copy = controls.closest(".cscs-student-copy");
                editor.hidden = true;
                codeElement.closest(".cell_input").appendChild(editor);
                cell.append(controls, output);
                copy?.remove();
                resetButton.hidden = true;
                editButton.textContent = "Edit";
                isStudentCopy = false;
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
                editButton.textContent = "Done";
                resetButton.hidden = false;
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
            editButton.textContent = editing ? "Edit" : "Done";
            resetButton.hidden = !editing;
        });

        resetButton.addEventListener("click", () => {
            editor.value = normalizeCode(codeElement.textContent);
        });

        runButton.addEventListener("click", async () => {
            runButton.disabled = true;
            runButton.textContent = "Running...";
            output.hidden = false;
            output.className = "cscs-execution-output is-running";
            output.textContent = "";

            try {
                const currentCode = editor.value;
                const contextElements = cells
                    .slice(0, cellIndex)
                    .map((candidate) => candidate.querySelector(".cell_input pre"))
                    .filter(Boolean);
                const contextUsings = contextElements
                    .flatMap((element) => extractUsingDirectives(normalizeCode(element.textContent)));
                const contextDeclarations = isCompleteProgram(currentCode)
                    ? []
                    : contextElements
                        .map((element) => normalizeCode(element.textContent))
                        .filter(isReusableDeclaration);
                const response = await fetch(`${apiBaseUrl}/v1/tasks/${taskId}/execute`, {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        cells: [
                            [...contextUsings, ...contextDeclarations].join("\n\n"),
                            currentCode
                        ]
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
                runButton.textContent = "Run C#";
            }
        });
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

    function extractUsingDirectives(source) {
        return source
            .split("\n")
            .map((line) => line.trim())
            .filter((line) => /^using\s+.+;\s*$/.test(line));
    }

    function normalizeCode(source) {
        return source.replace(/^\s*%{1,2}csharp\s*\r?\n/i, "");
    }

    function isReusableDeclaration(source) {
        return /^\s*(?:(?:public|private|protected|internal|static|async|partial|sealed|abstract)\s+)*(?:class|struct|record|enum|interface)\b/m.test(source) ||
            /^\s*(?:(?:public|private|protected|internal|static|async)\s+)*(?:[\w<>,?\[\]]+\s+)+\w+\s*\([^;]*\)\s*(?:=>|\{)/m.test(source);
    }

    function isCompleteProgram(source) {
        return /\bnamespace\s+\w+/.test(source) ||
            /\bclass\s+Program\b/.test(source) ||
            /\bstatic\s+void\s+Main\s*\(/.test(source) ||
            /\bstatic\s+void\s+main\s*\(/.test(source) ||
            /^\s*(?:public|private|protected|internal)\s+(?:static\s+)?[\w<>,?\[\]]+\s+\w+\s*\(/m.test(source);
    }
}

if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", initializeCsharpExecution);
} else {
    initializeCsharpExecution();
}
