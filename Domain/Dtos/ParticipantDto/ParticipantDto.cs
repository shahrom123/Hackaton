namespace Domain.Dtos.ParticipantDto;

public class ParticipantDto
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public int GroupId { get; set; }
    public int LocationId { get; set; }

    
}

public class GetParticipantDto:ParticipantDto
{
    public string GroupName { get; set; } 
    public string LocationName { get; set; }
}