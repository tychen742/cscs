"""
Sphinx extension: register 'polyglot-notebook' as a Pygments alias for C#.

Polyglot Notebooks (VS Code extension) sets language_info.name to
'polyglot-notebook' in notebook metadata. Pygments has no lexer by that name,
causing 'Pygments lexer name not known' warnings during jb build.
This extension maps the alias to the built-in CSharpLexer at Sphinx startup.
"""
from pygments.lexers.dotnet import CSharpLexer


def setup(app):
    app.add_lexer("polyglot-notebook", CSharpLexer)
    return {"version": "0.1", "parallel_read_safe": True}
