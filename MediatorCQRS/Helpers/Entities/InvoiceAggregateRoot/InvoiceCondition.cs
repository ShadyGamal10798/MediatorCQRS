namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

using System.ComponentModel.DataAnnotations.Schema;
using MediatorCQRS.Helpers.Guards;
using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Constants;

public abstract class InvoiceCondition : BaseEntity<int>
{
    public const int AmountLimit = 100000;

    protected InvoiceCondition(int invoiceId, decimal unitPrice, decimal amount, string description = "")
    {
        Description = description;
        InvoiceId = Guard.Against.Negative(invoiceId, nameof(invoiceId));
        UnitPrice = Guard.Against.NegativeOrZero(unitPrice, nameof(unitPrice));

        Guard.Against.NegativeOrZero(amount, nameof(amount));
        Amount = Guard.Against.GreaterThan(amount, AmountLimit, nameof(amount));

        Calculate();
    }
    protected InvoiceCondition() { } // EF Core

    public int InvoiceId { get; }
    public string TaxType { get; } = Configuration.TaxType;
    public string? Description { get; set; }
    public short TaxRate { get; } = Configuration.TaxRate;
    public decimal UnitPrice { get; }
    public decimal Amount { get; }
    [NotMapped]
    public decimal TotalPriceWithoutTax => UnitPrice * Amount - TaxValue;
    public decimal TaxValue { get; private set; }
    public decimal TotalPrice { get; private set; }

    private void Calculate()
    {
        decimal taxRate = 100 + TaxRate;
        taxRate = 100 / taxRate;
        TaxValue = UnitPrice * Amount - UnitPrice * Amount / (decimal)1.15;
        TotalPrice = UnitPrice * Amount;
    }
}
