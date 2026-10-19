Checkout member = new Checkout(new PercentageDiscount(0.10m));
if (!args.Contains("--check"))
{
    Console.WriteLine($"Member quote: {member.Quote(100m):F2}");
    return;
}
int checks = 0;
Check(member.Quote(100m) == 90m, "percentage quote");
Check(new Checkout(new NoDiscount()).Quote(100m) == 100m, "no discount");
Check(new Checkout(new PercentageDiscount(1m)).Quote(10m) == 0m, "full reduction");
DiscountPolicy fixedPolicy = new FixedDiscount(5m);
Check(fixedPolicy.Apply(20m) == 15m, "base reference override");
Check(fixedPolicy.Apply(3m) == 0m, "zero floor");
foreach (IDiscountPolicy policy in new IDiscountPolicy[] {new NoDiscount(), new PercentageDiscount(0.10m)})
{
    Check(policy.Apply(0m) == 0m, "zero input");
    bool rejected = false;
    try { policy.Apply(-1m); } catch (ArgumentOutOfRangeException) { rejected = true; }
    Check(rejected, "negative input");
}
foreach (Action invalid in new Action[] {
    () => new PercentageDiscount(-0.1m), () => new PercentageDiscount(1.1m),
    () => new FixedDiscount(-1m), () => new Checkout(null!) })
{
    bool rejected = false;
    try { invalid(); } catch (ArgumentException) { rejected = true; }
    Check(rejected, "invalid collaborator or configuration");
}
Console.WriteLine($"{checks} policy checks passed.");
void Check(bool valid, string message)
{
    if (!valid) throw new Exception(message);
    checks++;
}
