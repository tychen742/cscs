class Order
{
    private readonly List<OrderLine> lines = new List<OrderLine>();
    public int Count { get { return lines.Count; } }
    public decimal Total
    {
        get
        {
            decimal total = 0m;
            foreach (OrderLine line in lines) total += line.LineTotal;
            return total;
        }
    }
    public void Add(Product product, int quantity)
    {
        OrderLine line = new OrderLine(product, quantity);
        lines.Add(line);
    }
    public int CountUnits(string sku)
    {
        int count = 0;
        foreach (OrderLine line in lines)
            if (line.Product.Sku == sku) count += line.Quantity;
        return count;
    }
    public OrderLine[] GetLines() { return lines.ToArray(); }
}
