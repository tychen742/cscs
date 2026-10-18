#!/usr/bin/env python3
"""Reproduce the published-notebook size inventory without changing lessons."""
import csv, datetime, html, json, re
from collections import Counter
from pathlib import Path
import yaml

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/content_size'
WORDS = re.compile(r"\b[\w]+(?:['’\-][\w]+)*\b", re.UNICODE)
def words(s): return len(WORDS.findall(s))
def source(c): return ''.join(c.get('source', []))
def measure(path):
    n = json.loads(path.read_text()) if path.suffix == '.ipynb' else {'cells':[{'cell_type':'markdown','source':path.read_text()}]}; counts = Counter(); prose_parts = []; fenced_parts = []; title = path.stem
    for c in n['cells']:
        s = source(c); kind = c['cell_type']; counts['cells'] += 1; counts[kind+'_cells'] += 1
        if not s.strip(): counts['empty_cells'] += 1
        if kind == 'code':
            counts['code_words'] += words(s); counts['code_lines'] += sum(bool(x.strip()) for x in s.splitlines())
            counts['saved_output_cells'] += bool(c.get('outputs'))
            counts['hidden_code_cells'] += any(t in c.get('metadata',{}).get('tags',[]) for t in ['hide-input','hide-cell','remove-cell'])
        if kind != 'markdown': continue
        m = re.search(r'^# (.+)$', s, re.M)
        if m and title == path.stem: title = m.group(1)
        counts['markdown_words'] += words(s)
        # Count narrative separately from fenced code, directives, anchors and URLs.
        lines=[]; fence=None; block=[]; mode=None
        for line in s.splitlines():
            f=re.match(r'^\s*(`{3,}|~{3,})(.*)$',line)
            if fence:
                if f and f.group(1)[0] == fence[0] and len(f.group(1)) >= len(fence):
                    
                    if mode == 'code': fenced_parts.append('\n'.join(block))
                    elif mode == 'prose': lines.extend(block)
                    fence=None; block=[]; mode=None
                else: block.append(line)
                continue
            if f:
                fence=f.group(1); block=[]
                directive=re.match(r'\{([^}]+)\}',f.group(2).strip())
                mode=('meta' if directive.group(1) in ['index','contents','literalinclude','include','toctree'] else 'prose') if directive else 'code'
                continue
            if re.match(r'^\s*(?::+\{.*|:+\s*$|:[\w-]+:|\([^\n]+\)=\s*$)',line): continue
            lines.append(line)
        if block:
            if mode == 'code': fenced_parts.append('\n'.join(block))
            elif mode == 'prose': lines.extend(block)
        s='\n'.join(lines); s=re.sub(r'<!--.*?-->','',s,flags=re.S)
        s=re.sub(r'<[^>]+>',' ',s); s=re.sub(r'!?\[([^\]]*)\]\([^)]*\)',r'\1',s)
        s=re.sub(r'https?://\S+','',s); s=re.sub(r'^\[\^[^]]+\]:\s*','',s,flags=re.M)
        prose_parts.append(s)
    counts['prose_words']=words('\n'.join(prose_parts));counts['fenced_words']=words('\n'.join(fenced_parts))
    result={k:counts[k] for k in ['cells','markdown_cells','code_cells','raw_cells','empty_cells','prose_words','markdown_words','fenced_words','code_words','code_lines','saved_output_cells','hidden_code_cells']}
    return {'title':title,**result}

