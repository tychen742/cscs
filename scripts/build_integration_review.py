#!/usr/bin/env python3
"""Build a local review of integration changes, moves and full source diffs."""
import json,difflib,html
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1];OUT=ROOT/'authoring/integration_cleanup';e=html.escape
base=json.loads((OUT/'baseline.json').read_text());plans=json.loads((OUT/'planning_before.json').read_text());moves=json.loads((OUT/'moves.json').read_text());changes=[]
for path,old in base.items():
 now=json.loads((ROOT/path).read_text());before='\n\n'.join(''.join(c['source']) for c in old['cells']);after='\n\n'.join(''.join(c['source']) for c in now['cells'])
 if before!=after:changes.append({'path':path,'diff':list(difflib.unified_diff(before.splitlines(),after.splitlines(),fromfile='Before integration',tofile='After integration',lineterm=''))})
for path,before in plans.items():
 after=(ROOT/path).read_text()
 if before!=after:changes.append({'path':path,'diff':list(difflib.unified_diff(before.splitlines(),after.splitlines(),fromfile='Before integration',tofile='After integration',lineterm=''))})
(OUT/'diffs.json').write_text(json.dumps(changes,ensure_ascii=False,indent=1)+'\n')
s=['<!doctype html><html lang="en"><meta charset="utf-8"><meta name="viewport" content="width=device-width, initial-scale=1"><title>CSCS integration review</title><style>body{font:16px/1.55 system-ui;max-width:1300px;margin:30px auto;padding:0 24px;color:#263349}h1{font-size:30px}table{border-collapse:collapse;width:100%;margin-bottom:24px}td,th{padding:10px;border-bottom:1px solid #d9e0e8;vertical-align:top;text-align:left}th{background:#edf1f5}a{color:#155ca2;text-decoration:none}a:hover{background:#edf1f5}a:focus-visible{outline:2px solid #155ca2}details{margin:20px 0}summary{cursor:pointer;font-weight:650}pre{white-space:pre-wrap;overflow-wrap:anywhere;background:#f4f6f8;padding:16px;font:14px/1.5 ui-monospace,monospace}.plus{color:#156329}.minus{color:#8e2631}</style><body><h1>Integration cleanup and prerequisite placement</h1><p>Local work, not deployed. All recently developed lessons, explanations and exercise variations are retained. Empty/navigation/rubric cells are consolidated; executable sources and saved outputs are preserved.</p><p><a href="content_size_audit.html">Updated counts for all 92 active readings</a></p><h2>Review the targeted moves</h2><table><tr><th>Teaching change</th><th>Open the integrated lesson</th></tr>']
links=[('Type foundations before conversion applications; all input-casting examples beside conversion','chapters/02_var_data/0204_types_conversion.html'),('Single-value input and output before any required loop','chapters/02_var_data/0203_input_output.html'),('Loop-generated tables after for-loop instruction, preserving all formatting variants','chapters/04_iteration/0402_for_statements.html#apply-loops-to-formatted-tables'),('Search contracts with a short bridge to preparation','chapters/16_searching_sorting/1601_searching.html'),('Reporting snapshots and preparation/update costs after sorting instruction','chapters/16_searching_sorting/1602_basic_sorting.html#compare-reporting-and-query-workloads'),('Traversal verification closes DFS/components; old page redirects here','chapters/20_graphs/2004_depth_first_components.html#verify-a-traversal'),('The complete minimum-hop/minimum-cost counterexample is with weighted routes','chapters/24_greedy_graph_optimization/2404_shortest_paths.html#minimum-hops-is-not-minimum-cost'),('Chapter 26 orientation follows direct matching, KMP and computational limits','chapters/26_advanced_graphs_strings_limits/2600_advanced_graphs_strings_limits.html'),('Framework setup and test attributes are content before Footnotes','chapters/06_exceptions_testing/0603_testing.html#framework-setup-and-test-attributes')]
for text,url in links:s.append(f'<tr><td>{e(text)}</td><td><a href="{url}">Open lesson</a></td></tr>')
s.append('</table><h2>Verification</h2>')
for file in ['preservation_check.json','render_verification.json','verification_summary.json']:
 if (OUT/file).exists():s.append('<pre>'+e((OUT/file).read_text())+'</pre>')
s.append('<h2>Full source differences</h2><p>Expand a lesson or planning file. Relocated material appears as removal at its old location and addition at its destination; the cell lineage and code checks above verify preservation. Historical source snapshots remain available.</p>')
for c in changes:
 s.append('<details><summary>'+e(c['path'])+'</summary><pre>')
 for line in c['diff']:s.append('<span class="'+('plus' if line.startswith('+') else 'minus' if line.startswith('-') else '')+'">'+e(line)+'</span>\n')
 s.append('</pre></details>')
s.append('</body></html>');(OUT/'index.html').write_text('\n'.join(s));print(f'Review contains {len(changes)} notebook/planning diffs.')
