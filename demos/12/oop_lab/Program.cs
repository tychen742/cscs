using IntroCSCS;

internal class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(100m);
        account.Deposit(50m);
        account.Withdraw(25m);
        Console.WriteLine($"Final balance: {account.GetBalance()}");
    }
}
