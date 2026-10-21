#!/usr/bin/env node
// ThinkPress lecture deck builder.
//
// One Marp Markdown source per section produces:
//   deck.html  for students (Marp, thinkpress-lecture theme)
//   deck.pptx  for instructors (native, editable PowerPoint with speaker notes)
//
// Usage: node build.mjs path/to/deck.md [--pptx-dir DIR] [--no-html] [--no-pptx]
//   --pptx-dir: where the instructor PowerPoint goes. Keep it outside _html_extra/
//   and the deployed build (it holds quick-check answers); the books use
//   assignments/slides/.
//
// Source conventions (see LECTURE_SLIDES.md):
//   - Front matter: marp, theme: thinkpress-lecture, title, book, section, primary, accent
//   - Slides separated by a line containing only ---
//   - Slide type: <!-- _class: title | section | check | yourturn | recap -->
//   - Any other HTML comment on a slide is its speaker notes (required)
//   - Two columns: <div class="cols"> <div class="col"> ... </div> <div class="col"> ... </div> </div>
//   - A fenced block with language `output` is shown as program output

import fs from "node:fs";
import path from "node:path";
import { execFileSync } from "node:child_process";
import { createRequire } from "node:module";
import { fileURLToPath } from "node:url";

const require = createRequire(import.meta.url);
const pptxgen = require("pptxgenjs");
const MarkdownIt = require("markdown-it");
const yaml = require("js-yaml");
const sharp = require("sharp");

const HERE = path.dirname(fileURLToPath(import.meta.url));
const md = new MarkdownIt({ html: true });

// ---------- Layout constants (inches, LAYOUT_WIDE = 13.333 x 7.5) ----------
const SW = 13.333, SH = 7.5;
const MX = 0.6, TITLE_Y = 0.35, TITLE_H = 0.85, BODY_Y = 1.4, BODY_BOTTOM = 6.75;
const BODY_W = SW - 2 * MX;
const SIZE = { title: 36, body: 24, h3: 24, code: 18, table: 18, minBody: 24, minCode: 18 };
let linkBase = "https://cscs.thinkpress.org/";
const FONT = { head: "Cambria", body: "Calibri", code: "Consolas" };
const COLOR = { text: "1F2328", muted: "59636E", codeBg: "F6F8FA", border: "C9D1D9", white: "FFFFFF", light: "DFEEE2" };

// ---------- Source parsing ----------
function splitFrontMatter(src) {
  const m = src.match(/^---\r?\n([\s\S]*?)\r?\n---\r?\n/);
  if (!m) return { meta: {}, body: src };
  return { meta: yaml.load(m[1]) || {}, body: src.slice(m[0].length) };
}

