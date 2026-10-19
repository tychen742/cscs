/* Run with CSCS_JSDOM_PATH pointing to a temporary jsdom installation. */
const assert = require("node:assert/strict");
const fs = require("node:fs");
const path = require("node:path");
const { JSDOM } = require(process.env.CSCS_JSDOM_PATH || "jsdom");
const root = path.resolve(__dirname, "..");
const html = fs.readFileSync(path.join(root, "_build/html/chapters/03_decision/0302_ifstatement.html"), "utf8");
const script = fs.readFileSync(path.join(root, "_static/section_practice.js"), "utf8");
const dom = new JSDOM(html, {url: "https://book.example/chapters/03_decision/0302_ifstatement.html", runScripts: "outside-only"});
const {window} = dom;
const {document} = window;
const oldCell = document.querySelector('[data-cscs-cell-id="core19_choice_starter"]');
assert(oldCell, "Original runnable exercise must be rendered");
const editor = document.createElement("textarea");
editor.className = "cscs-code-editor";
editor.value = "reader's unsaved code";
oldCell.appendChild(editor);
const run = document.createElement("button");
let calls = 0;
run.addEventListener("click", () => calls++);
oldCell.appendChild(run);
window.eval(script);
window.initializeSectionPractice();
const tabs = [...document.querySelectorAll('[role="tab"]')];
const panels = [...document.querySelectorAll('[role="tabpanel"]')];
assert.equal(tabs.length, 4);
assert.equal(panels.length, 4);
assert.equal(panels.filter(p => !p.hidden).length, 1);
function chosen(index) {
    assert.equal(tabs[index].getAttribute("aria-selected"), "true");
    assert.equal(panels[index].hidden, false);
    assert.equal(tabs.filter(t => t.tabIndex === 0).length, 1);
}
chosen(0);
tabs[2].click(); chosen(2);
assert.equal(document.querySelector('[data-cscs-cell-id="core19_choice_starter"]'), oldCell);
assert.equal(editor.value, "reader's unsaved code");
run.click(); assert.equal(calls, 1, "Moving a panel must preserve runner listeners");
tabs[2].dispatchEvent(new window.KeyboardEvent("keydown", {key:"ArrowRight", bubbles:true})); chosen(3);
tabs[3].dispatchEvent(new window.KeyboardEvent("keydown", {key:"ArrowRight", bubbles:true})); chosen(0);
tabs[0].dispatchEvent(new window.KeyboardEvent("keydown", {key:"End", bubbles:true})); chosen(3);
tabs[3].dispatchEvent(new window.KeyboardEvent("keydown", {key:"Home", bubbles:true})); chosen(0);
const draft = document.querySelector('[data-practice-draft="invalid-code"]');
draft.value = "Two independent tests can both run.";
draft.dispatchEvent(new window.Event("input", {bubbles:true}));
assert([...Array(window.localStorage.length)].some((_, i) => window.localStorage.getItem(window.localStorage.key(i)) === draft.value));
tabs[1].click();tabs[0].click();assert.equal(draft.value, "Two independent tests can both run.");
const form = document.querySelector('[data-practice-check="branch-predictions"]');
const submit = () => form.dispatchEvent(new window.Event("submit", {bubbles:true,cancelable:true}));
const feedback = form.querySelector('[data-practice-result]');
submit(); assert.match(feedback.textContent, /Choose an output for both/);
form.querySelector('[name="independent"][value="pass"]').checked = true;
form.querySelector('[name="chain"][value="both"]').checked = true;
submit(); assert.match(feedback.textContent, /Program A: try again/); assert.match(feedback.textContent, /Program B: try again/);
form.querySelector('[name="independent"][value="both"]').checked = true;
form.querySelector('[name="chain"][value="pass"]').checked = true;
submit(); assert.match(feedback.textContent, /Program A: correct/); assert.match(feedback.textContent, /Program B: correct/);
window.location.hash = panels[3].id;
window.dispatchEvent(new window.HashChangeEvent("hashchange"));chosen(3);
window.initializeSectionPractice();assert.equal(document.querySelectorAll('[role="tab"]').length,4);
for (let i=0;i<4;i++) {
 assert.equal(tabs[i].getAttribute("aria-controls"),panels[i].id);
 assert.equal(panels[i].getAttribute("aria-labelledby"),tabs[i].id);
}
// With JS unavailable the source HTML still contains all four readable sections.
const fallback = new JSDOM(html).window.document;
const marker = fallback.querySelector('[data-section-practice]');
assert.equal([...marker.closest("section").children].filter(n=>n.tagName==="SECTION").length,4);
assert.equal(fallback.querySelectorAll('[role="tabpanel"][hidden]').length,0);
// Loading the shared asset on a page without an opt-in marker is a no-op.
const plain = new JSDOM('<main><textarea>unchanged</textarea></main>', {url:"https://book.example/other",runScripts:"outside-only"});
plain.window.eval(script);plain.window.initializeSectionPractice();
assert.equal(plain.window.document.querySelector('main').innerHTML,'<textarea>unchanged</textarea>');
const result={prediction_checks:true,question_tabs:4,keyboard_navigation:true,one_active_panel:true,code_node_and_listener_preserved:true,draft_retained:true,hash_target_revealed:true,idempotent:true,no_script_fallback:true,no_opt_in_no_op:true,live_runner_api_tested:false};
fs.writeFileSync(path.join(root,'authoring/section_practice_pilot/dom_verification.json'),JSON.stringify(result,null,2)+'\n');
console.log(result);
window.close();plain.window.close();
