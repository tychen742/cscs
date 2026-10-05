"""Generate the Think C# cover art: a seeded pattern of rounded squares in the
book's accent ramp, denser toward the upper right, with a '#' formed by the
darkest squares. Run: python3 materials/cover/make_cover_art.py"""
import random
from pathlib import Path

W, H, CELL, GAP = 600, 800, 40, 8
COLS, ROWS = W // CELL, H // CELL                     # 15 x 20
BG = "#EEEDFE"                                        # lightest purple
SHADES = ["#CECBF6", "#AFA9EC", "#7F77DD", "#534AB7", "#3C3489"]
GLYPH = "#26215C"                                     # darkest purple, used for the '#'
random.seed(2026)

def in_hash(c, r):
    """True if cell (c, r) belongs to the '#' glyph, centered at column 7, row 12."""
    x, y = c - 7, r - 12
    vertical = x in (-2, 2) and -4 <= y <= 4
    horizontal = y in (-2, 2) and -4 <= x <= 4
    return vertical or horizontal

def near_hash(c, r):
    """Cells touching the glyph stay empty so its outline reads clearly."""
    return not in_hash(c, r) and any(in_hash(c + dc, r + dr) for dc in (-1, 0, 1) for dr in (-1, 0, 1))

cells = []
for r in range(ROWS):
    for c in range(COLS):
        t = (c / (COLS - 1) + (ROWS - 1 - r) / (ROWS - 1)) / 2   # 0 lower left .. 1 upper right
        x, y = c * CELL + GAP / 2, r * CELL + GAP / 2
        size = CELL - GAP
        if in_hash(c, r):
            cells.append((x, y, size, GLYPH))
        elif near_hash(c, r):
            continue
        elif random.random() < 0.18 + t * 0.62:
            k = min(len(SHADES) - 1, int(t * 3.6 + random.random() * 1.3))
            cells.append((x, y, size, SHADES[k]))

svg = [f'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 {W} {H}" width="{W}" height="{H}" role="img" '
       f'aria-label="Cover art: a pattern of purple squares, denser toward the upper right, with a hash sign formed by the darkest squares">',
       f'  <rect width="{W}" height="{H}" fill="{BG}"/>']
svg += [f'  <rect x="{x:g}" y="{y:g}" width="{s:g}" height="{s:g}" rx="6" fill="{f}"/>' for x, y, s, f in cells]
svg.append("</svg>")
out = Path(__file__).resolve().parents[2] / "figures" / "cover-art.svg"
out.write_text("\n".join(svg) + "\n")
print(f"wrote {out} with {len(cells)} squares")
