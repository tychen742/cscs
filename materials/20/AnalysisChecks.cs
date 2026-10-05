using System;
using System.Linq;

var random = new Random(20261005);
for (int trial = 0; trial < 600; trial++)
{
    int n = random.Next(0, 40);
    int[] values = Enumerable.Range(0, n).Select(_ => random.Next(-10, 11)).ToArray();
    long sum = 0, triangular = 0, square = 0;
    for (int i = 0; i < n; i++)
    {
        sum += values[i];
        for (int j = i + 1; j < n; j++) triangular++;
        for (int j = 0; j < n; j++) square++;
    }
    Require(sum == values.Sum(x => (long)x), "sum");
    Require(triangular == (long)n * (n - 1) / 2, "triangular count");
    Require(square == (long)n * n, "square count");
    int target = random.Next(-12, 13);
    Require(FirstIndex(values, target) == Array.IndexOf(values, target), "first match");
    if (n > 0) Require(Max(values) == values.Max(), "maximum");
    int calls = HalvingCalls(n);
    int reductions = 0;
    for (int size = n; size > 1; size /= 2) reductions++;
    Require(calls == reductions + 1, "halving calls");
}
for (int n = 1; n <= 128; n++)
{
    long calls = 0;
    int active = 0, peak = 0;
    long work = Review(n);
    Require(calls == 2L * n - 1, "balanced tree calls");
    Require(peak == (int)Math.Ceiling(Math.Log2(n)) + 1, "peak frames");
    if ((n & (n - 1)) == 0)
        Require(work == n * ((long)Math.Log2(n) + 1), "power-of-two work");
    long Review(int size)
    {
        calls++; active++; peak = Math.Max(peak, active);
        long result = size == 1 ? 1 : Review(size / 2) + Review(size - size / 2) + size;
        active--; return result;
    }
}
Require(Max(new[] { int.MinValue }) == int.MinValue, "extreme singleton");
Require(FirstIndex(Array.Empty<int>(), 5) == -1, "empty search");
try { Max(Array.Empty<int>()); throw new Exception("empty maximum accepted"); }
catch (ArgumentException) { }
try { HalvingCalls(-1); throw new Exception("negative halving accepted"); }
catch (ArgumentOutOfRangeException) { }
Console.WriteLine("600 count/contract cases and 128 recurrence cases plus boundaries passed.");

static void Require(bool condition, string name)
{
    if (!condition) throw new Exception(name);
}
static int Max(int[] values)
{
    if (values is null) throw new ArgumentNullException(nameof(values));
    if (values.Length == 0) throw new ArgumentException("Nonempty input required.");
    int best = values[0];
    for (int i = 1; i < values.Length; i++) if (values[i] > best) best = values[i];
    return best;
}
static int FirstIndex(int[] values, int target)
{
    for (int i = 0; i < values.Length; i++) if (values[i] == target) return i;
    return -1;
}
static int HalvingCalls(int size)
{
    if (size < 0) throw new ArgumentOutOfRangeException(nameof(size));
    return size <= 1 ? 1 : 1 + HalvingCalls(size / 2);
}
