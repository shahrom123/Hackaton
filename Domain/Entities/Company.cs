using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Company
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Name { get; set; }
    public virtual List<Employee> Employees { get; set; }
}