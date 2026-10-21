#!/usr/bin/env python3
"""Render lecture sources with the production theme for per-slide visual QA."""
import argparse
from concurrent.futures import ThreadPoolExecutor
import json
from pathlib import Path
import subprocess
from PIL import Image, ImageDraw

ROOT = Path(__file__).resolve().parents[1]

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--chapters', type=int, nargs='*')
    parser.add_argument('--output', type=Path, default=Path('/tmp/cscs_slide_render'))
    parser.add_argument('--browser-path', default='/Applications/Google Chrome.app/Contents/MacOS/Google Chrome')
    parser.add_argument('--jobs', type=int, default=2)
    args = parser.parse_args()
    args.output.mkdir(parents=True, exist_ok=True)
    sources = sorted((ROOT/'_html_extra/chapters').glob('*/*_slides.md'))
    if args.chapters:
        sources = [p for p in sources if int(p.name[:2]) in args.chapters]
    def render(source):
        folder = args.output/source.stem
        folder.mkdir(exist_ok=True)
        command = [str(ROOT/'scripts/slides/node_modules/.bin/marp'), str(source), '--html', '--allow-local-files', '--images', 'png', '--image-scale', '0.5', '--browser', 'chrome', '--browser-path', args.browser_path, '--browser-timeout', '60', '--theme-set', str(ROOT/'scripts/slides/thinkpress-lecture.css'), '--output', str(folder/'slide.png')]
        result = subprocess.run(command, cwd=ROOT, capture_output=True, text=True, timeout=240)
        (folder/'render.log').write_text(result.stdout+result.stderr)
        files = sorted(folder.glob('slide.*.png'))
        sheets = []
        for start in range(0, len(files), 4):
            sheet = Image.new('RGB', (1280, 768), '#d0d0d0')
            draw = ImageDraw.Draw(sheet)
            for k, file in enumerate(files[start:start+4]):
                x, y = (k % 2)*640, (k//2)*384
                draw.text((x+8,y+4), f'{source.stem}: slide {start+k+1}', fill='black')
                with Image.open(file) as im:
                    sheet.paste(im.convert('RGB'), (x,y+24))
            target = folder/f'contact_{start//4+1:02}.png'
            sheet.save(target)
            sheets.append(str(target))
        print(f'{source.stem}: {len(files)} rendered slides', flush=True)
        return {'source': str(source.relative_to(ROOT)), 'exit_code': result.returncode, 'rendered_slides': len(files), 'contact_sheets': sheets}
    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        results = list(pool.map(render, sources))
    (args.output/'render_results.json').write_text(json.dumps(results, indent=2)+'\n')
    raise SystemExit(any(r['exit_code'] for r in results))

if __name__ == '__main__':
    main()
