class Checkout
{
    private readonly IDiscountPolicy discount;
    public Checkout(IDiscountPolicy discount)
    {
        if (discount is null) throw new ArgumentNullException(nameof(discount));
        this.discount = discount;
    }
    public decimal Quote(decimal subtotal) { return discount.Apply(subtotal); }
}
