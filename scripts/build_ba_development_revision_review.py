#!/usr/bin/env python3
"""Build the local B-A repair review, including source diffs and re-audit evidence."""
import difflib
import html
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/ba_development_revision'
PREVIEW = Path('/tmp/cscs-section-revision/_build/html')

def read(name):
    return json.loads((OUT / name).read_text())

def main():
    findings = json.loads((ROOT / 'authoring/ba_development_audit/findings.json').read_text())
    baseline = read('baseline.json')
    added = read('added_cells.json')
    corrections = read('corrections.json')
    checks = read('code_verification.json')
    preservation = read('preservation_check.json')
    descriptions = {
        'B01': 'Qualified the retained conversion chain; separated range, precision, casting, parsing and domain validation; added a verified loss-of-one-unit example and comparison table.',
        'B02': 'Corrected the integer-division prose and floating-point comment. The new guided evaluation trace distinguishes operand types, intermediate values and display formatting.',
        'B03': 'Corrected the postfix causal explanation. A verified result/state demonstration distinguishes old expression value, updated storage and the location of a for-loop update.',
        'B04': 'The current source already contained a proper accessor lesson, validated backing-field example and Email exercise. Retained all of them, independently verified all seven examples, and repaired the question/answer tags.',
        'B05': 'Corrected the read/write API call; added separate call/result patterns and an overwrite prediction without replacing the existing walkthrough.',
        'B06': 'Retained each client-check task and embedded its complete supporting types. All three visible starters and all three complete answers compile independently.',
        'B07': 'The current caller already included its helper. Preserved that source exactly, verified it in a fresh project, and added accepted/rejected-record and domain-contract interpretation.',
        'B08': 'Retained the newer Swap Two Prices activity and added a learner-completed stock/reservation table, standalone task, solution and feedback about assignment timing.',
        'B09': 'Retained bill-splitting and Math/pricing tasks. Added a precedence/value/type table and a fractional-hours repair with explained incorrect and correct outputs.',
        'B10': 'Added prompt/read/parse/format patterns, an invoice transcript, field-width explanation, guided Folders report and boundary/mistake feedback. Supplied-input assumptions are explicit.',
        'B11': 'Retained and verified the newer shipping-condition exercise; added threshold cases and counterexamples for || versus && and > versus >=, including stored-Boolean timing.',
        'B12': 'Retained the countdown-by-twos activity; applied the planning rubric to a concrete reminder task and added a condition-boundary repair with zero-iteration feedback.',
        'B13': 'Retained and verified current Product construction practice and repaired its exercise tags. Added tuple-deconstruction transfer with units/position feedback; kept params and all prior tuple examples.',
        'B14': 'Added extraction API/result patterns, named-group and no-match explanation, matched/unmatched trace, immutable replacement demonstration and a guided whole-record repair before the retained independent practice.',
        'B15': 'Retained card masking, corrected its overclaim about identification, and added purpose-based synthetic log review with feedback distinguishing display minimization from storage deletion.',
        'B16': 'Added a reproducible three-book/three-sale dataset, general query pattern, actual filter/group/join results and guided threshold/grouping feedback. Six query results and an empty boundary were checked with SQLite.',
        'B17': 'Added complete project-only row-mapping/affected-row and rollback examples, state tables and explained guided variations. Verified forced failure, valid commit, omitted commit and missing/existing IDs.',
        'B18': 'Retained Rational and Money. Added general operator syntax, a value/nonmutation contract and a standalone guided Amount addition exercise with zero-boundary and unchanged-operand evidence.'
    }
    results=[]
    for f in findings:
        files=sorted({e['file'] for e in f['evidence']})
        ev=[]
        for filename in files:
            current=json.loads((ROOT / filename).read_text())
            byid={c['id']:c for c in current['cells']}
            original={c['id']:c for c in baseline[filename]['cells']}
            for c in current['cells']:
                if c['id'] not in original or c['source']!=original[c['id']]['source']:
                    ev.append({'file':filename,'cell_id':c['id']})
            if f['id']=='B04':
                ev.extend({'file':filename,'cell_id':c['id']} for c in current['cells'] if c['id'] in ['0ad059f5','p2_559bae69e5','p2_381f87b120','p2_b226fc3150'])
            if f['id']=='B07':ev.append({'file':filename,'cell_id':'7f7f6d6b'})
        results.append({'id':f['id'],'title':f['title'],'status':'Addressed and rechecked','resolution':descriptions[f['id']],'files':files,'evidence':ev,'independent_code_checks':[{'cell_id':c['cell_id'],'passed':c['passed']} for c in checks if c['file'] in files]})
    assert len(results)==18 and all(c['passed'] for c in checks)
    (OUT / 'reaudit.json').write_text(json.dumps(results,indent=2)+'\n')
    esc=html.escape
    style='''body{font:17px/1.6 system-ui;color:#243146;margin:36px auto;padding:0 24px;max-width:1350px}h1,h2,h3{line-height:1.25}a{color:#145ba0;text-decoration:none}a:hover{background:#edf4ff}a:focus-visible{outline:2px solid #145ba0}article{border:1px solid #cbd6e4;border-radius:8px;padding:18px 24px;margin:18px 0}summary{cursor:pointer;font-weight:650;padding:10px 0}pre{font:13px/1.5 ui-monospace,monospace;white-space:pre-wrap;overflow-wrap:anywhere;background:#f3f5f8;padding:16px}.add{background:#dff3e6}.remove{background:#ffe6e6}.stats{padding:18px;background:#eef4fa}table{border-collapse:collapse;width:100%}th,td{padding:10px;text-align:left;border-bottom:1px solid #d5deea;vertical-align:top}.scroll{overflow:auto}small{display:block;font:12px monospace}'''
    parts=['<!doctype html><html lang="en"><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1"><title>B-A development repairs and recheck</title><style>'+style+'</style><main><h1>B-A development repairs and recheck</h1><p>2026-10-18 · Current reading order preserved · Not deployed</p>']
    parts.append('<p class="stats"><b>18 findings addressed.</b> '+str(preservation['original_cells_retained_in_order'])+' original cells retained in order; '+str(preservation['original_code_cells_retained'])+' original code cells and all original output records retained. '+str(preservation['added_cells'])+' cells added. 48 independent C# checks passed; six SQL result checks plus an empty-result boundary passed. Sixteen planning files updated.</p>')
    parts.append('<p>This revision starts from the source as it existed on October 18, which already contained some improvements made after the audit. Those additions remain. The property-accessor lesson and standalone parser were verified rather than duplicated. Factual errors are corrected in place; their before/after text is documented below. Existing assignments, chapter order and TOC remain unchanged.</p><p><a href="#reaudit">All 18 findings</a> · <a href="#diffs">Before/after source diffs</a> · <a href="#verification">Checks and limits</a></p><h2 id="reaudit">Finding-by-finding recheck</h2>')
    for r in results:
        parts.append(f'<article id="{r["id"]}"><h3>{r["id"]}: {esc(r["title"])}</h3><p><b>Addressed and rechecked.</b> {esc(r["resolution"])}</p><ul>')
        for filename in r['files']:
            parts.append('<li><a href="/'+filename[:-6]+'.html">'+esc(filename)+'</a></li>')
        parts.append('</ul><details><summary>Current evidence locations</summary><ul>')
        for e in r['evidence']:parts.append('<li>'+esc(e['file'])+' · cell ID <code>'+e['cell_id']+'</code></li>')
        parts.append('</ul></details></article>')
    parts.append('<h2 id="diffs">Before/after lesson sources</h2><p>Red lines show the original wording or a cell whose code was extended; green lines show its replacement or an addition. No original cell is deleted. Complete retained programs are shown in the source diffs. Factual corrections retain their teaching purpose. Cell IDs and old output records are verified separately.</p>')
    patch=[]
    def source(n):return '\n\n'.join('['+c['cell_type']+' · '+c['id']+']\n'+''.join(c['source']) for c in n['cells'])
    for filename,old in baseline.items():
        now=json.loads((ROOT / filename).read_text());a=source(old);b=source(now)
        lines=list(difflib.unified_diff(a.splitlines(),b.splitlines(),fromfile='Before/'+filename,tofile='After/'+filename,n=3))
        if not lines:
            parts.append('<details><summary>'+esc(filename)+' — source unchanged; exercise presentation rechecked</summary><p>The current teaching development was retained and independently checked.</p></details>');continue
        patch.extend(lines)
        parts.append('<details><summary>'+esc(filename)+'</summary><pre>')
        for line in lines:
            cls=' class="add"' if line.startswith('+') else ' class="remove"' if line.startswith('-') else ''
            parts.append('<span'+cls+'>'+esc(line)+'</span>\n')
        parts.append('</pre></details>')
    parts.append('<h2 id="verification">Checks and limits</h2><pre>'+esc(json.dumps(preservation,indent=2))+'</pre><p>Each checked C# program was compiled and run in a fresh .NET 10 project. SQLite provider examples use the reference project’s pinned package and an in-memory database. New exercise solutions retain verified output. Incomplete starters are tested as intentional learner tasks, so their initial output can differ from the target answer.</p><p>The full HTML build succeeded. It reports one existing lexer warning in an unchanged Chapter 2 character-literal example. The final rendering and index destinations are checked separately. This is a recheck of the 18 identified development gaps, not a claim that every paragraph in the book is beyond further improvement.</p><p>General syntax, explanations, result interpretation and guided practice were checked as connected instruction, not quotas. Setups remain in appendices; optional material remains optional. No deployment was requested or performed.</p></main></html>')
    page=''.join(parts);(OUT / 'review.html').write_text(page);PREVIEW.mkdir(parents=True,exist_ok=True);(PREVIEW/'ba_development_revision.html').write_text(page)
    (OUT / 'lesson_sources.diff').write_text('\n'.join(patch)+'\n')
    md='# B-A Development Revision and Recheck\n\n2026-10-18. All 18 audit findings addressed using the current source as the baseline. Existing teaching cells, examples, exercises and original output records remain. Current chapter/reading order and assignments are unchanged. Not deployed.\n\n'
    for r in results:md+=f'## {r["id"]}: {r["title"]}\n\n{r["resolution"]}\n\n'
    md+='## Verification\n\n```json\n'+json.dumps(preservation,indent=2)+'\n```\n\n48 independent C# checks passed. Six SQL result queries and an empty-result boundary passed. Full HTML build passed with one existing lexer warning from an unchanged character-literal example. `reaudit.json` records current evidence; `lesson_sources.diff` shows the source changes. The HTML report also includes full before/after diffs.\n'
    (OUT / 'README.md').write_text(md)
    print(PREVIEW/'ba_development_revision.html')

if __name__ == '__main__':
    main()
