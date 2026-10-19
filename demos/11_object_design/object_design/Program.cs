Product product = new Product("P100", "Notebook", 6m);
Order first = new Order();
if (!args.Contains("--check"))
{
    first.Add(product, 2);
    first.Add(new Product("P200", "Pen", 2m), 3);
    Console.WriteLine($"{first.Count} lines, total {first.Total:F2}");
    return;
}
int checks = 0;
Check(first.Count == 0 && first.Total == 0m, "empty order");
first.Add(product, 2);
Check(first.Count == 1 && first.Total == 12m, "first line");
first.Add(product, 3);
Check(first.Count == 2 && first.Total == 30m, "repeated line");
Check(first.CountUnits("P100") == 5, "unit count");
Check(first.CountUnits("missing") == 0, "missing SKU");
Check(first.CountUnits("p100") == 0, "case-sensitive SKU");
Order second = new Order();
second.Add(product, 1);
Check(second.Total == 6m && first.Total == 30m, "independent orders");
OrderLine[] snapshot = first.GetLines();
snapshot[0] = new OrderLine(product, 99);
Check(first.Total == 30m, "snapshot storage");
Check(!ReferenceEquals(product, new Product("P100", "Notebook", 6m)), "distinct identity");
foreach (Action invalid in new Action[] {
    () => new Product(" ", "Notebook", 6m),
    () => new Product("P100", " ", 6m),
    () => new Product("P100", "Notebook", -1m),
    () => first.Add(product, 0),
    () => first.Add(product, -1),
    () => first.Add(null!, 1) })
{
    bool rejected = false;
    try { invalid(); } catch (ArgumentException) { rejected = true; }
    Check(rejected, "invalid input rejected");
    Check(first.Count == 2 && first.Total == 30m, "rejection preserves state");
}
Console.WriteLine($"{checks} object-design checks passed.");
void Check(bool valid, string message)
{
    if (!valid) throw new Exception(message);
    checks++;
}
