using System.ComponentModel.DataAnnotations;

namespace MediatorCQRS.Helpers.Entities
{
    public class RegisterModel
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string EmployeeNumber { get; set; }

        [Required, StringLength(128)]
        public string Password { get; set; }
        public int RoleNumber { get; set; }
    }
}
