using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Location
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Name { get; set; }
    [Required,MaxLength(50)]
    public string Description { get; set; }
    public virtual List<Participant> Participants { get; set; }

    public Location(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    
}