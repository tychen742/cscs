"""Preserve published chapter URLs after the October 2026 reorder."""
import html
import json
import posixpath
from pathlib import Path


def write_redirects(app, exception):
    if exception or app.builder.format != 'html':
        return
    redirects = json.loads(Path(__file__).with_suffix('.json').read_text())
    for old, new in redirects.items():
        target = posixpath.relpath(new + '.html', posixpath.dirname(old))
        page = Path(app.outdir) / (old + '.html')
        page.parent.mkdir(parents=True, exist_ok=True)
        page.write_text(
            '<!doctype html><meta charset="utf-8">'
            '<title>Page moved</title>'
            f'<meta http-equiv="refresh" content="0; url={html.escape(target)}">'
            f'<a href="{html.escape(target)}">Continue to the chapter</a>'
            '<script>location.replace(' + json.dumps(target) +
            ' + location.search + location.hash)</script>'
        )


def setup(app):
    app.connect('build-finished', write_redirects)
    return {'version': '1.0', 'parallel_read_safe': True}
