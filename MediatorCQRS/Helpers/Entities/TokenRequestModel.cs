using System.ComponentModel.DataAnnotations;

namespace MediatorCQRS.Helpers.Entities
{
    public class TokenRequestModel
    {
        public string? EmployeeNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
