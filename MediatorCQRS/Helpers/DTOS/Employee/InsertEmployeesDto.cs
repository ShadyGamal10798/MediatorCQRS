using Microsoft.AspNetCore.Http;

namespace MediatorCQRS.Helpers.DTOS.Employee
{
    public record InsertEmployeesDto(IFormFile ExcelFile);
    public record InsertClientsDto(IFormFile ExcelFile);
}
