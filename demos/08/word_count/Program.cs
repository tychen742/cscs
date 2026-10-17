using System;
using System.Collections.Generic;

HashSet<string> ignored = new HashSet<string> { "a", "an", "and", "the" };
Dictionary<string, int> counts = GetCounts("The pen, pen and book!", ignored);
PrintCounts(counts, 1);
Console.WriteLine($"Distinct counted words: {counts.Count}");

static Dictionary<string, int> GetCounts(string s, HashSet<string> ignore)
{
    char[] sep = "\n\t !@#$%^&*()_+{}|[]\\:\";<>?,./".ToCharArray();
    string[] words = s.ToLowerInvariant().Split(sep);
    ignore.Add("");
    var wc = new Dictionary<string, int>();
    foreach (string w in words)
    {
        if (!ignore.Contains(w))
        {
            if (wc.ContainsKey(w)) wc[w]++;
            else wc[w] = 1;
        }
    }
    return wc;
}

static void PrintCounts(Dictionary<string, int> wc, int minCount)
{
    List<string> words = new List<string>(wc.Keys);
    words.Sort(StringComparer.Ordinal);
    foreach (string w in words)
        if (wc[w] >= minCount) Console.WriteLine($"{w}: {wc[w]}");
}
