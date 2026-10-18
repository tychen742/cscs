"""Normalize lookup entries without changing lesson text or index anchors.

Sphinx's shorthand index argument splits on commas. Book headings and C# generic
names contain literal commas, so interpret each shorthand line as one single
entry instead. Explicit single/pair/triple/see/seealso directives retain their
normal Sphinx semantics.
"""
import re
from sphinx.domains.index import IndexDirective
from sphinx.util import logging

LOGGER = logging.getLogger(__name__)
NUMBERED_TASK = re.compile(r'^\d+[.)]\s+')
EXPLICIT_TYPE = re.compile(r'^(?:single|pair|triple|see|seealso):\s*')
BOILERPLATE = {
    'summary', 'overview', 'introduction', 'exercise', 'practice',
    'multiple choice', 'true or false', 'coding practice', 'coding questions',
    'concept questions', 'review questions', 'submit', 'lab submission',
    'homework submission', 'deliverable and submission', 'project connection',
    'initial practice', 'independent coding practice', 'check your application',
    'check your explanations', 'prepare the solution', 'prepare application code',
    'prepare tests', 'run in vs code', 'set up and run', 'implement and run',
    'integrate and verify', 'verify before extending',
}
REPAIRS = {
    '1D Arrays': 'array; one-dimensional',
    'array; one dimensional': 'array; one-dimensional',
    'array; two dimensional two dimensional array': 'array; two-dimensional',
    'string; Split Split method for strings': 'string; Split',
    'StreamReader; EndOfStream EndOfStream': 'StreamReader; EndOfStream',
    'StreamWriter; format string StreamWriter; Write': 'StreamWriter; formatted output',
    'class; Rational Rational class': 'class; Rational',
    'loop; for for': 'loop; for',
    'statement; if if': 'statement; if',
    'collections, data collections': 'collections',
    'tuple; destructuring, discard': 'tuple; destructuring; discard',
    'string; Contains, string': 'string; Contains',
    'string; Contains, string; IndexOf, string; StartsWith': 'string; Contains; IndexOf; StartsWith',
    'string; Length, string; indexing': 'string; Length; indexing',
    'string; Trim, string; ToUpper, string; ToLower': 'string; Trim; ToUpper; ToLower',
    'string; IndexOf, string': 'string; IndexOf',
    'string; Length, string': 'string; Length',
    'string; ToUpper, string': 'string; ToUpper',
    'string; Trim, string': 'string; Trim',
    'escape code; \\g<2>': 'escape sequence',
}


class SubjectIndexDirective(IndexDirective):
    def run(self):
        self.arguments[0] = '\n'.join(
            line if EXPLICIT_TYPE.match(line.strip()) else 'single: ' + line
            for line in self.arguments[0].split('\n')
        )
        return super().run()


def normalize_entry(entry):
    kind, value, target, main, category = entry
    if kind != 'single':
        return [entry]
    value = value.strip().replace('\\#', '#')
    if NUMBERED_TASK.match(value) or value.casefold() in BOILERPLATE:
        return []
    value = REPAIRS.get(value, value)
    parts = [part.strip() for part in value.split(';') if part.strip()]
    if len(parts) == 2 and parts[1].casefold() == 'summary':
        return []
    if value == '.NET; SDK; runtime; dotnet --version':
        values = ['.NET; SDK', '.NET; runtime', 'dotnet --version']
    elif parts and parts[0] in {'Add', 'Count', 'pwd'} and len(parts) > 2:
        values = parts
    elif len(parts) > 2:
        # Semicolons describe main term / subentry, not an unlimited hierarchy.
        values = [parts[0] + '; ' + child for child in parts[1:]]
    else:
        values = ['; '.join(parts)]
    return [(kind, term, target, main, category) for term in values]


def clean_subject_index(app, env):
    domain = env.get_domain('index')
    canonical = {}
    prepared = {}
    suppressed = normalized = 0
    for document, entries in domain.entries.items():
        prepared[document] = []
        for entry in entries:
            result = normalize_entry(entry)
            suppressed += not result
            normalized += bool(result and result != [entry])
            prepared[document].extend(result)
            for kind, value, *_ in result:
                # Merge capitalization variants only where both already exist.
                # Prefer the lowercase subject term; preserve API capitalization.
                for part in value.split(';'):
                    part = part.strip()
                    key = (kind, part.casefold())
                    if key not in canonical or part == part.lower():
                        canonical[key] = part
    for document, entries in prepared.items():
        cleaned, seen = [], set()
        for kind, value, target, main, category in entries:
            value = '; '.join(canonical[(kind, part.strip().casefold())]
                              for part in value.split(';'))
            item = (kind, value, target, main, category)
            if item not in seen:
                cleaned.append(item)
                seen.add(item)
        domain.entries[document] = cleaned
    LOGGER.info('Subject index: omitted %s task/boilerplate entries; normalized %s entries.',
                suppressed, normalized)
    # Rebuild one ordinary document so Sphinx also regenerates genindex when
    # only this extension has changed and no notebook needs rereading.
    return ['index']


def setup(app):
    app.add_directive('index', SubjectIndexDirective, override=True)
    app.connect('env-updated', clean_subject_index)
    return {'version': '2.0', 'parallel_read_safe': True, 'parallel_write_safe': True}
