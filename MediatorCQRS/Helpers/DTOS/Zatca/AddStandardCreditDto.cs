using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorCQRS.Helpers.DTOS.Zatca
{
    public class AddStandardCreditDto
    {
        public int InvoiceId { get; set; }
        public string InstructionNote { get; set; }
        public DateTime PreviousIssuedDate { get; set; }
        public bool IsShopRental { get; set; }
        public string? EmpId { get; set; }
    }
}
