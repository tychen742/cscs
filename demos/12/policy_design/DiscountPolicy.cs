class DiscountPolicy
{
    public virtual decimal Apply(decimal subtotal)
    {
        if (subtotal < 0m) throw new ArgumentOutOfRangeException(nameof(subtotal));
        return subtotal;
    }
}

class FixedDiscount : DiscountPolicy
{
    private readonly decimal reduction;
    public FixedDiscount(decimal reduction)
    {
        if (reduction < 0m) throw new ArgumentOutOfRangeException(nameof(reduction));
        this.reduction = reduction;
    }
    public override decimal Apply(decimal subtotal)
    {
        decimal validSubtotal = base.Apply(subtotal);
        return Math.Max(0m, validSubtotal - reduction);
    }
}
