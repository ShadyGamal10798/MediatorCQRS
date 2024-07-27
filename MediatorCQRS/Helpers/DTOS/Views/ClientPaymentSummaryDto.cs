namespace MediatorCQRS.Helpers.DTOS.Views
{
    public record ClientPaymentSummaryDto
    (
        int Id,
        string ClientName,
        string StationName,
        string PaymentMethodArabic,
        decimal TotalPrice,
        DateTime CreatedDate,
        int StationId,
        bool ZatcaStatus
    )
    {
        public string Serial => string.Format("R{0}", Id);
    }
}