def main():
    toc=yaml.safe_load((ROOT/'_toc.yml').read_text());rows=[]; seen=set()
    def walk(node,chapter=0,role='other'):
        if 'file' in node:
            rel=node['file']+'.ipynb';p=ROOT/rel
            if not p.exists() and (ROOT/(node['file']+'.md')).exists(): rel=node['file']+'.md';p=ROOT/rel
            if rel not in seen:
                seen.add(rel)
                actual='assignment' if '/assignments/' in rel else role
                if not p.exists(): raise FileNotFoundError(rel)
                rows.append({'chapter':chapter,'role':actual,'path':rel,'format':p.suffix[1:],**measure(p)})
        for child in node.get('sections',[]):walk(child,chapter,'content' if chapter else role)
    walk({'file':toc['root']},0,'front matter')
    for part in toc.get('parts',[]):
        for ch in part.get('chapters',[]):
            m=re.match(r'chapters/(\d\d)[_-]',ch.get('file',''));num=int(m.group(1)) if m else 0
            role='landing' if num else ('part overview' if '/parts/' in ch.get('file','') else 'appendix' if '/appendices/' in ch.get('file','') else 'front matter')
            walk(ch,num,role)
    sections=[r for r in rows if r['role']=='content']; summaries=[]
    for num in range(1,27):
        sr=[r for r in sections if r['chapter']==num];land=next(r for r in rows if r['chapter']==num and r['role']=='landing')
        summaries.append({'chapter':num,'title':land['title'],'sections':len(sr),'prose_words':sum(r['prose_words'] for r in sr),'cells':sum(r['cells'] for r in sr),'code_cells':sum(r['code_cells'] for r in sr),'under_500':sum(r['prose_words']<500 for r in sr),'under_1000':sum(r['prose_words']<1000 for r in sr),'shortest_words':min(r['prose_words'] for r in sr)})
    OUT.mkdir(exist_ok=True)
    payload={'generated':datetime.datetime.now().isoformat(timespec='seconds'),'scope':'Current working-tree notebooks in _toc.yml. Chapter summaries include content sections only; exclude landing pages and assignments. Nested supporting readings are included if published as content.','method':'Prose words are approximate tokens in markdown outside fenced blocks, directives/options, anchors, HTML tags/comments and URLs; headings, tables, captions, inline identifiers and footnotes remain. Markdown words count the entire markdown source. Code words/lines are separate. Saved outputs excluded from words. Notebook cells include empty cells and hidden solutions; Markdown pages are counted as one synthetic markdown cell and identified by format. Thresholds flag review candidates, not quality failures.','chapters':summaries,'pages':rows}
    (OUT/'inventory.json').write_text(json.dumps(payload,indent=2,ensure_ascii=False)+'\n')
    for name,data in [('sections',sections),('chapters',summaries),('all_published_pages',rows)]:
        with (OUT/(name+'.csv')).open('w',newline='') as f:
            w=csv.DictWriter(f,fieldnames=list(data[0]));w.writeheader();w.writerows(data)
    md=['# Content-section size inventory','',payload['scope'],'',payload['method'],'','## Chapter totals','','| Chapter | Title | Sections | Prose words | Cells | Code cells | Under 500 | Under 1,000 |','| --- | --- | ---: | ---: | ---: | ---: | ---: | ---: |']
    for r in summaries:md.append('| '+ ' | '.join(str(r[k]) for k in ['chapter','title','sections','prose_words','cells','code_cells','under_500','under_1000'])+' |')
    md+=['','## All content sections, shortest first','','| Chapter | Section | Prose words | Markdown cells | Code cells | Fenced words |','| --- | --- | ---: | ---: | ---: | ---: |']
    for r in sorted(sections,key=lambda r:r['prose_words']):md.append(f"| {r['chapter']} | [{r['title']}](../../{r['path']}) | {r['prose_words']} | {r['markdown_cells']} | {r['code_cells']} | {r['fenced_words']} |")
    (OUT/'REPORT.md').write_text('\n'.join(md)+'\n')
    def table(data,keys):
        return '<table><thead><tr>'+''.join('<th>'+html.escape(k.replace('_',' ').title())+'</th>' for k in keys)+'</tr></thead><tbody>'+''.join('<tr>'+''.join('<td>'+html.escape(str(r[k]))+'</td>' for k in keys)+'</tr>' for r in data)+'</tbody></table>'
    markup='''<!doctype html><meta charset="utf-8"><title>CSCS content size audit</title><style>body{font:16px system-ui;line-height:1.5;margin:32px;color:#243047}table{border-collapse:collapse;width:100%;margin-bottom:36px}td,th{padding:8px 12px;border-bottom:1px solid #d9e0e8;text-align:left}th{background:#edf2f8;position:sticky;top:0}tr:nth-child(even){background:#f8fafc}input{font:inherit;padding:10px;width:450px;max-width:90%}a{color:#155cad;text-decoration:none}h1{margin-bottom:8px}.note{max-width:1000px}</style><h1>CSCS content-section size audit</h1>'''
    markup+='<p class="note">'+html.escape(payload['scope'])+'</p><p class="note">'+html.escape(payload['method'])+'</p>'
    markup+=f'<p><strong>{len(sections)} content pages across 26 chapters; {sum(r["prose_words"]<500 for r in sections)} below 500 prose words; {sum(r["prose_words"]<1000 for r in sections)} below 1,000.</strong></p><h2>Chapter totals</h2>'
    markup+=table(summaries,['chapter','title','sections','prose_words','cells','code_cells','under_500','under_1000'])
    markup+='<h2>Content sections, shortest first</h2><p><input id="filter" placeholder="Filter by chapter, section title, or path" aria-label="Filter content sections"></p>'
    markup+=table(sorted(sections,key=lambda r:r['prose_words']),['chapter','title','prose_words','cells','markdown_cells','code_cells','fenced_words','code_lines','path'])
    markup+='''<script>document.querySelector('#filter').addEventListener('input',e=>{document.querySelectorAll('table:last-of-type tbody tr').forEach(r=>r.hidden=!r.textContent.toLowerCase().includes(e.target.value.toLowerCase()))})</script>'''
    (OUT/'index.html').write_text(markup)
    print(json.dumps({'sections':len(sections),'under500':sum(r['prose_words']<500 for r in sections),'under1000':sum(r['prose_words']<1000 for r in sections),'shortest':sorted(sections,key=lambda r:r['prose_words'])[:15],'chapters':summaries},indent=2))
if __name__=='__main__':main()
