using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;

namespace MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot.Services
{
    public class InvoiceCalculator<T>
        where T : InvoiceCondition
    {
        private readonly Invoice<T> _invoice;
        public InvoiceCalculator(Invoice<T> invoice)
        {
            _invoice = invoice;

        }
        public CalculationResult Calculate()
        {
            IReadOnlyCollection<T> conditions = _invoice.Conditions;
            var discount = _invoice.Discount;

            var totalPriceWithoutTax = conditions.Sum(e => e.TotalPriceWithoutTax);
            var totalAfterDiscount = discount.Apply(totalPriceWithoutTax);
            var totalTax = conditions.Sum(e => e.TaxValue);

            return new CalculationResult
            {
                TotalPriceWithoutTax = totalPriceWithoutTax,
                TotalTax = totalTax,
                TotalAfterDiscount = totalAfterDiscount,
                FinalPrice = totalAfterDiscount + totalTax
            };
        }
    }

    public class CalculationResult
    {
        public decimal TotalPriceWithoutTax { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalAfterDiscount { get; set; }
    }
}
