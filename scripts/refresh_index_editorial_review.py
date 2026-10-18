"""Refresh complete rendered before/after term lists for the local index review."""
import html
import json
import re
from pathlib import Path
from bs4 import BeautifulSoup

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/index_cleanup'
BUILD = Path('/tmp/cscs-section-revision/_build/html')
soup = BeautifulSoup((BUILD / 'genindex.html').read_text(), 'html.parser')
before = set(json.loads((OUT / 'labels_before_editorial.json').read_text()))
after = {a.get_text(' ', strip=True) for a in soup.select('.indextable a')
         if not re.fullmatch(r'\[\d+\]', a.get_text(' ', strip=True))}
delta = {'removed_or_replaced': sorted(before - after, key=str.casefold),
         'added_or_normalized': sorted(after - before, key=str.casefold)}
(OUT / 'editorial_changes.json').write_text(json.dumps(delta, indent=2) + '\n')
page = (OUT / 'editorial_review.html').read_text().split('<details>')[0]
for key, values in delta.items():
    page += '<details><summary>' + key.replace('_', ' ').title() + f' ({len(values)})</summary><ul>'
    page += ''.join('<li>' + html.escape(value) + '</li>' for value in values)
    page += '</ul></details>'
page += '</html>'
(OUT / 'editorial_review.html').write_text(page)
(BUILD / 'index_cleanup_review.html').write_text(page)
print({key: len(values) for key, values in delta.items()})
