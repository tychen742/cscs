/* Interactive figures: an SVG drawn in figures/ that also responds to clicks.
 *
 * A {figure} directive renders its SVG as an <img>, which cannot take clicks. Give the
 * directive `:class: interactive-figure` (the class lands on the <img>) and this script
 * fetches the SVG, inlines it in place of the <img>, and wires the behavior the SVG
 * declares for itself:
 *
 *   - an element with data-choice="k" becomes a button that toggles the reveal of k;
 *   - elements with data-answer="k" are hidden until k is revealed;
 *   - elements with data-placeholder="k" show only while k is hidden;
 *   - an element with data-hint shows until every choice has been revealed.
 *
 * The SVG's own <style> draws those states off the classes set here (is-interactive on
 * the root, is-chosen, is-shown, is-hidden, all-shown). Without this script, or when the
 * fetch fails, the figure stays the static image, with every answer visible.
 */
(function () {
    "use strict";

    function wire(svg) {
        var choices = Array.prototype.slice.call(svg.querySelectorAll("[data-choice]"));
        function refresh() {
            var allShown = choices.every(function (choice) {
                return choice.classList.contains("is-chosen");
            });
            svg.classList.toggle("all-shown", allShown);
        }
        choices.forEach(function (choice) {
            choice.setAttribute("role", "button");
            choice.setAttribute("tabindex", "0");
            choice.setAttribute("aria-pressed", "false");
            function toggle() {
                var key = choice.getAttribute("data-choice");
                var shown = !choice.classList.contains("is-chosen");
                choice.classList.toggle("is-chosen", shown);
                choice.setAttribute("aria-pressed", String(shown));
                svg.querySelectorAll('[data-answer="' + key + '"]').forEach(function (el) {
                    el.classList.toggle("is-shown", shown);
                });
                svg.querySelectorAll('[data-placeholder="' + key + '"]').forEach(function (el) {
                    el.classList.toggle("is-hidden", shown);
                });
                refresh();
            }
            choice.addEventListener("click", toggle);
            choice.addEventListener("keydown", function (event) {
                if (event.key === "Enter" || event.key === " ") {
                    event.preventDefault();
                    toggle();
                }
            });
        });
        refresh();
    }

    function enhance(img) {
        if (img.dataset.interactiveFigure === "ready") return;
        img.dataset.interactiveFigure = "ready";
        fetch(img.getAttribute("src"))
            .then(function (response) {
                if (!response.ok) throw new Error("fetch failed");
                return response.text();
            })
            .then(function (text) {
                var doc = new DOMParser().parseFromString(text, "image/svg+xml");
                var root = doc.documentElement;
                if (!root || root.nodeName !== "svg" || doc.querySelector("parsererror")) return;
                var svg = document.importNode(root, true);
                svg.classList.add("is-interactive");
                svg.setAttribute("role", "group");
                if (img.alt) svg.setAttribute("aria-label", img.alt);
                svg.style.width = img.style.width || "100%";
                svg.style.height = "auto";
                img.replaceWith(svg);
                wire(svg);
            })
            .catch(function () { /* keep the static image */ });
    }

    function init() {
        document.querySelectorAll('img.interactive-figure[src$=".svg"]').forEach(enhance);
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", init);
    } else {
        init();
    }
})();
