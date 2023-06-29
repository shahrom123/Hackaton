using Domain.Dtos.Challenge;

namespace Infrastructure.Services;

public interface IChallengeService
{
    Task<ChallengeDto> AddChallenge(ChallengeDto model);
    Task<bool> DeleteChallenge(int id);
    Task<ChallengeDto> UpdateChallenge(ChallengeDto model);
    Task<List<ChallengeDto>> GetChallenges();
    Task<ChallengeDto> GetChallengeById(int id); 
}