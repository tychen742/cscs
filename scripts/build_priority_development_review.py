import json,html,difflib,sys
from pathlib import Path
R=Path(__file__).resolve().parents[1];O=R/'authoring/priority_development';e=html.escape
sys.path.insert(0,str(R/'scripts'));from audit_content_size import measure
baseline=json.loads((O/'baseline.json').read_text());notes=json.loads((O/'coverage.json').read_text())
prior={r['path']:r for r in json.loads((R/'authoring/content_size/development_review.json').read_text())['sections']}
rows=[]
for rel,old in baseline.items():
 new=json.loads((R/rel).read_text());oldtext='\n\n'.join(''.join(c['source']) for c in old['cells']);newtext='\n\n'.join(''.join(c['source']) for c in new['cells']);count=measure(R/rel)
 rows.append({'path':rel,'title':count['title'],'before_prose_words':prior[rel]['prose_words'],'before_cells':len(old['cells']),'after_cells':count['cells'],'after_prose_words':count['prose_words'],'new_code_cells':sum(c['cell_type']=='code' and c['id'].startswith('ba_') for c in new['cells']),'coverage':notes[Path(rel).stem[:4]],'diff':list(difflib.unified_diff(oldtext.splitlines(),newtext.splitlines(),fromfile='Before',tofile='After',lineterm=''))})
(O/'changes.json').write_text(json.dumps(rows,ensure_ascii=False,indent=2)+'\n')
s=['<!doctype html><html lang="en"><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><title>Priority-section development review</title><style>body{font:16px/1.55 system-ui;margin:30px auto;max-width:1250px;padding:0 24px;color:#263349}table{border-collapse:collapse;width:100%}td,th{padding:10px;border-bottom:1px solid #d9e0e8;text-align:left;vertical-align:top}th{background:#edf1f5}a{color:#155ca2;text-decoration:none}a:hover{background:#edf1f5}a:focus-visible{outline:2px solid #155ca2}details{margin:18px 0}summary{cursor:pointer;font-weight:650}pre{white-space:pre-wrap;overflow-wrap:anywhere;background:#f4f6f8;padding:16px;font:14px/1.5 ui-monospace,monospace}.added{color:#156329}.removed{color:#8e2631}</style><body><h1>Priority-section development review</h1><p>Local revision, not deployed. Fifteen readings across ten chapters, preserving the current order and assignments. New teaching cores precede complete retained examples; original variations remain.</p><p><a href="content_size_audit.html">Refreshed full-book counts</a></p><table><tr><th>Reading</th><th>Cells before / after</th><th>Words before / after</th><th>New runnable examples</th><th>Developed instruction</th></tr>']
for r in rows:
 url=r['path'].replace('.ipynb','.html');s.append(f'<tr><td><a href="{url}">{e(r["title"])}</a></td><td>{r["before_cells"]} / {r["after_cells"]}</td><td>{r["before_prose_words"]:,} / {r["after_prose_words"]:,}</td><td>{r["new_code_cells"]}</td><td>{e(r["coverage"])}</td></tr>')
s.append('</table><h2>Preservation and verification</h2>')
for filename in ['preservation_check.json','verification_summary.json']:
 if (O/filename).exists():s.append('<pre>'+e((O/filename).read_text())+'</pre>')
s.append('<h2>Source differences</h2><p>Each comparison uses full-width wrapped source lines, avoiding the narrow side-by-side layout. Green lines are additions; red lines show the explicitly recorded corrections or formatting repairs. Expand a reading to inspect its changes.</p>')
for r in rows:
 s.append('<details><summary>'+e(r['title'])+'</summary><pre>')
 for line in r['diff']:s.append('<span class="'+('added' if line.startswith('+') else 'removed' if line.startswith('-') else '')+'">'+e(line)+'</span>\n')
 s.append('</pre></details>')
s.append('</body></html>');(O/'index.html').write_text('\n'.join(s))
print(f'Review includes {len(rows)} full source diffs.')
