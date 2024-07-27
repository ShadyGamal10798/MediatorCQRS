namespace MediatorCQRS.Helpers.DTOS.Zatca
{
    public class OrderWithXmlData
    {
        public int Id { get; set; }
        public string InvoiceHash { get; set; }
        public int InvoiceCounter { get; set; }
    }
}
