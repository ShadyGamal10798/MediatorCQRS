namespace MediatorCQRS.Helpers.DTOS.Views
{
    public record PostpaidClientPaymentSummaryDto
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
        public string Serial => string.Format("D{0}", Id);
    }
}
