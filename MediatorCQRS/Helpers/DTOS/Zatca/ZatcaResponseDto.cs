namespace MediatorCQRS.Helpers.DTOS.Zatca
{
    public class ZatcaResponseDto
    {
        public Dictionary<string, string> Messages { get; set; }
        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }
        public string ErrorMessages { get; set; }
        public string ReportingStatus { get; set; }
        public string ClearanceStatus { get; set; }
        public string QrCode { get; set; }
        public int StatusCode { get; set; }
        public string? WarningMessage { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ClearedInvoice { get; set; }
        public string? ClearedXMLFileNameFullPath { get; set; }



        public ZatcaResponseDto()
        {
            Messages = new Dictionary<string, string>();
        }
    }
}
