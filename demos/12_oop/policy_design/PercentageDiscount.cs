class PercentageDiscount : IDiscountPolicy
{
    private readonly decimal rate;
    public PercentageDiscount(decimal rate)
    {
        if (rate < 0m || rate > 1m) throw new ArgumentOutOfRangeException(nameof(rate));
        this.rate = rate;
    }
    public decimal Apply(decimal subtotal)
    {
        if (subtotal < 0m) throw new ArgumentOutOfRangeException(nameof(subtotal));
        return subtotal * (1m - rate);
    }
}
