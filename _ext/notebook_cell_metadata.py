"""Annotate rendered notebook code cells with stable source metadata."""

import json
from pathlib import Path

from bs4 import BeautifulSoup
import re


def _cell_id(cell):
    metadata = cell.get("metadata", {}) or {}
    return cell.get("id") or metadata.get("id")


def _markdown_anchor(source):
    for line in source.splitlines():
        text = re.sub(r"[`*_#]", "", line).strip()
        if (
            text
            and not text.startswith(("::", "(", "```", ".. ", ":", "---", "<", "<!--"))
            and not text.endswith(("=", "-"))
        ):
            return text[:80]
    return None


def annotate_notebook_page(app, html_path):
    output_path = Path(html_path)
    relative_path = output_path.relative_to(Path(app.outdir)).with_suffix(".ipynb")
    notebook_path = Path(app.srcdir) / relative_path
    if not notebook_path.is_file():
        return

    notebook = json.loads(notebook_path.read_text(encoding="utf-8"))
    cells = notebook.get("cells", [])
    if not cells:
        return

    soup = BeautifulSoup(output_path.read_text(encoding="utf-8"), "html.parser")
    rendered_cells = [cell for cell in soup.select("div.cell") if cell.select_one(".cell_input")]
    code_index = 0
    for source_index, source_cell in enumerate(cells):
        if source_cell.get("cell_type") != "code":
            continue
        if code_index >= len(rendered_cells):
            break
        rendered_cell = rendered_cells[code_index]
        code_index += 1
        cell_id = _cell_id(source_cell)
        if cell_id:
            rendered_cell["data-cscs-cell-id"] = str(cell_id)
        rendered_cell["data-cscs-cell-index"] = str(
            notebook["cells"].index(source_cell)
        )
        rendered_cell["data-cscs-cell-type"] = "code"
        classes = rendered_cell.get("class", [])
        if "cscs-code-cell" not in classes:
            classes.append("cscs-code-cell")
        rendered_cell["class"] = classes

    for source_index, source_cell in enumerate(cells):
        if source_cell.get("cell_type") != "markdown":
            continue
        source = source_cell.get("source", "")
        if isinstance(source, list):
            source = "".join(source)
        anchor = _markdown_anchor(source)
        if not anchor:
            continue
        normalized_anchor = " ".join(anchor.split()).lower()
        for candidate in soup.find_all(["h1", "h2", "h3", "h4", "h5", "h6", "p", "li", "blockquote", "td"]):
            candidate_text = " ".join(candidate.get_text(" ", strip=True).split()).lower()
            if normalized_anchor in candidate_text:
                candidate["data-cscs-cell-id"] = str(_cell_id(source_cell) or "")
                candidate["data-cscs-cell-index"] = str(source_index)
                candidate["data-cscs-cell-type"] = "markdown"
                candidate["class"] = [*candidate.get("class", []), "cscs-markdown-cell"]
                break

    output_path.write_text(str(soup), encoding="utf-8")


def on_build_finished(app, exception):
    if exception is not None:
        return
    for html_path in Path(app.outdir).rglob("*.html"):
        annotate_notebook_page(app, html_path)


def setup(app):
    app.connect("build-finished", on_build_finished)
    return {"version": "0.1", "parallel_read_safe": True}
