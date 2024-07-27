namespace MediatorCQRS.Helpers.DTOS
{
    public class AddDebitOrCreditOrderDto
    {
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public string? CreatedBy { get; set; }
        public string InvoiceType { get; set; }
        public string InstructionNote { get; set; }

    }
}
