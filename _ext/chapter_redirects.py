"""Preserve published chapter URLs after the October 2026 reorder."""
import html
import json
import posixpath
from pathlib import Path


def write_redirects(app, exception):
    if exception or app.builder.format != 'html':
        return
    redirects = json.loads(Path(__file__).with_suffix('.json').read_text())
    fragment_file = Path(__file__).with_name('section_anchor_routes.json')
    fragments = json.loads(fragment_file.read_text()) if fragment_file.exists() else {}
    for old, new in redirects.items():
        target = posixpath.relpath(new + '.html', posixpath.dirname(old))
        page = Path(app.outdir) / (old + '.html')
        page.parent.mkdir(parents=True, exist_ok=True)
        fragment_targets = {
            key[len(old + '.html'):]: posixpath.relpath(value.split('#')[0], posixpath.dirname(old)) + '#' + value.split('#', 1)[1]
            for key, value in fragments.items() if key.startswith(old + '.html#')
        }
        page.write_text(
            '<!doctype html><meta charset="utf-8">'
            '<title>Page moved</title>'
            f'<meta http-equiv="refresh" content="0; url={html.escape(target)}">'
            f'<a href="{html.escape(target)}">Continue to the chapter</a>'
            '<script>const fragments=' + json.dumps(fragment_targets) + ';'
            'const next=new URL(fragments[location.hash]||(' + json.dumps(target) + '+location.hash),location.href);'
            'next.search=location.search;location.replace(next.href)</script>'
        )


def setup(app):
    app.connect('build-finished', write_redirects)
    return {'version': '1.0', 'parallel_read_safe': True}