function splitSlides(body) {
  const slides = [];
  let cur = [], inFence = false;
  for (const line of body.split(/\r?\n/)) {
    if (/^\s*(```|~~~)/.test(line)) inFence = !inFence;
    if (!inFence && /^---\s*$/.test(line)) { slides.push(cur.join("\n")); cur = []; continue; }
    cur.push(line);
  }
  slides.push(cur.join("\n"));
  return slides.filter((s) => s.trim());
}

function parseSlide(text) {
  let cls = "";
  const notes = [];
  const body = text.replace(/<!--([\s\S]*?)-->/g, (_, inner) => {
    const d = inner.trim().match(/^_?(class|paginate|header|footer|backgroundColor|color)\s*:\s*(.*)$/s);
    if (d) { if (d[1] === "class") cls = d[2].trim(); }
    else notes.push(inner.trim());
    return "";
  });
  let cols = null, pre = body;
  const colsMatch = body.match(/<div class="cols">([\s\S]*)<\/div>\s*$/);
  if (colsMatch) {
    pre = body.slice(0, colsMatch.index);
    cols = [...colsMatch[1].matchAll(/<div class="col">([\s\S]*?)<\/div>/g)].map((m) => parseBlocks(m[1]));
  }
  return { cls, notes: notes.join("\n\n"), blocks: parseBlocks(pre), cols };
}

function inlineRuns(token) {
  const runs = [];
  const st = { bold: false, italic: false, href: null };
  for (const t of token.children || []) {
    if (t.type === "link_open") st.href = t.attrGet("href");
    else if (t.type === "link_close") st.href = null;
    else if (t.type === "strong_open") st.bold = true;
    else if (t.type === "strong_close") st.bold = false;
    else if (t.type === "em_open") st.italic = true;
    else if (t.type === "em_close") st.italic = false;
    else if (t.type === "text") runs.push({ text: t.content, ...st });
    else if (t.type === "code_inline") runs.push({ text: t.content, code: true, ...st });
    else if (t.type === "softbreak" || t.type === "hardbreak") runs.push({ text: " ", ...st });
  }
  return runs;
}

function parseBlocks(src) {
  const tokens = md.parse(src, {});
  const blocks = [];
  const listStack = [];
  let table = null, row = null, inQuote = false;
  for (let i = 0; i < tokens.length; i++) {
    const t = tokens[i];
    if (t.type === "heading_open") {
      blocks.push({ type: "heading", level: Number(t.tag.slice(1)), runs: inlineRuns(tokens[i + 1]) }); i += 2;
    } else if (t.type === "bullet_list_open" || t.type === "ordered_list_open") {
      if (!listStack.length) blocks.push({ type: "list", ordered: t.type === "ordered_list_open", items: [] });
      listStack.push(t.type);
    } else if (t.type === "bullet_list_close" || t.type === "ordered_list_close") {
      listStack.pop();
    } else if (t.type === "blockquote_open") { inQuote = true; blocks.push({ type: "quote", runs: [] }); }
    else if (t.type === "blockquote_close") inQuote = false;
    else if (t.type === "fence") blocks.push({ type: "code", lang: t.info.trim(), text: t.content.replace(/\n$/, "") });
    else if (t.type === "table_open") table = { type: "table", rows: [] };
    else if (t.type === "tr_open") row = [];
    else if (t.type === "tr_close") table.rows.push(row);
    else if (t.type === "table_close") { blocks.push(table); table = null; }
    else if (t.type === "inline") {
      const img = (t.children || []).find((c) => c.type === "image");
      if (table) row.push(inlineRuns(t));
      else if (img && !listStack.length) blocks.push({ type: "image", src: img.attrGet("src"), alt: img.content });
      else if (listStack.length) {
        const list = blocks.findLast((b) => b.type === "list");
        list.items.push({ runs: inlineRuns(t), level: listStack.length - 1 });
      } else if (inQuote) {
        const q = blocks[blocks.length - 1];
        if (q.runs.length) q.runs.push({ text: " " });
        q.runs.push(...inlineRuns(t));
      } else blocks.push({ type: "para", runs: inlineRuns(t) });
    }
  }
  return blocks;
}

// ---------- Text helpers ----------
const plain = (runs) => runs.map((r) => r.text).join("");
const hex = (c, fallback) => String(c || fallback).replace("#", "").toUpperCase();

function toPptRuns(runs, opts, P) {
  return runs.map((r) => ({
    text: r.text,
    options: {
      ...opts,
      bold: r.bold || opts.bold || false,
      italic: r.italic || false,
      ...(r.href ? { hyperlink: { url: new URL(r.href, linkBase).href }, underline: false } : {}),
      ...(r.code ? { fontFace: FONT.code, color: opts.color === COLOR.white ? "FFE9A8" : P.accentDark } : {}),
      ...(r.bold && !r.code && !opts.color ? { color: P.primary } : {}),
    },
  }));
}

// Approximate wrapped line count for a run of text at a font size in a width.
function lineCount(text, sizePt, widthIn, mono = false) {
  const charW = (sizePt / 72) * (mono ? 0.6 : 0.5);
  const perLine = Math.max(1, Math.floor(widthIn / charW));
  return text.split("\n").reduce((n, l) => n + Math.max(1, Math.ceil(l.length / perLine)), 0);
}

// ---------- Block rendering ----------
function textBlocksHeight(blocks, size, w) {
  let h = 0;
  for (const b of blocks) {
    const lh = (size / 72) * 1.25;
    if (b.type === "list") for (const it of b.items) h += lineCount(plain(it.runs), size, w - 0.4 - it.level * 0.4) * lh + 0.08;
    else if (b.type === "heading") h += lh + 0.1;
    else h += lineCount(plain(b.runs), size, w - (b.type === "quote" ? 0.5 : 0)) * lh + 0.15;
  }
  return h;
}

function codeHeight(b, size) {
  return b.text.split("\n").length * (size / 72) * 1.25 + 0.3;
}

function addTextGroup(slide, blocks, x, y, w, size, P, dark) {
  const paras = [];
  const base = { fontFace: FONT.body, fontSize: size, color: dark ? COLOR.white : COLOR.text };
  for (const b of blocks) {
    if (b.type === "heading") {
      paras.push(...toPptRuns(b.runs, { ...base, bold: true, color: dark ? COLOR.white : P.accent }, P));
      paras[paras.length - 1].options.breakLine = true;
      paras[paras.length - 1].options.paraSpaceAfter = 4;
    } else if (b.type === "list") {
      b.items.forEach((it, idx) => {
        const runs = toPptRuns(it.runs, base, P);
        runs[0].options.bullet = b.ordered ? { type: "number" } : { indent: 20 };
        runs[0].options.indentLevel = it.level;
        runs[runs.length - 1].options.breakLine = true;
        runs[runs.length - 1].options.paraSpaceAfter = 8;
        paras.push(...runs);
      });
    } else if (b.type === "para" || b.type === "quote") {
      const runs = toPptRuns(b.runs, base, P);
      runs[runs.length - 1].options.breakLine = true;
      runs[runs.length - 1].options.paraSpaceAfter = 10;
      paras.push(...runs);
    }
  }
  if (!paras.length) return;
  paras[paras.length - 1].options.breakLine = false;
  const h = textBlocksHeight(blocks, size, w) + 0.1;
  slide.addText(paras, { x, y, w, h, valign: "top", margin: 0, isTextBox: true, fit: "none" });
  return h;
}

function addQuote(slide, b, x, y, w, size, P) {
  const h = textBlocksHeight([b], size, w) + 0.25;
  slide.addText(toPptRuns(b.runs, { fontFace: FONT.body, fontSize: size, color: COLOR.text }, P), {
    shape: "roundRect", rectRadius: 0.12, x, y, w, h, fill: { color: P.tint }, margin: [8, 14, 8, 14], valign: "middle", isTextBox: true,
  });
  return h;
}

function addCode(slide, b, x, y, w, size) {
  const h = codeHeight(b, size);
  const output = b.lang === "output";
  slide.addText(b.text, {
    x, y, w, h, fontFace: FONT.code, fontSize: size, color: COLOR.text, valign: "top", margin: [8, 12, 8, 12],
    fill: { color: output ? COLOR.white : COLOR.codeBg },
    line: output ? { color: COLOR.border, width: 1.5, dashType: "dash" } : { color: "E1E4E8", width: 0.75 },
    isTextBox: true, fit: "none",
  });
  return h;
}

function addTable(slide, b, x, y, w, P) {
  const rows = b.rows.map((r, ri) => r.map((cell) => ({
    text: plain(cell),
    options: ri === 0
      ? { bold: true, color: COLOR.white, fill: { color: P.primary }, fontFace: FONT.body, fontSize: SIZE.table }
      : { color: COLOR.text, fontFace: FONT.body, fontSize: SIZE.table, fill: { color: ri % 2 ? COLOR.white : "F6F8FA" } },
  })));
  const h = rows.length * 0.45;
  slide.addTable(rows, { x, y, w, rowH: 0.45, border: { type: "solid", color: "D0D7DE", pt: 0.75 }, margin: 0.06 });
  return h;
}

async function addImage(slide, b, x, y, w, maxH, deckDir) {
  const file = path.resolve(deckDir, b.src);
  let buf = fs.readFileSync(file);
  if (file.endsWith(".svg")) buf = await sharp(buf, { density: 300 }).png().toBuffer();
  const meta = await sharp(buf).metadata();
  const ratio = meta.height / meta.width;
  let iw = w, ih = w * ratio;
  if (ih > maxH) { ih = maxH; iw = ih / ratio; }
  slide.addImage({ data: "image/png;base64," + buf.toString("base64"), x: x + (w - iw) / 2, y, w: iw, h: ih, altText: b.alt || "" });
  return ih;
}

// Lay out a column of blocks; shrink fonts until it fits.
async function layoutColumn(slide, blocks, x, y, w, maxY, P, deckDir, dark = false, warn) {
  let body = SIZE.body, code = SIZE.code;
  const estimate = () => {
    let h = 0, group = [];
    const flush = () => { if (group.length) { h += textBlocksHeight(group, body, w) + 0.2; group = []; } };
    for (const b of blocks) {
      if (["para", "list", "heading"].includes(b.type)) group.push(b);
      else { flush(); h += b.type === "code" ? codeHeight(b, code) + 0.2 : b.type === "table" ? b.rows.length * 0.45 + 0.2 : b.type === "quote" ? textBlocksHeight([b], body, w) + 0.45 : 2.5; }
    }
    flush();
    return h;
  };
  while (estimate() > maxY - y && (body > SIZE.minBody || code > SIZE.minCode)) {
    if (body > SIZE.minBody) body -= 2;
    if (code > SIZE.minCode) code -= 1;
  }
  if (estimate() > maxY - y) warn("content may overflow; split this slide");
  let cy = y, group = [];
  const flush = () => { if (group.length) { cy += addTextGroup(slide, group, x, cy, w, body, P, dark) + 0.2; group = []; } };
  for (const b of blocks) {
    if (["para", "list", "heading"].includes(b.type)) { group.push(b); continue; }
    flush();
    if (b.type === "code") cy += addCode(slide, b, x, cy, w, code) + 0.2;
    else if (b.type === "table") cy += addTable(slide, b, x, cy, w, P) + 0.2;
    else if (b.type === "quote") cy += addQuote(slide, b, x, cy, w, body, P) + 0.2;
    else if (b.type === "image") cy += (await addImage(slide, b, x, cy, w, maxY - cy, deckDir)) + 0.2;
  }
  flush();
}

// ---------- Slide types ----------
function takeTitle(blocks) {
  const i = blocks.findIndex((b) => b.type === "heading" && b.level <= 2);
  if (i < 0) return { title: "", rest: blocks };
  return { title: plain(blocks[i].runs), rest: blocks.filter((_, j) => j !== i) };
}

async function renderSlide(pres, s, n, meta, P, deckDir, warn) {
  const dark = ["title", "section", "recap"].includes(s.cls);
  const slide = pres.addSlide({ masterName: dark ? "TP_DARK" : "TP_CONTENT" });
  const { title, rest } = takeTitle(s.blocks);

  if (s.cls === "title" || s.cls === "section") {
    slide.addText(title, { x: MX, y: 2.2, w: BODY_W, h: 1.4, fontFace: FONT.head, fontSize: s.cls === "title" ? 48 : 44, bold: true, color: COLOR.white, valign: "bottom", margin: 0, isTextBox: true });
    const sub = rest.filter((b) => b.type === "para").map((b) => plain(b.runs)).join("\n");
    if (sub) slide.addText(sub, { x: MX, y: 3.75, w: BODY_W, h: 1.6, fontFace: FONT.body, fontSize: 24, color: COLOR.light, valign: "top", margin: 0, isTextBox: true });
  } else {
    const prefix = s.cls === "check" && !/^quick check/i.test(title) ? "Quick check: " : s.cls === "yourturn" && !/^your turn/i.test(title) ? "Your turn: " : "";
    const questionInBody = s.cls === "check" && title.length > 50;
    slide.addText(questionInBody ? "Quick check" : prefix + title, { placeholder: "title" });
    if (s.cls === "check") {
      const list = rest.find((b) => b.type === "list");
      const stem = rest.filter((b) => b !== list);
      if (questionInBody) stem.unshift({ type: "para", runs: [{ text: title }] });
      let y = BODY_Y;
      if (stem.length) { y += textBlocksHeight(stem.filter((b) => b.type !== "code"), SIZE.body, BODY_W); await layoutColumn(slide, stem, MX, BODY_Y, BODY_W, 4.2, P, deckDir, false, warn); y = Math.max(y, BODY_Y) + stem.filter((b) => b.type === "code").reduce((h, b) => h + codeHeight(b, SIZE.code) + 0.2, 0.2); }
      if (list) {
        const items = list.items, two = items.length === 4 && items.every((it) => plain(it.runs).length < 40);
        const cw = two ? (BODY_W - 0.3) / 2 : BODY_W, ch = 0.7;
        items.forEach((it, k) => {
          const cx = two ? MX + (k % 2) * (cw + 0.3) : MX, cyy = y + (two ? Math.floor(k / 2) : k) * (ch + 0.2);
          slide.addText([{ text: String.fromCharCode(65 + k) + "   ", options: { bold: true, color: P.accent } }, ...toPptRuns(it.runs, { fontFace: FONT.body, fontSize: 24, color: COLOR.text }, P)],
            { shape: "roundRect", rectRadius: 0.1, x: cx, y: cyy, w: cw, h: ch, fill: { color: P.tint }, margin: [4, 14, 4, 14], valign: "middle", fontFace: FONT.body, fontSize: 24, isTextBox: true, objectName: `Choice ${String.fromCharCode(65 + k)}` });
        });
      }
    } else if (s.cols) {
      const gap = 0.5, cw = (BODY_W - gap) / 2;
      let y = BODY_Y;
      if (rest.length) { await layoutColumn(slide, rest, MX, y, BODY_W, 2.6, P, deckDir, false, warn); y += textBlocksHeight(rest, SIZE.body, BODY_W) + 0.25; }
      for (let c = 0; c < s.cols.length && c < 2; c++) await layoutColumn(slide, s.cols[c], MX + c * (cw + gap), y, cw, BODY_BOTTOM, P, deckDir, false, warn);
    } else {
      const img = rest.find((b) => b.type === "image"), text = rest.filter((b) => b.type !== "image");
      if (img && text.length) {
        const tw = BODY_W * 0.55;
        await layoutColumn(slide, text, MX, BODY_Y, tw, BODY_BOTTOM, P, deckDir, false, warn);
        await addImage(slide, img, MX + tw + 0.4, BODY_Y, BODY_W - tw - 0.4, BODY_BOTTOM - BODY_Y, deckDir);
      } else await layoutColumn(slide, rest, MX, BODY_Y, BODY_W, BODY_BOTTOM, P, deckDir, s.cls === "recap", warn);
    }
  }
  if (s.cls === "recap") {
    // recap uses the dark frame; title drawn here because the dark layout has no title placeholder
    slide.addText(title, { x: MX, y: TITLE_Y, w: BODY_W, h: TITLE_H, fontFace: FONT.head, fontSize: SIZE.title, bold: true, color: COLOR.white, margin: 0, isTextBox: true });
  }
  if (s.notes) slide.addNotes(s.notes);
  else warn("no speaker notes");
}

// ---------- Build ----------
async function buildPptx(meta, slides, outFile, deckDir) {
  const P = {
    primary: hex(meta.primary, "2A6B37"),
    accent: hex(meta.accent, "B8860B"),
    accentDark: hex(meta.code_color, "8A1C3C"),
    tint: hex(meta.tint, "EEF5EF"),
  };
  const pres = new pptxgen();
  pres.layout = "LAYOUT_WIDE";
  pres.theme = { headFontFace: FONT.head, bodyFontFace: FONT.body };
  pres.title = meta.title || "";
  pres.author = meta.author || "ThinkPress";
  const footer = [meta.book, meta.section].filter(Boolean).join("  ·  ");
  pres.defineSlideMaster({
    title: "TP_CONTENT",
    background: { color: COLOR.white },
    objects: [
      { placeholder: { options: { name: "title", type: "title", x: MX, y: TITLE_Y, w: BODY_W, h: TITLE_H, fontFace: FONT.head, fontSize: SIZE.title, bold: true, color: P.primary, valign: "middle", margin: 0 }, text: "" } },
      { text: { text: footer, options: { x: MX, y: 7.0, w: 9, h: 0.35, fontFace: FONT.body, fontSize: 11, color: COLOR.muted, margin: 0 } } },
    ],
    slideNumber: { x: 12.2, y: 7.0, w: 0.6, h: 0.35, fontFace: FONT.body, fontSize: 11, color: COLOR.muted, align: "right" },
  });
  pres.defineSlideMaster({
    title: "TP_DARK",
    background: { color: P.primary },
    objects: [{ text: { text: footer, options: { x: MX, y: 7.0, w: 9, h: 0.35, fontFace: FONT.body, fontSize: 11, color: COLOR.light, margin: 0 } } }],
  });
  const warnings = [];
  for (let i = 0; i < slides.length; i++) {
    await renderSlide(pres, slides[i], i + 1, meta, P, deckDir, (msg) => warnings.push(`slide ${i + 1}: ${msg}`));
  }
  await pres.writeFile({ fileName: outFile });
  return warnings;
}

function buildHtml(meta, src, deckPath, outFile) {
  // Inject per-book colors so the HTML matches the PowerPoint.
  const vars = `section { --primary: ${meta.primary || "#2a6b37"}; --accent: ${meta.accent || "#b8860b"}; --tint: ${meta.tint || "#eef5ef"}; }`;
  // Student HTML: drop speaker notes (they hold quick-check answers and solutions);
  // keep Marp directives such as _class.
  const noNotes = src.replace(/<!--([\s\S]*?)-->/g, (all, inner) =>
    /^\s*_?(class|paginate|header|footer|backgroundColor|color)\s*:/.test(inner) ? all : "");
  const withStyle = noNotes.replace(/^---\r?\n/, `---\nstyle: |\n  ${vars}\n`);
  const tmp = deckPath.replace(/\.md$/, ".build-tmp.md");
  fs.writeFileSync(tmp, withStyle);
  try {
    execFileSync(path.join(HERE, "node_modules/.bin/marp"),
      [tmp, "--html", "--allow-local-files", "-o", outFile, "--theme-set", path.join(HERE, "thinkpress-lecture.css")],
      { stdio: ["ignore", "ignore", "inherit"] });
    if (!fs.existsSync(outFile)) throw new Error("marp did not write " + outFile);
  } finally { fs.unlinkSync(tmp); }
}

const args = process.argv.slice(2);
const pptxDirIdx = args.indexOf("--pptx-dir");
const pptxDir = pptxDirIdx >= 0 ? path.resolve(args[pptxDirIdx + 1]) : null;
const deckPath = path.resolve(args.find((a, i) => !a.startsWith("--") && (pptxDirIdx < 0 || i !== pptxDirIdx + 1)) || "");
if (!deckPath.endsWith(".md") || !fs.existsSync(deckPath)) { console.error("usage: node build.mjs deck.md [--no-html] [--no-pptx]"); process.exit(1); }
const src = fs.readFileSync(deckPath, "utf8");
const { meta, body } = splitFrontMatter(src);
const slides = splitSlides(body).map(parseSlide);
const deckDir = path.dirname(deckPath);
linkBase = `https://cscs.thinkpress.org/chapters/${path.basename(deckDir)}/`;
const base = deckPath.replace(/\.md$/, "");

if (!args.includes("--no-pptx")) {
  const pptxOut = pptxDir ? path.join(pptxDir, path.basename(base) + ".pptx") : base + ".pptx";
  if (pptxDir) fs.mkdirSync(pptxDir, { recursive: true });
  if (!pptxDir && deckPath.includes(`${path.sep}_html_extra${path.sep}`)) {
    console.error("refusing to write the PowerPoint inside _html_extra/ (it would be published); pass --pptx-dir");
    process.exit(1);
  }
  const warnings = await buildPptx(meta, slides, pptxOut, deckDir);
  console.log(`pptx: ${pptxOut} (${slides.length} slides)`);
  for (const w of warnings) console.log("  warning: " + w);
}
if (!args.includes("--no-html")) {
  buildHtml(meta, src, deckPath, base + ".html");
  console.log(`html: ${path.basename(base)}.html`);
}
