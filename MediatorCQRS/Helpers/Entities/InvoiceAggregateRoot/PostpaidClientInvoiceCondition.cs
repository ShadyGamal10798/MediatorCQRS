using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Guards;

namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

public class PostpaidClientInvoiceCondition : InvoiceCondition
{
    public PostpaidClientInvoiceCondition(int invoiceId, decimal unitPrice, decimal amount, int productId, string description = "")
        : base(invoiceId, unitPrice, amount, description)
    {
        ProductId = Guard.Against.NegativeOrZero(productId, nameof(productId));
    }
    private PostpaidClientInvoiceCondition() { } // EF Core

    public int ProductId { get; }
    public LKProduct? Product { get; }
}
