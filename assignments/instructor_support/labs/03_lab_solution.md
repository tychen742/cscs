# Instructor Solution Walkthrough: Product Code Report

**Exact assignment:** the Product Code Report task in [Chapter 3 lab](../../../chapters/03-methods/assignments/lab.ipynb).

**Completed method reference:** [sku_report_lab_solution.cs](../../../materials/03/sku_report_lab_solution.cs).

From the repository root:

```bash
dotnet run --project materials/03/sku_report_lab_solution.csproj
```

## Explain the Four Methods

`NormalizeSku` trims the ends and uppercases the result. `SkuCategory` locates
the first hyphen and returns the prefix. `SkuNumber` starts one position after
that hyphen and reads four characters. `ReportLine` cleans the input once and
calls the other methods to assemble one line.

Trace `"  elec-1042-blk "`: normalization produces `ELEC-1042-BLK`; the first
hyphen is at index 4; the category is `ELEC`, and four characters starting at
index 5 yield `1042`. The item number remains text, preserving leading zeros.

## Assess the Submission

Check the four methods, the required delegation from `ReportLine`, and all
three supplied output lines. The reference supplies those methods and sample
runs. Students must additionally supply their own fourth call with extra spaces
and lowercase input, plus the requested explanatory comment and screenshot.
Do not mark a submission complete solely because it reproduces the reference file.

A good explanation says that calling helpers keeps each operation in one place,
so changing extraction behavior does not require editing multiple copies.
Accept equivalent implementations satisfying the task. No fixed points scheme
is specified here. The task assumes the supplied SKU format; malformed-code
validation is an extension rather than an unstated grading requirement.

## Common Mistakes

`Trim` does not remove internal spaces. `Substring(start, length)` takes a
length, not an ending index. Omitting the `+ 1` includes the hyphen. Parsing the
item as an integer loses its leading zeros. Calling the extraction methods on
raw, unnormalized input can produce inconsistent output.

## Verified Output

```text
ELEC-1042-BLK: category ELEC, item 1042
OFFC-2210-WHT: category OFFC, item 2210
FURN-0307-OAK: category FURN, item 0307
```
