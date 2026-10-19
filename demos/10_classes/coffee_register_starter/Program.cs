// Exercise: 5. Print a Shift Report with ToString
using System;
using System.Collections.Generic;

CashRegister front = new CashRegister("Front", "Avery");
CashRegister driveThru = new CashRegister("Drive-thru", "Sam");

front.Checkout(new decimal[] { 4.50m, 4.50m, 12.00m });
driveThru.Checkout(new decimal[] { 3.25m });
CashRegister.TaxRate = 0.07m;
front.Checkout(new decimal[] { 2.75m, 6.00m });
driveThru.Checkout(new decimal[] { 9.80m, 1.20m });

List<CashRegister> registers = new List<CashRegister> { front, driveThru };
decimal storeTotal = 0m;

Console.WriteLine("Shift report");
foreach (CashRegister register in registers)
{
    Console.WriteLine(register);
    storeTotal += register.Total;
}
Console.WriteLine($"Store total: {CashRegister.Money(storeTotal)}");

class CashRegister
{
    private static int nextReceiptNumber = 1001;   // shared by all registers

    public static decimal TaxRate { get; set; } = 0.08m;

    public static string Money(decimal amount)
    {
        return "$" + amount.ToString("F2");
    }

    private string name;
    private string cashier = "";
    private decimal total;
    private int receiptCount;

    public CashRegister(string name, string cashier)
    {
        this.name = name;
        Cashier = cashier;
        total = 0m;
        receiptCount = 0;
    }

    public string Name
    {
        get { return name; }
    }

    public decimal Total
    {
        get { return total; }
    }

    public int ReceiptCount
    {
        get { return receiptCount; }
    }

    public string Cashier
    {
        get { return cashier; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Cashier name cannot be blank.");
            }
            cashier = value.Trim();
        }
    }

    public void Checkout(decimal[] prices)
    {
        decimal subtotal = 0m;
        foreach (decimal price in prices)
        {
            subtotal += price;
        }

        decimal tax = Math.Round(subtotal * TaxRate, 2);
        decimal amountDue = subtotal + tax;

        int receipt = nextReceiptNumber;
        nextReceiptNumber++;

        total += amountDue;
        receiptCount++;

        Console.WriteLine($"Receipt {receipt} ({name}, {cashier}): {Money(subtotal)} + tax {Money(tax)} = {Money(amountDue)}");
    }

    public override string ToString()
    {
        string summary = "";

        // Your code starts here.



        // Your code ends here.

        return summary;
    }
}
