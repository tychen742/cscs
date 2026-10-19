/*
 * Trace viewer: an algorithm stepper driven by the reader's own run.
 *
 * A cell's C# calls Trace.Array(...) (execution/runner-template/Trace.cs), which prints one
 * record per step on its own line:
 *
 *     @@trace {"t":"array","v":[8,4,8,2],"hi":[1],"marks":{"sorted":[0]},"range":[0,4],"vars":{"saved":4},"msg":"..."}
 *
 * This script finds those lines in a cell's output, removes them from the printed text,
 * and renders the steps under the output as boxes with indexes, highlighted slots, mark
 * labels, the step's message and variables, Previous/Next buttons, a slider, a counter,
 * and arrow-key navigation. It serves two outputs:
 *
 *   - the live output of a run (pre.cscs-execution-output): execution.js dispatches a
 *     "cscs:output" event on the cell after a run completes, after a stored run is
 *     restored, and when the output is cleared; the event's detail names the output
 *     element and a host element placed right under it;
 *   - the notebook's saved output (div.cell_output pre), scanned once at load, so a
 *     reader who does not run the cell still gets the stepper.
 *
 * Record fields: t (kind, "array" only so far), v (values), hi (highlighted indexes),
 * marks (label -> indexes; an index equal to v.length means one past the end), range
 * ([low, high) half-open; slots outside are dimmed), vars (name -> value), msg (text).
 * Lines that do not parse are left in the output untouched.
 */
