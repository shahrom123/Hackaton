using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string FullName { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public virtual List<EmployeeSkill> EmployeeSkills { get; set; }
    public Employee(int id, string fullName, int companyId)
    {
        Id = id;
        FullName = fullName;
        CompanyId = companyId;
    }
}