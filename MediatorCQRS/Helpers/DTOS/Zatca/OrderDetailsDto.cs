namespace MediatorCQRS.Helpers.DTOS.Zatca
{
    public class OrderDetailsDto
    {
        public string OrderSerial { get; set; }
        public DateTime CreationDate { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string OrderType { get; set; }
        public string ProductName { get; set; }
        public string StationName { get; set; }
        public decimal Liters { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithoutVat { get; set; }
        public decimal Vat { get; set; }
        public string QrCode { get; set; }
        public string VATNumber { get; set; }
        public string POSName { get; set; }
        public string Address { get; set; }
    }
}
