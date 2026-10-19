/* Opt-in section practice. Move whole rendered question sections, never clone
 * runnable cells: their identities, editors, outputs and listeners stay intact. */
(function () {
    "use strict";

    function initializeSectionPractice() {
        document.querySelectorAll("[data-section-practice]").forEach(marker => {
            if (marker.dataset.practiceReady === "true") return;
            const section = marker.closest("section");
            if (!section) return;
            const questions = Array.from(section.children).filter(child =>
                child.tagName === "SECTION" && child.querySelector(":scope > h3"));
            const labels = (marker.dataset.practiceLabels || "").split("|");
            if (!questions.length || labels.length !== questions.length) return;

            const scope = marker.dataset.sectionPractice;
            const prefix = `practice-${scope}`;
            const storagePrefix = `cscs:practice:v1:${location.pathname}:${scope}:`;
            let selected = 0;
            try {
                const saved = localStorage.getItem(storagePrefix + "selected");
                const found = questions.findIndex(question => question.id === saved);
                if (found >= 0) selected = found;
            } catch (_) { /* Practice remains usable without browser storage. */ }

            section.classList.add("section-practice");
            const tabs = document.createElement("div");
            tabs.className = "practice-tab-list";
            tabs.setAttribute("role", "tablist");
            tabs.setAttribute("aria-label", "Section practice questions");
            const panels = document.createElement("div");
            panels.className = "practice-panels";
            const buttons = questions.map((question, index) => {
                const button = document.createElement("button");
                button.type = "button";
                button.id = `${prefix}-tab-${index + 1}`;
                button.className = "practice-tab";
                button.textContent = `${index + 1}. ${labels[index]}`;
                button.setAttribute("role", "tab");
                button.setAttribute("aria-controls", question.id);
                question.setAttribute("role", "tabpanel");
                question.setAttribute("aria-labelledby", button.id);
                question.tabIndex = 0;
                tabs.appendChild(button);
                panels.appendChild(question);
                return button;
            });
            marker.replaceChildren(tabs, panels);

            function select(index, focus) {
                selected = (index + questions.length) % questions.length;
                questions.forEach((question, i) => {
                    const active = i === selected;
                    question.hidden = !active;
                    buttons[i].setAttribute("aria-selected", String(active));
                    buttons[i].tabIndex = active ? 0 : -1;
                });
                if (focus) buttons[selected].focus();
                try {
                    localStorage.setItem(storagePrefix + "selected", questions[selected].id);
                } catch (_) { /* No persistence is required to switch tabs. */ }
            }

            buttons.forEach((button, index) => {
                button.addEventListener("click", () => select(index, false));
                button.addEventListener("keydown", event => {
                    let next;
                    if (event.key === "ArrowRight") next = index + 1;
                    else if (event.key === "ArrowLeft") next = index - 1;
                    else if (event.key === "Home") next = 0;
                    else if (event.key === "End") next = questions.length - 1;
                    else return;
                    event.preventDefault();
                    select(next, true);
                });
            });

            function revealHashTarget() {
                if (!location.hash) return;
                let id;
                try { id = decodeURIComponent(location.hash.slice(1)); }
                catch (_) { return; }
                const target = document.getElementById(id);
                const index = questions.findIndex(question => question === target || question.contains(target));
                if (index >= 0) select(index, false);
            }
            window.addEventListener("hashchange", revealHashTarget);

            questions.forEach(question => {
                question.querySelectorAll("textarea[data-practice-draft]").forEach(input => {
                    const key = storagePrefix + input.dataset.practiceDraft;
                    try {
                        const saved = localStorage.getItem(key);
                        if (saved !== null) input.value = saved;
                    } catch (_) { /* The field still works as a local scratchpad. */ }
                    input.addEventListener("input", () => {
                        try { localStorage.setItem(key, input.value); }
                        catch (_) { /* Do not block typing if storage is full. */ }
                    });
                });
            });
            section.querySelectorAll("[data-practice-tests]").forEach(check => {
                const button = check.querySelector("button");
                const status = check.querySelector("[data-test-status]");
                const results = check.querySelector("[data-test-results]");
                const scores = [[59,"No pass"],[60,"Pass"],[89,"Pass"],[90,"Distinction"],[95,"Distinction"]];
                const delivery = [["E",25,"Service E: 8"],["E",50,"Service E: 8"],["S",49.99,"Service S: 3"],["S",50,"Service S: 0"],["P",25,"Service P: 0"],["X",50,"Unknown service"],["Z",50,"Unknown service"]];
                button.addEventListener("click", async () => {
                    const cell = Array.from(section.querySelectorAll("[data-cscs-cell-id]")).find(node => node.dataset.cscsCellId === check.dataset.practiceCell);
                    const runner = cell?.cscsPractice;
                    results.replaceChildren();
                    if (!runner) {
                        status.textContent = "Code runner unavailable. Reload the page, or use Run and compare with the table.";
                        return;
                    }
                    const source = runner.getCode();
                    const scorePattern = /^([ \t]*int[ \t]+score[ \t]*=[ \t]*)-?\d+([ \t]*;)/gm;
                    const servicePattern = /^([ \t]*string[ \t]+service[ \t]*=[ \t]*)"[^"\r\n]*"([ \t]*;)/gm;
                    const totalPattern = /^([ \t]*decimal[ \t]+orderTotal[ \t]*=[ \t]*)\d+(?:\.\d+)?m([ \t]*;)/gm;
                    const isScores = check.dataset.practiceTests === "scores";
                    const patterns = isScores ? [scorePattern] : [servicePattern,totalPattern];
                    if (patterns.some(pattern => [...source.matchAll(pattern)].length !== 1)) {
                        status.textContent = "Keep exactly one supplied input declaration for each input, using literal values (for example int score = 95; or string service = \"S\"; and decimal orderTotal = 50m;). Your code was not changed or run.";
                        return;
                    }
                    const cases = isScores ? scores : delivery;
                    let passed = 0;
                    button.disabled = true;
                    const controller = new AbortController();
                    const timer = setTimeout(() => controller.abort(), 180000);
                    try {
                        for (let i = 0; i < cases.length; i++) {
                            status.textContent = `Checking case ${i + 1} of ${cases.length}…`;
                            const values = cases[i];
                            const code = isScores ? source.replace(scorePattern, (_,a,b) => a + values[0] + b) :
                                source.replace(servicePattern, (_,a,b) => a + JSON.stringify(values[0]) + b)
                                    .replace(totalPattern, (_,a,b) => a + values[1] + "m" + b);
                            const result = await runner.execute(code, "", controller.signal);
                            const expected = values[values.length - 1];
                            const actual = (result.output || "").replace(/\r\n/g,"\n").trimEnd();
                            const ok = result.exitCode === 0 && !result.error && actual === expected;
                            if (ok) passed++;
                            const row = document.createElement("li");
                            row.textContent = `${ok ? "PASS" : "FAIL"}: ${isScores ? "score " + values[0] : values[0] + " / " + values[1]}: expected ${JSON.stringify(expected)}; actual ${JSON.stringify(actual)}.`;
                            if (result.error) row.textContent += " " + result.error;
                            if (result.exitCode !== 0) row.textContent += ` Execution did not succeed (exit ${result.exitCode ?? "unknown"}).`;
                            results.appendChild(row);
                            if (result.exitCode !== 0) {
                                status.textContent = `Execution stopped. ${passed} of ${cases.length} cases passed; remaining cases were not run. Fix the error and check again.`;
                                return;
                            }
                        }
                        status.textContent = `${passed} of ${cases.length} cases passed. These checks cover the listed cases; they do not prove correctness for every input.`;
                    } catch (error) {
                        status.textContent = `Check incomplete: ${error.name === "AbortError" ? "time limit reached" : error.message}. ${passed} cases passed before stopping. Try again when the runner is available.`;
                    } finally {
                        clearTimeout(timer);
                        button.disabled = false;
                    }
                });
            });

            marker.dataset.practiceReady = "true";
            section.querySelectorAll('[data-practice-check="zero-evidence"]').forEach(form => {
                form.addEventListener("submit", event => {
                    event.preventDefault();
                    const answer = form.querySelector('input[name="zero-evidence"]:checked');
                    form.querySelector("[data-practice-result]").textContent = !answer ?
                        "Choose an explanation before checking." : answer.value === "shared" ?
                        "Correct. P assigns zero; an unmatched X retains the initial zero. The amount alone does not identify the selected service." :
                        "Try again. Trace P and X in the faulty program: which assignment, if any, changes charge?";
                });
            });
            section.querySelectorAll('[data-practice-check="branch-predictions"]').forEach(form => {
                form.addEventListener("submit", event => {
                    event.preventDefault();
                    const a = form.querySelector('input[name="independent"]:checked');
                    const b = form.querySelector('input[name="chain"]:checked');
                    const result = form.querySelector("[data-practice-result]");
                    if (!a || !b) {
                        result.textContent = "Choose an output for both programs before checking.";
                        return;
                    }
                    const first = a.value === "both";
                    const second = b.value === "pass";
                    result.textContent = (first ? "Program A: correct. Both conditions run, printing Pass then Distinction. " :
                        "Program A: try again. Independent if statements each test their condition. ") +
                        (second ? "Program B: correct. The first branch prints Pass; the else if is skipped." :
                        "Program B: try again. A chain stops after its first matching branch.");
                });
            });
            select(selected, false);
            revealHashTarget();
        });
    }

    // Also exposed for progressive navigation and a duplicate-initialization check.
    window.initializeSectionPractice = initializeSectionPractice;
    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", initializeSectionPractice);
    } else {
        initializeSectionPractice();
    }
}());
