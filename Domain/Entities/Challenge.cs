using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Challenge
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Title { get; set; }
    [Required,MaxLength(50)]
    public string Description { get; set; }
    public virtual List<Group> Groups { get; set; }

    public Challenge(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }


}