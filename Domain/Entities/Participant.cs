using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Participant
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Fullname { get; set; }
    [Required,MaxLength(50)]
    public string Email { get; set; }
    [Required,MaxLength(50)]
    public string Phone { get; set; }
    [Required,MaxLength(50)]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public int LocationId { get; set; } 
    public virtual Location Location { get; set; }

    public Participant()
    {
        CreatedAt = DateTime.Now;
    }

    public Participant(int id, string fullname, string email, string phone, string password, int groupId, int locationId)
    {
        Id = id;
        Fullname = fullname;
        Email = email;
        Phone = phone;
        Password = password;
        GroupId = groupId;
        LocationId = locationId;
    }
    
}

