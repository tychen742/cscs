class NoDiscount : IDiscountPolicy
{
    public decimal Apply(decimal subtotal)
    {
        if (subtotal < 0m) throw new ArgumentOutOfRangeException(nameof(subtotal));
        return subtotal;
    }
}
