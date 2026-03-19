import json, uuid

def new_id():
    return uuid.uuid4().hex[:8]

def md(source):
    return {"cell_type": "markdown", "id": new_id(), "metadata": {}, "source": source}

def code(source):
    return {"cell_type": "code", "id": new_id(), "metadata": {}, "outputs": [], "execution_count": None, "source": source}

nb_path = "chapters/02-var_data/0203-operators.ipynb"
with open(nb_path) as f:
    nb = json.load(f)

old = nb["cells"]
# old[0]=intro, old[1]=summary, old[2]=detailed,
# old[3]=assignment code (x++), old[4]=comparison code, old[5]=logical code,
# old[6..13]=Division section, old[14..15]=Remainders, old[16..18]=Exercise

new_cells = [
    old[0],  # # Operators intro
    old[1],  # summary table
    old[2],  # detailed table
    md("## Operation Examples\n"),
    md("### Assignment\n\nThe `=` operator assigns a value. Compound assignment operators (`+=`, `-=`, etc.) combine an operation with assignment. The `++` and `--` operators increment or decrement by 1:\n"),
    old[3],  # x = 1; x++; ++x code
    md("### Arithmetic\n\nBasic arithmetic operations:\n"),
    code("int a = 10, b = 3;\na + b   // addition\na - b   // subtraction\na * b   // multiplication\na / b   // integer division (truncates)\na % b   // remainder"),
    md("### Comparison\n\nComparison operators return a `bool` (`true` or `false`):\n"),
    old[4],  # int x = 1, y = 2; x == y; x < y; x <= y
    md("### Logical\n\nLogical operators combine or invert `bool` expressions:\n"),
    old[5],  # x < 5 && x < 10; x < 5 || x < 10; !(...)
    md("### Bitwise\n\nBitwise operators work directly on the binary representation of integers:\n"),
    code("int x = 5, y = 3;\nx & y    // Bitwise AND:  0101 & 0011 = 0001 → 1\nx | y    // Bitwise OR:   0101 | 0011 = 0111 → 7\nx ^ y    // Bitwise XOR:  0101 ^ 0011 = 0110 → 6\n~x       // Bitwise NOT:           ~0101 = ...11111010 → -6\nx << 1   // Left shift:   0101 << 1 = 1010 → 10\nx >> 1   // Right shift:  0101 >> 1 = 0010 → 2"),
] + old[6:]  # ## Division, ## Remainders, ## Exercise unchanged

nb["cells"] = new_cells

with open(nb_path, "w") as f:
    json.dump(nb, f, indent=1, ensure_ascii=False)

print(f"Done. Total cells: {len(new_cells)}")
for i, c in enumerate(new_cells):
    src = "".join(c["source"])[:70].replace("\n", " ")
    print(f"  [{i}] {c['cell_type']}: {src}")
