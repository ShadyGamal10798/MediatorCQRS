using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.ClientAggregateRoot;
using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot.Services;
using MediatorCQRS.Helpers.Entities.Zatca;
using MediatorCQRS.Helpers.Guards;

namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

public abstract class Invoice<T> : BaseEntity<int>
    where T : InvoiceCondition
{
    protected List<T> _conditions = new List<T>();

    protected Invoice(
        int stationId,
        int clientId,
        PaymentMethod paymentMethod,
        string literalTotalPrice,
        DateTime invoiceDate,
        List<T> conditions,
        int lkInvoiceType,
        Discount? discount = null,
        string? notes = null, string? createdBy = null)
    {
        StationId = Guard.Against.NegativeOrZero(stationId, nameof(stationId));
        ClientId = Guard.Against.NegativeOrZero(clientId, nameof(clientId));
        LiteralTotalPrice = Guard.Against.NullOrEmpty(literalTotalPrice, nameof(literalTotalPrice));
        InvoiceDate = Guard.Against.NullOrDefault(invoiceDate, nameof(invoiceDate));
        LKInvoiceTypeId = lkInvoiceType;
        AddConditions(conditions);
        if (discount != null) ApplyDiscount(discount);

        PaymentMethod = paymentMethod;
        Notes = notes;
        CreatedBy = createdBy;
    }

    public void AddConditions(List<T> conditions)
    {
        Guard.Against.Empty(conditions, nameof(conditions));

        _conditions.AddRange(conditions);

        CalculationResult result = Calculator.Calculate();
        TotalPrice = result.TotalPriceWithoutTax;
        TotalTax = result.TotalTax;
        TotalPriceAfterDiscount = result.TotalAfterDiscount;
        FinalPrice = result.FinalPrice;
    }
    public void ApplyDiscount(Discount discount)
    {
        Guard.Against.Null(discount, nameof(discount));

        Discount = discount;

        CalculationResult result = Calculator.Calculate();
        TotalPrice = result.TotalPriceWithoutTax;
        TotalTax = result.TotalTax;
        TotalPriceAfterDiscount = result.TotalAfterDiscount;
        FinalPrice = result.FinalPrice;
    }
    protected Invoice() { } // EF Core

    public int StationId { get; }
    public Station? Station { get; }
    public PaymentMethod PaymentMethod { get; }
    public int LKInvoiceTypeId { get; private set; }
    public int ClientId { get; }
    public Client? Client { get; private set; }
    public string? Notes { get; set; }
    public decimal TotalPrice { get; private set; }
    public decimal TotalTax { get; private set; }
    public decimal TotalPriceAfterDiscount { get; private set; }
    public decimal FinalPrice { get; private set; }
    public string LiteralTotalPrice { get; }
    public DateTime InvoiceDate { get; }
    public string? CreatedBy { get; set; }
    public int? CreditOrDepitMainOrderId { get; private set; }
    public string? InstructionNote { get; private set; }
    public string? XMLError { get; set; }
    public bool XMLStatus { get; set; }
    public bool ZatcaStatus { get; set; }
    public string? ZatcaError { get; set; }
    public bool HasCreditOrDebit { get; private set; }
    public ApplicationUser? AdminApplicationUser { get; set; }
    public Discount Discount { get; private set; } = new Discount(0, DiscountType.Value);
    public IReadOnlyCollection<T> Conditions => _conditions.AsReadOnly();

    protected abstract InvoiceCalculator<T> Calculator { get; }
    public XMLData? XMLData { get; set; }
    public InvalidZatcaInvoice? InvalidZatcaInvoice { get; set; }
    public LKInvoiceType LKInvoiceType { get; set; }
    //public Invoice<InvoiceCondition>? CreditOrDebitInvoice { get; set; }

    public void SetClient(Client client)
    {
        Client = client;
    }
    public void UpdateCreditDetails(decimal price, bool hasCredit, int? mainCreditId)
    {
        FinalPrice = price;
        HasCreditOrDebit = hasCredit;
        CreditOrDepitMainOrderId = mainCreditId;
    }

}
