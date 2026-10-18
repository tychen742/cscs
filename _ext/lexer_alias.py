"""
Sphinx extension: register C# highlighting and the Polyglot Notebook alias.

Polyglot Notebooks (VS Code extension) sets language_info.name to
'polyglot-notebook' in notebook metadata. Pygments has no lexer by that name,
causing 'Pygments lexer name not known' warnings during jb build.
This extension also recognizes #nullable directives missing from the bundled
C# lexer, while retaining its remaining rules and Unicode identifier modes.
"""
from pygments.lexers.dotnet import CSharpLexer
from pygments.token import Comment


class BookCSharpLexer(CSharpLexer):
    """Recognize nullable directives used in the standalone teaching cells."""

    _all_tokens = {}
    tokens = {
        level: {
            **states,
            "root": [(r"^[ \t]*#nullable\b[^\n]*", Comment.Preproc), *states["root"]],
        }
        for level, states in CSharpLexer.tokens.items()
    }


def setup(app):
    app.add_lexer("csharp", BookCSharpLexer)
    app.add_lexer("polyglot-notebook", BookCSharpLexer)
    return {"version": "0.2", "parallel_read_safe": True}
