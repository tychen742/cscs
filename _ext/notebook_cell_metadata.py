"""Annotate rendered notebook cells with stable source metadata."""

import json
from pathlib import Path

from bs4 import BeautifulSoup
import re


def _cell_id(cell):
    metadata = cell.get("metadata", {}) or {}
    return cell.get("id") or metadata.get("id")


def _markdown_anchor(source):
    for line in source.splitlines():
        raw = line.strip()
        if (
            not raw
            or raw.startswith(("::", "(", "```", ".. ", ":", "---", "<", "<!--"))
            or raw.endswith(("=", "-"))
        ):
            continue
        if raw.startswith("#"):
            raw = re.sub(r"^#+\s*", "", raw)
        text = re.sub(r"[`*_]", "", raw).strip()
        if text:
            return text[:80]
    return None


def _is_inside(node, selector):
    if selector == "nav":
        return node.find_parent("nav") is not None
    if selector == "div.cell":
        return any(parent.name == "div" and "cell" in parent.get("class", []) for parent in node.parents)
    return node.find_parent(selector) is not None


def _document_nodes(article):
    nodes = []
    for node in article.find_all(["h1", "h2", "h3", "h4", "h5", "h6", "p", "ul", "ol", "table", "blockquote", "div"]):
        if _is_inside(node, "nav"):
            continue
        classes = node.get("class", [])
        if node.name == "div" and "cell" not in classes:
            continue
        nodes.append(node)
    return nodes


def _apply_markdown_metadata(node, source_cell, source_index):
    node["data-cscs-cell-id"] = str(_cell_id(source_cell) or "")
    node["data-cscs-cell-index"] = str(source_index)
    node["data-cscs-cell-type"] = "markdown"
    classes = node.get("class", [])
    if "cscs-markdown-cell" not in classes:
        classes.append("cscs-markdown-cell")
    node["class"] = classes


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
    article = soup.select_one("article.bd-article") or soup
    rendered_cells = [cell for cell in article.select("div.cell") if cell.select_one(".cell_input")]
    code_markers = {}
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
        code_markers[source_index] = rendered_cell

    nodes = _document_nodes(article)
    node_positions = {id(node): index for index, node in enumerate(nodes)}
    markers = []
    last_marker_position = -1
    for source_index, source_cell in enumerate(cells):
        if source_cell.get("cell_type") == "code":
            rendered_cell = code_markers.get(source_index)
            if rendered_cell is not None and id(rendered_cell) in node_positions:
                position = node_positions[id(rendered_cell)]
                if position > last_marker_position:
                    markers.append((position, source_index, "code", rendered_cell))
                    last_marker_position = position
            continue

        if source_cell.get("cell_type") != "markdown":
            continue
        source = source_cell.get("source", "")
        if isinstance(source, list):
            source = "".join(source)
        anchor = _markdown_anchor(source)
        if not anchor:
            continue
        normalized_anchor = " ".join(anchor.split()).lower()
        for candidate in article.find_all(["h1", "h2", "h3", "h4", "h5", "h6", "p", "li", "blockquote", "td"]):
            if _is_inside(candidate, "nav") or _is_inside(candidate, "div.cell"):
                continue
            candidate_text = " ".join(candidate.get_text(" ", strip=True).split()).lower()
            if normalized_anchor in candidate_text:
                node = candidate
                while id(node) not in node_positions and node.parent is not None:
                    node = node.parent
                if id(node) in node_positions:
                    position = node_positions[id(node)]
                    if position > last_marker_position:
                        markers.append((position, source_index, "markdown", node))
                        last_marker_position = position
                        break

    markers.sort(key=lambda item: item[0])
    marked_source_indices = {source_index for _, source_index, _, _ in markers}
    anchored_markdown_indices = set()
    for source_index, source_cell in enumerate(cells):
        if source_cell.get("cell_type") != "markdown":
            continue
        source = source_cell.get("source", "")
        if isinstance(source, list):
            source = "".join(source)
        if _markdown_anchor(source):
            anchored_markdown_indices.add(source_index)

    for marker_index, (start, source_index, cell_type, node) in enumerate(markers):
        if cell_type != "markdown":
            continue
        source_cell = cells[source_index]
        next_marker = markers[marker_index + 1] if marker_index + 1 < len(markers) else None
        end = next_marker[0] if next_marker is not None else len(nodes)
        next_source_index = next_marker[1] if next_marker is not None else len(cells)
        missed_markdown_indices = [
            index for index in anchored_markdown_indices
            if source_index < index < next_source_index and index not in marked_source_indices
        ]
        if missed_markdown_indices:
            # When a later markdown cell could not be anchored in the rendered
            # HTML, do not let the previous cell claim the intervening page.
            # The browser authoring UI can still edit the matched anchor block,
            # but it will not hide or overwrite unrelated rendered cells.
            end = start + 1
        for block in nodes[start:end]:
            if block.name == "div" and "cell" in block.get("class", []):
                break
            if _is_inside(block, "div.cell"):
                continue
            _apply_markdown_metadata(block, source_cell, source_index)

    output_path.write_text(str(soup), encoding="utf-8")


def on_build_finished(app, exception):
    if exception is not None:
        return
    for html_path in Path(app.outdir).rglob("*.html"):
        annotate_notebook_page(app, html_path)


def setup(app):
    app.connect("build-finished", on_build_finished)
    return {"version": "0.1", "parallel_read_safe": True}
