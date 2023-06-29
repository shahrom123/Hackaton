using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Group
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string GroupNick { get; set; }
    [Required]
    public int ChallengeId { get; set; }
    public Challenge Challenge { get; set; }
    public int MinimumNumberOfMembers { get; set; } 
    [Required,MaxLength(50)]
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual List<Participant> Participants { get; set; }

    public Group()
    {
        CreatedAt = DateTime.Now;
    }

    public Group(int id, string groupNick, int challengeId, int minimumNumberOfMembers, string teamSlogan)
    {
        Id = id;
        GroupNick = groupNick;
        ChallengeId = challengeId;
        MinimumNumberOfMembers = minimumNumberOfMembers;
        TeamSlogan = teamSlogan;
    }
}