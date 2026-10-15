int checks = 0;
foreach (int[] input in new[] { Array.Empty<int>(), new[]{1}, new[]{4,2,2,-1}, new[]{5,4,3,2,1}, new[]{1,2,3,4,5} })
{
    int[] actual = (int[])input.Clone();
    int[] expected = (int[])input.Clone();
    Array.Sort(expected);
    BasicSort.InsertionSort(actual, Comparer<int>.Default);
    Check(actual.Length == expected.Length, "length");
    for (int i = 0; i < actual.Length; i++) Check(actual[i] == expected[i], "sorted occurrence");
    foreach (int target in new[]{-1,1,2,5,99})
    {
        int found = BasicSearch.BinaryAny(actual, target, Comparer<int>.Default);
        Check(found < 0 ? Array.IndexOf(actual, target) < 0 : actual[found] == target, "binary result");
        Check(BasicSearch.LinearFirst(input, target, EqualityComparer<int>.Default) == Array.IndexOf(input, target), "first match");
    }
}
var random = new Random(1701);
for (int trial = 0; trial < 100; trial++)
{
    int[] values = new int[random.Next(0,20)];
    for (int i=0;i<values.Length;i++) values[i]=random.Next(-10,11);
    int[] expected=(int[])values.Clone();Array.Sort(expected);
    BasicSort.InsertionSort(values,Comparer<int>.Default);
    for(int i=0;i<values.Length;i++) Check(values[i]==expected[i],"random sorted occurrences");
}
(int Amount, string Id)[] invoices = { (30, "A"), (10, "B"), (30, "C"), (30, "D") };
IComparer<(int Amount, string Id)> amountOrder = Comparer<(int Amount, string Id)>.Create((left, right) => left.Amount.CompareTo(right.Amount));
BasicSort.InsertionSort(invoices, amountOrder);
Check(invoices[1].Id == "A", "first equal-key arrival");
Check(invoices[2].Id == "C", "second equal-key arrival");
Check(invoices[3].Id == "D", "third equal-key arrival");
int[] descending = { 1, 3, 2 };
IComparer<int> reverseOrder = Comparer<int>.Create((left, right) => right.CompareTo(left));
BasicSort.InsertionSort(descending, reverseOrder);
Check(string.Join(",", descending) == "3,2,1" && BasicSearch.BinaryAny(descending, 2, reverseOrder) == 1, "consistent descending policy");
Console.WriteLine($"{checks} search/sort checks passed.");
void Check(bool valid,string message) { if(!valid)throw new Exception(message);checks++; }
