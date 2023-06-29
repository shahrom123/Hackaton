namespace Domain.Dtos.GroupDto;

public class GroupDto
{
    public int Id { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public int MinimumNumberOfMembers { get; set; } 
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }

    public GroupDto()
    {
        CreatedAt = DateTime.Now;
    }
}