# Instructor Solution Walkthrough: Chapter 8 Sales Lab

**Exact assignment:** [current Chapter 8 lab](../../chapters/08_arrays/assignments/lab.ipynb).

**Canonical answers:** the five `hide-input` cells in that notebook. Each answer
was compiled and run independently with .NET 10. The older
[`demos/08/array_lab/`](../../demos/08/array_lab/README.md) is a
supplementary completed exercise and is not this lab's answer key.

To reproduce an answer in VS Code, create a temporary console project, replace
`Program.cs` with that answer cell's complete source, save, and run `dotnet run`.
These answers use top-level statements; replace an explicit-Main template
rather than appending them after its class.

The checkpoints below are grading guidance, not a prescribed points scheme.
Accept equivalent correct implementations that satisfy the task's stated contract.

## Task 1: Print a Week of Sales

Answer cell ID: `lab08_003`; zero-based cell index at verification: 3.

PrintSales writes the label once, then prefixes each amount with a space and finally writes a newline. Write versus WriteLine determines whether values share one line.

**Assessment checkpoints:** Check both branch labels, the complete values, and one line per branch; equivalent loop styles are acceptable.

Verified output:

```text
Downtown: 1200 950 1100 1300 1650 2100 1800
Airport: 800 870 900 950 1020 1100 1250
```

## Task 2: Summarize the Week

Answer cell ID: `lab08_006`; zero-based cell index at verification: 6.

Total accumulates all values. LowestDay keeps an index and compares values at that index. Casting total to double before division avoids integer truncation.

**Assessment checkpoints:** Check total, two-decimal average, and the day/index correspondence. With equal minima, the reference retains the first index because it uses <.

Verified output:

```text
Weekly total: 10100
Daily average: 1442.86
Lowest day: Tue (950)
```

## Task 3: Check the Target and the Trend

Answer cell ID: `lab08_009`; zero-based cell index at verification: 9.

CountAtLeast includes the threshold via >=. IsAscending rejects the first descending adjacent pair and allows equal consecutive values.

**Assessment checkpoints:** Check exact-threshold, equal-pair, empty, and single-element cases. Do not equate ascending with strictly increasing.

Verified output:

```text
Downtown days at or above 1000: 6
Airport days at or above 1000: 3
Downtown grew every day: False
Airport grew every day: True
```

## Task 4: Combine Two Branches

Answer cell ID: `lab08_012`; zero-based cell index at verification: 12.

Allocate a new array and write pairwise sums into it; both original branch arrays remain unchanged.

**Assessment checkpoints:** Check all seven sums and unchanged inputs. Returning or modifying an input array violates the NEW-array requirement.

Verified output:

```text
Downtown: 1200 950 1100 1300 1650 2100 1800
Airport: 800 870 900 950 1020 1100 1250
Combined: 2000 1820 2000 2250 2670 3200 3050
Downtown still starts with: 1200
```

## Task 5: Build a Branch-by-Day Report

Answer cell ID: `lab08_015`; zero-based cell index at verification: 15.

A row loop with an inner column loop totals each branch; the reversed nesting totals each day. The maximum tracks both the total and its branch index.

**Assessment checkpoints:** Check all three branch totals, seven day totals, and the top branch. Reset the accumulator at the correct outer-loop scope. The supplied business data is nonnegative; do not claim the reference maximum initialization handles arbitrary negative datasets.

Verified output:

```text
Branch totals:
  Downtown: 10100
  Airport: 6890
  Campus: 7900
Day totals:
  Mon: 3500
  Tue: 3270
  Wed: 3400
  Thu: 3600
  Fri: 3570
  Sat: 3800
  Sun: 3750
Top branch: Downtown (10100)
```
