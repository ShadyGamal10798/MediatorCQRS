using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot.Services;

namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

public class PostpaidClientInvoice : Invoice<PostpaidClientInvoiceCondition>
{
    protected override InvoiceCalculator<PostpaidClientInvoiceCondition> Calculator => new InvoiceCalculator<PostpaidClientInvoiceCondition>(this);

    private PostpaidClientInvoice() { } // EF Core

    public PostpaidClientInvoice(
        int stationId,
        int clientId,
        PaymentMethod paymentMethod,
        string literalTotalPrice,
        DateTime invoiceDate,
        List<PostpaidClientInvoiceCondition> conditions,
        int lkInvoiceTypeId,
        Discount? discount = null,
        string? notes = null, string? createdBy = null)
        : base(stationId, clientId, paymentMethod, literalTotalPrice, invoiceDate, conditions, lkInvoiceTypeId, discount, notes, createdBy) { }

}
