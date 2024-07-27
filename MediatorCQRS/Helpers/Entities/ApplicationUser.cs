using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MediatorCQRS.Helpers.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public bool? PasswordNeedToReset { get; set; }

        // Override the UserName property to allow nul
        public override string? UserName { get; set; }
        public string? FullName { get; set; }

        public string? Job { get; set; }
        public int? StationId { get; set; }
        public DateTime BirthDay { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        public string? OTP { get; set; }
        public DateTime? OTPExpiration { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public ICollection<PostpaidClientInvoice>? AdminPostpaidClientInvoices { get; set; }
        public ICollection<ShopRentalInvoice>? AdminShopRentalInvoices { get; set; }
    }
}
