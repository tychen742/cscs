#!/usr/bin/env python3
"""Generate a local review of the additive chapter-section revision."""
from pathlib import Path
import json,re,html,difflib,yaml
from bs4 import BeautifulSoup
R=Path(__file__).resolve().parents[1];F=R/'authoring/section_revision';O=Path('/tmp/cscs-section-revision/_build/html')
base=json.loads((F/'baseline.json').read_text());inv=json.loads((R/'authoring/content_size/inventory.json').read_text());size=json.loads((F/'size_comparison.json').read_text());pres=json.loads((F/'preservation_check.json').read_text());plans=json.loads((R/'authoring/content_size/section_boundary_review.json').read_text())
style='''body{font:17px system-ui;line-height:1.6;margin:30px;color:#243047}main{max-width:1450px;margin:auto}a{color:#175ca6;text-decoration:none}a:hover{background:#edf4ff}a:focus-visible{outline:2px solid #175ca6}summary{font-weight:650;cursor:pointer;padding:12px 0}details{border-top:1px solid #ccd6e2;margin:12px 0}table{border-collapse:collapse;width:100%;margin:15px 0}td,th{padding:8px;border-bottom:1px solid #d8dfe8;text-align:left;vertical-align:top}th{background:#eef2f7}.diff{table-layout:fixed;font:12px ui-monospace,monospace}.diff td{white-space:pre-wrap!important;overflow-wrap:anywhere}.diff_header{background:#eef2f7}.diff_add{background:#d8f1df}.diff_sub{background:#ffdddd}.diff_chg{background:#fff0b5}col.num{width:40px}col.prose{width:calc(50% - 40px)}input{font:inherit;padding:10px;max-width:90%;width:500px}.stats{background:#eef4fa;padding:16px;border-radius:8px}'''
parts=['<!doctype html><html lang="en"><meta charset="utf-8"><title>Section revision: lessons and preservation</title><style>'+style+'</style><main><h1>Section revision: lessons and preservation</h1><p>The 26-chapter sequence is retained. Reading boundaries follow the reviewed ORGANIZATION/MATERIALS plan; explanations, original examples and exercise variations remain. Not deployed.</p>']
parts.append(f'<p class="stats">Published content readings: {size["before_readings"]} → {size["after_readings"]}. Approximate prose: {size["before_prose_words"]:,} → {size["after_prose_words"]:,}. Pages below 500 prose words: {size["before_under_500"]} → {size["after_under_500"]}; the two remaining short pages are supporting reference readings.</p>')
parts.append(f'<p>Preservation: {pres["active_original_nonempty_cells"]:,} original nonempty lesson cells accounted for, including {pres["active_original_code_cells"]} original code cells. Six new runnable examples compile/run independently with saved output. Original assignment content, code, identities and outputs remain, with section-reference corrections in the Methods lab.</p><p>Counts are screening evidence, not a quality score. Cell counts also increased because headings now occupy separate indexed cells. The additions develop reasoning, state traces, boundary cases and guided variations; they are not a word quota.</p><p><a href="section_revision_sources.html">Online comparisons and sources</a> · <a href="content_size_audit.html">Updated size inventory</a></p><p><input id="filter" placeholder="Filter by chapter or title" aria-label="Filter chapters"></p>')
def text(n):
 s='\n\n'.join(''.join(c['source']) for c in n['cells']);s=re.sub(r'```\{index\}[^\n]*\n```\s*','',s);return s
for ch in inv['chapters']:
 num=ch['chapter'];rows=[r for r in inv['pages'] if r['chapter']==num and r['role']=='content'];folder=Path(rows[0]['path']).parent
 parts.append(f'<section class="chapter" id="ch{num}"><h2>{num}. {html.escape(ch["title"])}</h2><p><strong>{html.escape(plans[str(num)]["action"])}</strong></p><ol>')
 for r in rows:parts.append('<li><a href="'+r['path'][:-6]+'.html">'+html.escape(r['title'])+'</a> ('+str(r['prose_words'])+' prose words)</li>')
 parts.append('</ol><details><summary>Before/after lesson sources</summary><p>Green is added or relocated material; red includes material moved to another reading. Preservation is checked across the complete reading set, not by treating each red line as removal. Index directives are omitted from these displays for readability.</p>')
 keys=set(k for k in base if str(folder)+'/' in k and '/assignments/' not in k and not re.search(r'/\d\d00_',k));keys.update(r['path'][:-6] for r in rows)
 for k in sorted(keys):
  p=R/(k+'.ipynb');now=json.loads(p.read_text());old=base.get(k,{'cells':[]});a=text(old);b=text(now)
  if a==b:continue
  tab=BeautifulSoup(difflib.HtmlDiff(wrapcolumn=105).make_table(a.splitlines(),b.splitlines(),'Before','After',context=True,numlines=2),'html.parser').table
  for e in tab.select('.diff_next,colgroup'):e.decompose()
  tab.insert(0,BeautifulSoup('<colgroup><col class="num"><col class="prose"><col class="num"><col class="prose"></colgroup>','html.parser').colgroup)
  parts.append('<details><summary>'+html.escape(Path(k).name)+'</summary>'+str(tab).replace('&nbsp;',' ')+'</details>')
 parts.append('</details></section>')
parts.append('''<script>document.querySelector('#filter').addEventListener('input',e=>{const q=e.target.value.toLowerCase();document.querySelectorAll('.chapter').forEach(s=>s.hidden=!s.textContent.toLowerCase().includes(q))})</script></main></html>''')
(F/'index.html').write_text(''.join(parts));O.mkdir(parents=True,exist_ok=True);(O/'section_revision_review.html').write_text(''.join(parts));(O/'content_size_audit.html').write_text((R/'authoring/content_size/index.html').read_text())
from markdown_it import MarkdownIt
body=MarkdownIt().enable('table').render((F/'SOURCES.md').read_text());(O/'section_revision_sources.html').write_text('<!doctype html><meta charset="utf-8"><title>Comparison sources</title><style>'+style+'</style><main>'+body+'</main>')
print(O/'section_revision_review.html')
