using MediatorCQRS.Helpers.Guards;

namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

public class Discount
{
    public decimal Value { get; private set; }
    public DiscountType Type { get; private set; }

    public Discount(decimal value, DiscountType type)
    {
        Value = Guard.Against.Negative(value, nameof(value));
        Type = type;
    }
    private Discount() { }

    public decimal Apply(decimal price)
    {
        Guard.Against.Negative(price, nameof(price));

        if (price == 0)
            return price;

        if (Type == DiscountType.Value)
            return price - Value;
        else
            return price - price * Value / 100;
    }

}
