class OrderLine
{
    public Product Product { get; }
    public int Quantity { get; }
    public decimal LineTotal { get { return Product.UnitPrice * Quantity; } }

    public OrderLine(Product product, int quantity)
    {
        if (product is null) throw new ArgumentNullException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        Product = product;
        Quantity = quantity;
    }
}
