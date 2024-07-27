namespace MediatorCQRS.Helpers.DTOS.Views
{
    public class GeneralBudgetReportView
    {
        public int ProductId { get; set; }
        public string StationName { get; set; }
        public string PosName { get; set; }
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
        public string ProductNameUr { get; set; }
        public string ProductNameBn { get; set; }
        public decimal Liters { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public string EmployeeName { get; set; }
        public decimal TotalPaymentsInCash { get; set; }
        public decimal TotalPaymentsInVisa { get; set; }
    }

}
