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
