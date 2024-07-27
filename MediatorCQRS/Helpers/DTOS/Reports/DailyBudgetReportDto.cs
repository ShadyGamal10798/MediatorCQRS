namespace MediatorCQRS.Helpers.DTOS.Reports
{
    public class DailyBudgetReportDto
    {
        public List<GetDailyReportDto> DailyReports { get; set; }

        public string VatNumber { get; set; }
        public decimal CashTotalPaymentsToday { get; set; }
        public decimal VisaTotalPaymentsToday { get; set; }

    }
}
