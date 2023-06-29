namespace Domain.Entities;

public class EmployeeSkill
{
    public int SkillId { get; set; }
    public int EmployeeId { get; set; }
    public virtual Skill Skill { get; set; }
    public virtual Employee Employee { get; set; }
}