(function installTraceViewer() {
    if (window.cscsTraceViewer) return;

    const PREFIX = "@@trace ";
    const KINDS = { array: renderArrayStep };

    // Split output text into the visible text and the parsed step records.
    function extract(text) {
        const steps = [];
        const visible = [];
        let trailingNewline = text.endsWith("\n");
        text.split("\n").forEach((line, index, lines) => {
            if (index === lines.length - 1 && line === "" && trailingNewline) return;
            if (line.startsWith(PREFIX)) {
                try {
                    const record = JSON.parse(line.slice(PREFIX.length));
                    if (record && typeof record === "object" && KINDS[record.t]) {
                        steps.push(record);
                        return;
                    }
                } catch (_) {
                    // Not a record after all: keep the line as text.
                }
            }
            visible.push(line);
        });
        return { steps, visible: visible.join("\n") + (visible.length && trailingNewline ? "\n" : "") };
    }

    function hasTrace(text) {
        return typeof text === "string" && text.includes(PREFIX);
    }

    // Strip the records from an output element's text; returns the steps (possibly empty).
    // rawText is the full output when the caller has it (a live run); otherwise the
    // element's current text is used, so a saved output is read once at load.
    function takeSteps(outputElement, rawText) {
        const raw = typeof rawText === "string" ? rawText : (outputElement.textContent || "");
        if (!hasTrace(raw)) {
            outputElement.classList.remove("cscs-trace-empty");
            return [];
        }
        const { steps, visible } = extract(raw);
        if (!steps.length) return [];
        outputElement.textContent = visible;
        outputElement.classList.toggle("cscs-trace-empty", visible.trim() === "");
        return steps;
    }

    // ---- rendering -------------------------------------------------------------

    function element(tag, className, text) {
        const node = document.createElement(tag);
        if (className) node.className = className;
        if (text !== undefined) node.textContent = text;
        return node;
    }

    function createStepper(steps) {
        const root = element("div", "cscs-trace");
        root.tabIndex = 0;
        root.setAttribute("role", "group");
        root.setAttribute("aria-label", "Algorithm trace");

        const header = element("div", "cscs-trace-header");
        const title = element("span", "cscs-trace-title", "Step through this run");
        const counter = element("span", "cscs-trace-counter");
        counter.setAttribute("aria-live", "polite");
        header.append(title, counter);

        const picture = element("div", "cscs-trace-picture");
        const message = element("p", "cscs-trace-message");
        const vars = element("dl", "cscs-trace-vars");

        const controls = element("div", "cscs-trace-controls");
        const previous = element("button", "cscs-trace-previous", "Previous");
        previous.type = "button";
        const next = element("button", "cscs-trace-next", "Next");
        next.type = "button";
        const slider = document.createElement("input");
        slider.type = "range";
        slider.className = "cscs-trace-slider";
        slider.min = "0";
        slider.max = String(steps.length - 1);
        slider.step = "1";
        slider.setAttribute("aria-label", "Step");
        controls.append(previous, slider, next);

        root.append(header, picture, message, vars, controls);

        let current = 0;
        function show(index) {
            current = Math.max(0, Math.min(steps.length - 1, index));
            const step = steps[current];
            picture.replaceChildren(KINDS[step.t](step));
            message.textContent = step.msg || "";
            vars.replaceChildren();
            const names = step.vars && typeof step.vars === "object" ? Object.keys(step.vars) : [];
            names.forEach((name) => {
                const item = element("div", "cscs-trace-var");
                item.append(element("dt", "", name), element("dd", "", formatValue(step.vars[name])));
                vars.appendChild(item);
            });
            vars.hidden = names.length === 0;
            counter.textContent = `Step ${current + 1} of ${steps.length}`;
            slider.value = String(current);
            slider.setAttribute("aria-valuetext", `Step ${current + 1} of ${steps.length}`);
            previous.disabled = current === 0;
            next.disabled = current === steps.length - 1;
        }

        previous.addEventListener("click", () => { show(current - 1); root.focus({ preventScroll: true }); });
        next.addEventListener("click", () => { show(current + 1); root.focus({ preventScroll: true }); });
        slider.addEventListener("input", () => show(Number(slider.value)));
        root.addEventListener("keydown", (event) => {
            // The slider moves itself with the arrow keys; everything else in the box uses these.
            if (event.target === slider) return;
            const keys = { ArrowLeft: current - 1, ArrowRight: current + 1, Home: 0, End: steps.length - 1 };
            if (!(event.key in keys)) return;
            event.preventDefault();
            show(keys[event.key]);
        });

        show(0);
        return root;
    }

    function formatValue(value) {
        if (value === null || value === undefined) return "null";
        return typeof value === "string" ? value : JSON.stringify(value);
    }

    // The array picture: one grid holding the value boxes (row 1), their indexes (row 2),
    // and the mark labels below, each spanning the columns it covers. An extra column
    // past the last element carries marks placed at index v.length (a half-open bound).
    function renderArrayStep(step) {
        const values = Array.isArray(step.v) ? step.v : [];
        const length = values.length;
        const highlights = new Set(Array.isArray(step.hi) ? step.hi : []);
        const range = Array.isArray(step.range) && step.range.length === 2 ? step.range : null;
        const marks = step.marks && typeof step.marks === "object" ? step.marks : {};
        const usesEndColumn = Object.values(marks).some((indexes) => Array.isArray(indexes) && indexes.includes(length));
        const columns = length + (usesEndColumn || length === 0 ? 1 : 0);

        const grid = element("div", "cscs-trace-array");
        grid.style.setProperty("--cscs-trace-columns", String(columns));

        for (let index = 0; index < length; index += 1) {
            const slot = element("div", "cscs-trace-slot");
            slot.style.gridColumn = String(index + 1);
            if (highlights.has(index)) slot.classList.add("is-highlight");
            if (range && (index < range[0] || index >= range[1])) slot.classList.add("is-out");
            slot.append(element("span", "cscs-trace-value", formatValue(values[index])));
            grid.appendChild(slot);

            const label = element("div", "cscs-trace-index", String(index));
            label.style.gridColumn = String(index + 1);
            grid.appendChild(label);
        }
        if (length === 0) {
            const empty = element("div", "cscs-trace-slot is-end", "");
            empty.style.gridColumn = "1";
            empty.append(element("span", "cscs-trace-value", "empty"));
            grid.appendChild(empty);
            const label = element("div", "cscs-trace-index", "0");
            label.style.gridColumn = "1";
            grid.appendChild(label);
        } else if (usesEndColumn) {
            const end = element("div", "cscs-trace-slot is-end");
            end.style.gridColumn = String(length + 1);
            end.setAttribute("aria-hidden", "true");
            grid.appendChild(end);
            const label = element("div", "cscs-trace-index", String(length));
            label.style.gridColumn = String(length + 1);
            grid.appendChild(label);
        }

        // Marks: consecutive indexes with the same label form one bar.
        Object.keys(marks).forEach((label) => {
            const indexes = (Array.isArray(marks[label]) ? marks[label] : [])
                .filter((index) => Number.isInteger(index) && index >= 0 && index <= length)
                .sort((a, b) => a - b);
            let start = null;
            let previous = null;
            const flush = () => {
                if (start === null) return;
                const mark = element("div", `cscs-trace-mark cscs-trace-mark-${cssName(label)}`, label);
                mark.style.gridColumn = `${start + 1} / ${previous + 2}`;
                if (previous > start) mark.classList.add("is-span");
                grid.appendChild(mark);
            };
            indexes.forEach((index) => {
                if (start !== null && index === previous + 1) {
                    previous = index;
                    return;
                }
                flush();
                start = index;
                previous = index;
            });
            flush();
        });

        const wrapper = element("div", "cscs-trace-array-wrapper");
        wrapper.appendChild(grid);
        return wrapper;
    }

    function cssName(label) {
        return String(label).toLowerCase().replace(/[^a-z0-9]+/g, "-").replace(/^-|-$/g, "") || "mark";
    }

    // ---- attaching to outputs ------------------------------------------------------

    // Render (or remove) the stepper for an output element into the given host.
    function attach(outputElement, host, rawText) {
        const steps = takeSteps(outputElement, rawText);
        host.replaceChildren();
        if (!steps.length) {
            host.hidden = true;
            return null;
        }
        const stepper = createStepper(steps);
        host.appendChild(stepper);
        host.hidden = false;
        return stepper;
    }

    // Live output: execution.js tells us when a cell's output changed.
    document.addEventListener("cscs:output", (event) => {
        const detail = event.detail || {};
        if (!detail.output || !detail.host) return;
        if (detail.output.hidden) {
            detail.host.replaceChildren();
            detail.host.hidden = true;
            return;
        }
        attach(detail.output, detail.host, detail.text);
    });

    // Saved outputs: every stored stream output on the page.
    function attachSavedOutputs() {
        document.querySelectorAll("div.cell_output").forEach((cellOutput) => {
            if (cellOutput.dataset.cscsTraceReady === "true") return;
            cellOutput.dataset.cscsTraceReady = "true";
            const outputs = Array.from(cellOutput.querySelectorAll("pre")).filter((pre) => hasTrace(pre.textContent));
            if (!outputs.length) return;
            const host = element("div", "cscs-trace-host cscs-trace-host-saved");
            cellOutput.appendChild(host);
            attach(outputs[0], host);
        });
        // Live outputs rendered before this script's listener existed.
        document.querySelectorAll("pre.cscs-execution-output:not([hidden])").forEach((output) => {
            const host = output.nextElementSibling;
            if (host && host.classList.contains("cscs-trace-host") && !host.childElementCount) attach(output, host);
        });
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", attachSavedOutputs);
    } else {
        attachSavedOutputs();
    }

    window.cscsTraceViewer = { PREFIX, extract, attach, createStepper };
})();
