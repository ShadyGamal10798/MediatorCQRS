using MediatorCQRS.Helpers.Guards;

namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

public class ShopRentalInvoiceCondition : InvoiceCondition
{
    public ShopRentalInvoiceCondition(int invoiceId, decimal unitPrice, decimal amount, string salesType, string description = "")
        : base(invoiceId, unitPrice, amount, description)
    {
        Guard.Against.GreaterThan(unitPrice, UnitPriceLimit, nameof(unitPrice));
        SalesType = Guard.Against.NullOrEmpty(salesType, nameof(salesType));
    }
    private ShopRentalInvoiceCondition() { } // EF Core

    public string SalesType { get; } = string.Empty;

    public const decimal UnitPriceLimit = 500000m;
}
