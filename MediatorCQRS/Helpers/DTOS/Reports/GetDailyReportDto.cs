namespace MediatorCQRS.Helpers.DTOS.Reports
{
    public class GetDailyReportDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Liters { get; set; }
        public decimal TotalPrice { get; set; }
        public string EmployeeName { get; set; }
        public string StationName { get; set; }
        public string PosName { get; set; }
        public string Address { get; set; }
        public decimal TotalPaymentsInCash { get; set; }
        public decimal TotalPaymentsInVisa { get; set; }



    }
}
