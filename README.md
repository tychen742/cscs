Introduction to Computer Science in C\#
===========================================

<!-- Build Status
------------- -->

<!-- [![GitHub Pages and Release PDF](https://github.com/LoyolaChicagoBooks/introcs-csharp/actions/workflows/main.yml/badge.svg)](https://github.com/LoyolaChicagoBooks/introcs-csharp/actions/workflows/main.yml) -->

<!-- Viewing and Downloading
--------------------------- -->


<!-- Building the Book
--------------------

More details to follow... -->

```
$ pip install -r requirements.txt
$ ./bin/get-code-examples.sh && make html latexpdf
$ make html
```

Notes
-----
- Sphinx 5.3.0 + python3.10 work ==> on production Sphinx is 8.02
- After installing sphinx_rtd_theme, Sphinx 8.02 is uninstalled and 7.4.7 is installed and:
"Successfully installed 
    alabaster-0.7.16 
    docutils-0.20.1 
    sphinx-7.4.7 
    sphinx-rtd-theme-2.0.0 
    sphinxcontrib-jquery-4.1
    
- pip install sphinx_rtd_theme
- pip install sphinx_tabs
- ??? pip install docutils==0.16 ==> 
- ??? conf.py: extensions = ['sphinx_tabs.tabs']
- Esbonio v0.11.0 by Swyddfa for live preview in vscode (included in reStructuredText v190.4.1 by LeXtudio)
