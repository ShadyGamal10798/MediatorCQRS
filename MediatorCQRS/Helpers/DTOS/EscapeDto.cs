using Microsoft.AspNetCore.Http;

namespace MediatorCQRS.Helpers.DTOS
{
    public class EscapeDto
    {
        public string? PlateNumber { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public IFormFile? Image { get; set; }
    }
}
