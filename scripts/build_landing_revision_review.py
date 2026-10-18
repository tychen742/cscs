#!/usr/bin/env python3
"""Build the review artifact with readable full before/after Markdown diffs."""
import difflib
import html
import json
from pathlib import Path
R = Path(__file__).resolve().parents[1]
O = R / 'authoring/landing_page_revision'
B = Path('/tmp/cscs-section-revision/_build/html')
old = json.loads((R / 'authoring/landing_page_audit/inventory.json').read_text())
rows = json.loads((O / 'manifest.json').read_text())
head = '''<!doctype html><html lang="en"><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>Chapter landing-page revision</title><style>body{font:18px/1.55 system-ui;max-width:1080px;margin:35px auto;padding:0 20px;color:#25334a}a{color:#1763b5;text-decoration:none}a:hover{background:#e8f1fb}a:focus-visible{outline:2px solid currentColor}table{border-collapse:collapse;width:100%}th,td{text-align:left;padding:10px;border-bottom:1px solid #ccd5df}th{background:#eef1f6}pre{white-space:pre-wrap;overflow-wrap:anywhere;font:14px/1.5 ui-monospace,monospace;background:#f6f7f9;padding:18px}article{padding-top:20px;border-top:1px solid #ccd5df;margin-top:35px}summary{cursor:pointer;font-weight:600;padding:10px 0}nav{display:flex;gap:12px;flex-wrap:wrap}</style><body><h1>Chapter landing-page revision</h1><p>All 26 numbered chapter landings revised against B-A. Introductions, concept maps, and measurable objectives reflect the current readings; glossaries render as continuous numbered tables. Chapter Flow contains the content readings in their existing order.</p><p><b>Preservation:</b> 315 other notebooks are byte-identical. Chapter order, section paths, assignments, and exercises are unchanged. Existing video selections and old heading anchors are retained.</p><p><b>Lecture decks:</b> explicitly deferred as a separate task at the author's request. Each page identifies the deck as in preparation rather than linking a nonexistent file.</p><p>Public YouTube metadata supplied runtimes, titles, creators, and embed permissions. This is not a transcript or full playback review. Five empty slots are filled, and Chapter 26 gains a KMP introduction while retaining its graph review.</p><nav>'''
head += ''.join(f'<a href="#ch{r["chapter"]}">{r["chapter"]}</a>' for r in rows) + '</nav><h2>Verified chapter inventory</h2><table><tr><th>Chapter</th><th>Core objectives</th><th>Glossary terms</th><th>Page</th></tr>'
for r in rows:
 href=r['path'].replace('.ipynb','.html')
 head+=f'<tr><td>{r["chapter"]}. {html.escape(r["title"])}</td><td>{r["objectives"]}</td><td>{r["glossary_terms"]}</td><td><a href="{href}">Preview</a></td></tr>'
head+='</table><h2>Before and after</h2><p>Each expandable comparison shows the entire landing-page Markdown diff. Reductions remove obsolete orientation or formatting, not content lessons or exercises.</p>'
for r,b in zip(rows,old):
 n=json.loads((R/r['path']).read_text());s='\n\n'.join(''.join(c['source']) for c in n['cells'])
 diff='\n'.join(difflib.unified_diff(b['source'].splitlines(),s.splitlines(),fromfile='Before',tofile='After',lineterm=''))
 head+=f'<article id="ch{r["chapter"]}"><h2>{r["chapter"]}. {html.escape(r["title"])}</h2><p><a href="{r["path"].replace(".ipynb",".html")}">Open revised landing page</a></p><details><summary>Show full source comparison</summary><pre>{html.escape(diff)}</pre></details></article>'
head+='</body></html>'
(O/'review.html').write_text(head)
(B/'landing_revision_review.html').write_text(head)
print(B/'landing_revision_review.html')
