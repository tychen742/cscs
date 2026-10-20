# Word-count worked example

**Inventory role:** Demo. Dictionary word counts with an ignore set and sorted reporting.

Companion to Chapter 8 Dictionaries. Uses a short traceable input, an ignore set, a counting dictionary, and a sorted key list.

Run: `dotnet run --project demos/08_collections/word_count/word_count.csproj` from the book root.

Expected output:

```text
book: 1
pen: 2
Distinct counted words: 2
```

Try empty input, ignored-only input, repeated mixed-case words, and a reporting threshold of 2. GetCounts deliberately preserves the original example's side effect of adding the empty string to the ignore set.
