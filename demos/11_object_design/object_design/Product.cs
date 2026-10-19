class Product
{
    public string Sku { get; }
    public string Name { get; }
    public decimal UnitPrice { get; }

    public Product(string sku, string name, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentException("SKU required.");
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required.");
        if (unitPrice < 0m) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        Sku = sku.Trim();
        Name = name.Trim();
        UnitPrice = unitPrice;
    }
}
