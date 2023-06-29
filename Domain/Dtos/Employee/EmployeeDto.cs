using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Employee;

public class EmployeeBaseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int CompanyId { get; set; }
}