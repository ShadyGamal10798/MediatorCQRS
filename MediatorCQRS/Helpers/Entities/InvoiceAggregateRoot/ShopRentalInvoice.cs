using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot.Services;

namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

public class ShopRentalInvoice : Invoice<ShopRentalInvoiceCondition>
{
    public ShopRentalInvoice(
        int stationId,
        int clientId,
        PaymentMethod paymentMethod,
        string literalTotalPrice,
        DateTime invoiceDate,
        List<ShopRentalInvoiceCondition> conditions,
        int lkInvoiceTypeId,
        Discount? discount = null,
        string? notes = null, string? createdBy = null)
        : base(stationId, clientId, paymentMethod, literalTotalPrice, invoiceDate, conditions, lkInvoiceTypeId, discount, notes, createdBy) { }
    private ShopRentalInvoice() { } // EF Core


    protected override InvoiceCalculator<ShopRentalInvoiceCondition> Calculator => new InvoiceCalculator<ShopRentalInvoiceCondition>(this);
}
