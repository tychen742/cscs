"""Render the complete index mapping as a searchable local review."""
import difflib
import html
import json
from pathlib import Path

ROOT=Path(__file__).resolve().parents[1]
OUT=ROOT/'authoring/index_revision'
BUILD=Path('/tmp/cscs-section-revision/_build/html')
rows=json.loads((OUT/'mapping.json').read_text())
check=json.loads((OUT/'verification.json').read_text())
additions=json.loads((ROOT/'_ext/subject_index_additions.json').read_text())['entries']
E=html.escape
page='''<!doctype html><html lang="en"><meta charset="utf-8"><title>Subject index revision</title><style>body{font:17px/1.55 system-ui;color:#24324a;max-width:1500px;margin:36px auto;padding:0 24px}h1{font-size:34px}table{border-collapse:collapse;width:100%}td,th{border:1px solid #ccd3dd;padding:12px;text-align:left;vertical-align:top}th{background:#edf3f8}input,select{font:inherit;padding:9px;margin:8px}.controls{position:sticky;top:0;background:white;border-bottom:1px solid #ccd3dd}pre{white-space:pre-wrap;overflow-wrap:anywhere;background:#f4f6fa;padding:18px}small{color:#58677d}li{margin:6px 0}a{color:#1556a8}</style><h1>Subject index revision</h1><p><a href="genindex.html">Open the revised index</a></p><p>All 1,435 audited entries are resolved through an explicit reviewed mapping. The table below shows every old entry, its replacement or removal, and the original teaching passages. No teaching heading, explanation, exercise, code cell, or notebook output was changed.</p>'''
page+=f'<p><strong>{check["canonical_subject_terms"]:,} subject terms · {check["cross_references"]} cross-references · {check["added_direct_entries"]} direct entries added · {check["notebooks_byte_identical"]} notebooks byte-identical.</strong></p><p>{check["local_index_links_checked"]:,} local index links checked; no broken destinations. All original mapped teaching passages are represented. Duplicate pointers within the same passage are collapsed. Not deployed.</p>'
page+='''<h2>Examples</h2><table><tr><th>Before</th><th>After</th></tr><tr><td>A Boolean Result Answers a Question</td><td>methods → Boolean return values</td></tr><tr><td>last in first out → enqueue/dequeue</td><td>queue → Enqueue/Dequeue; stack → LIFO; queue → FIFO</td></tr><tr><td>string → Parse</td><td>parsing → numeric-input conversion, with qualified int.Parse and double.Parse entries elsewhere</td></tr><tr><td>tree height → tree depth</td><td>tree → height; tree → node depth</td></tr><tr><td>dictionary → Keys Keys property</td><td>dictionary → Keys property</td></tr><tr><td>Recursion and algorithms findable only through headings</td><td>Direct entries plus BFS, DFS, GCD, KMP and other aliases</td></tr></table><h2>Complete entry mapping</h2><div class="controls"><label>Search <input id="q" placeholder="Original, subject, or lesson"></label><label>Show <select id="show"><option value="all">All</option><option value="changed">Reworded or regrouped</option><option value="retained">Confirmed and retained</option><option value="removed">Removed from index</option></select></label><span id="count"></span></div><table id="mapping"><thead><tr><th>Old entry</th><th>Reviewed subjects</th><th>Resolution and locations</th></tr></thead><tbody>'''
for row in rows:
 subjects=row['subjects'];status='removed' if not subjects else 'retained' if subjects==[row['original']] else 'changed'
 subjects_html='<ul>'+''.join('<li>'+E(x)+'</li>' for x in subjects)+'</ul>' if subjects else '<em>Omit from subject index</em>'
 links=[]
 for l in row['locations']:
  url=l['document']+'.html#'+l['target']
  links.append(f'<details><summary><a href="{E(url)}">{E(l["heading"] or l["document"])}</a></summary><p>{E(l["excerpt"])}</p></details>')
 page+=f'<tr data-status="{status}"><td><small>#{row["id"]}</small><br>{E(row["original"])}</td><td>{subjects_html}</td><td>{E(row["resolution"])}'+''.join(links)+'</td></tr>'
page+='</tbody></table><h2>Direct entries and cross-references added</h2><table><tr><th>Kind</th><th>Entry</th><th>Teaching passage</th></tr>'
for a in additions:
 url=a['document']+'.html#'+a['target']
 page+='<tr><td>'+E(a.get('kind','single'))+'</td><td>'+E(a['value'])+'</td><td><a href="'+E(url)+'">'+E(a['document']+'#'+a['target'])+'</a></td></tr>'
page+='</table><details><summary>Index extension source diff</summary><pre>'
before=(OUT/'subject_index_before.py').read_text().splitlines();after=(ROOT/'_ext/subject_index.py').read_text().splitlines()
page+=E('\n'.join(difflib.unified_diff(before,after,fromfile='Before',tofile='After',lineterm='')))
page+='''</pre></details><script>const rs=[...document.querySelectorAll('#mapping tbody tr')],q=document.querySelector('#q'),s=document.querySelector('#show');function filter(){let n=0;for(const r of rs){const ok=(s.value==='all'||r.dataset.status===s.value)&&r.textContent.toLowerCase().includes(q.value.toLowerCase());r.hidden=!ok;n+=ok;}document.querySelector('#count').textContent=n+' entries shown';}q.addEventListener('input',filter);s.addEventListener('change',filter);filter();</script></html>'''
(OUT/'index.html').write_text(page)
(BUILD/'index_revision_review.html').write_text(page)
print('Review includes every audited entry and all additions.')
