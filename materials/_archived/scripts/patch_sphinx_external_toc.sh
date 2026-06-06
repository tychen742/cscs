#!/bin/bash
# =============================================================================
# Patch: sphinx-external-toc 1.1.0 — KeyError / UnboundLocalError in collectors.py
#
# Bug:
#   Two bugs in sphinx_external_toc/collectors.py::assign_section_numbers():
#
#   1. Line ~114 (first loop): env.toc_secnumbers[doc][anchor] = ...
#      The outer key `doc` is never guaranteed to exist in toc_secnumbers,
#      causing a KeyError on the master_doc (e.g. 'preface').
#      Fix: use .setdefault(doc, {}) to initialize missing keys.
#
#   2. Line ~141 (second loop): used wrong variable names `doc` and `anchor`
#      (from the first loop's scope) instead of `docname` and `anchorname`,
#      causing an UnboundLocalError when the first loop's body was never entered.
#      Fix: correct variable names to docname/anchorname + setdefault guard.
#
# Affected versions: sphinx-external-toc 1.1.0 (likely earlier versions too)
# Reported: N/A — discovered via build failure in Jupyter Book 1.0.4.post1
#           with Sphinx 7.4.7 and Python 3.13
# =============================================================================

COLLECTORS=".venv/lib/python3.13/site-packages/sphinx_external_toc/collectors.py"

if [ ! -f "$COLLECTORS" ]; then
    echo "ERROR: Cannot find $COLLECTORS"
    echo "Make sure you're in your project root and the venv is set up."
    exit 1
fi

echo "Patching $COLLECTORS ..."

# Fix 1: Add .setdefault(doc, {}) guard in the first loop
sed -i '' \
    's/env\.toc_secnumbers\[doc\]\[anchor\]/env.toc_secnumbers.setdefault(doc, {})[anchor]/' \
    "$COLLECTORS"

# Fix 2: Correct wrong variable names in the second loop + add setdefault guard
sed -i '' \
    's/env\.toc_secnumbers\.setdefault(doc, {})\[anchor\] = copy\.deepcopy(update_secnumber)/env.toc_secnumbers.setdefault(docname, {})[anchorname] = copy.deepcopy(update_secnumber)/' \
    "$COLLECTORS"

# Fix 1 gets caught by Fix 2's sed pattern on second pass, so restore line 114
sed -i '' \
    '114s/setdefault(docname, {})\[anchorname\]/setdefault(doc, {})[anchor]/' \
    "$COLLECTORS"

# Fix 3: __replace_toc method — env.toc_secnumbers[ref] raises KeyError when
#         `ref` (e.g. 'chapters/16-appendix/16-appendix') was never initialized.
#         Fix: use .setdefault(ref, {}) guard.
sed -i '' \
    's/env\.toc_secnumbers\[ref\]\[node\["anchorname"\]\]/env.toc_secnumbers.setdefault(ref, {})[node["anchorname"]]/' \
    "$COLLECTORS"

echo "Verifying patches..."
grep -n "toc_secnumbers.setdefault" "$COLLECTORS"

echo ""
echo "Expected:"
echo "  Line ~114: env.toc_secnumbers.setdefault(doc, {})[anchor] = ..."
echo "  Line ~141: env.toc_secnumbers.setdefault(docname, {})[anchorname] = ..."
echo ""
echo "Done. Try rebuilding with: jbb"
