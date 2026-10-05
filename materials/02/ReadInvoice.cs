using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

Console.Write("Quantity (whole number, 0 to 100): ");
string quantityText = Console.ReadLine() ?? "";
int quantity = int.Parse(quantityText);
Console.WriteLine();
decimal unitPrice = 38.50m;
decimal subtotal = quantity * unitPrice;
decimal tax = Math.Round(subtotal * 0.07m, 2, MidpointRounding.AwayFromZero);
decimal total = subtotal + tax;
Console.WriteLine($"Total: {total:F2} USD");
