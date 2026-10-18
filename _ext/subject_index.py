"""Normalize lookup entries without changing lesson text or index anchors.

Sphinx's shorthand index argument splits on commas. Book headings and C# generic
names contain literal commas, so interpret each shorthand line as one single
entry instead. Explicit single/pair/triple/see/seealso directives retain their
normal Sphinx semantics.
"""
import re
import json
from pathlib import Path
from sphinx import addnodes
from sphinx.errors import ExtensionError
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
    """Build the reviewed index from unchanged parsed source nodes.

    Read the doctrees, not previously rewritten domain entries, so cached and
    clean builds use the same source inventory and never remap our own output.
    """
    base = Path(__file__).parent
    mapping_path = base / 'subject_index_entries.json'
    additions_path = base / 'subject_index_additions.json'
    mapping = json.loads(mapping_path.read_text())
    additions = json.loads(additions_path.read_text())
    domain = env.get_domain('index')
    output = {}
    unknown = set()
    evidence = []
    for document in sorted(env.found_docs):
        tree = env.get_doctree(document)
        entries = []
        for node in tree.findall(addnodes.index):
            for original in node['entries']:
                for kind, value, target, main, category in normalize_entry(original):
                    key = value.casefold()
                    if kind != 'single' or key not in mapping:
                        unknown.add((document, kind, value))
                        continue
                    for subject in mapping[key]:
                        entries.append(('single', subject, target, main, category))
                    evidence.append((document, target, value))
        output[document] = entries
    if unknown:
        examples = '\n'.join(f'{doc}: {kind}: {value}'
                             for doc, kind, value in sorted(unknown))
        raise ExtensionError('Unreviewed subject-index entries. Review and update '
                             'subject_index_entries.json before publishing:\n' + examples)
    for addition in additions['entries']:
        document, target = addition['document'], addition['target']
        if document not in output:
            raise ExtensionError(f'Unknown index destination: {document}')
        tree = env.get_doctree(document)
        if target not in tree.ids:
            raise ExtensionError(f'Missing index destination: {document}#{target}')
        output[document].append((addition.get('kind', 'single'), addition['value'],
                                 target, '', None))
    # Collapse duplicate pointers within the same actual section, not unrelated
    # passages that happen to share a term. Prefer the stable section anchor.
    collapsed = {}
    for document, entries in output.items():
        tree = env.get_doctree(document)
        seen, clean = set(), []
        for kind, value, target, main, category in entries:
            node = tree.ids.get(target)
            section = node
            while section is not None and section.tagname != 'section':
                section = section.parent
            section_id = section['ids'][0] if section is not None and section['ids'] else target
            key = (kind, value, section_id)
            if key not in seen:
                clean.append((kind, value, target, main, category))
                seen.add(key)
        collapsed[document] = clean
    roots = {value.split(';')[0].strip() for entries in collapsed.values()
             for kind, value, *_ in entries if kind == 'single'}
    for entries in collapsed.values():
        for kind, value, *_ in entries:
            if kind in {'see', 'seealso'}:
                for destination in value.split(';', 1)[1].split(','):
                    if destination.strip() not in roots:
                        raise ExtensionError(f'Unknown index cross-reference: {value}')
    domain.entries.clear()
    domain.entries.update(collapsed)
    LOGGER.info('Reviewed subject index: %s source locations, %s lookup entries, '
                '%s explicit additions/cross-references.', len(evidence),
                sum(map(len, collapsed.values())), len(additions['entries']))
    return ['index']


def setup(app):
    app.add_directive('index', SubjectIndexDirective, override=True)
    app.connect('env-updated', clean_subject_index)
    return {'version': '3.0', 'parallel_read_safe': True, 'parallel_write_safe': True}
