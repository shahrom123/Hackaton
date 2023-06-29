using Domain.Dtos.Challenge;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ChallengeController
{
    private readonly IChallengeService _challengeService;

    public ChallengeController(IChallengeService challengeService)
    {
        _challengeService = challengeService; 
    }

    [HttpPost("AddChallenge")]
    public async Task<ChallengeDto> AddChallenge(ChallengeDto challenge)
    {
        return await _challengeService.AddChallenge(challenge); 
    }

    [HttpDelete("DeleteChallenge")]
    public async Task<bool> DeleteChallenge(int id)
    {
        return await _challengeService.DeleteChallenge(id); 
    }
    [HttpGet("GetChallengeById")]
    public async Task<ChallengeDto> GetChallengeById(int id)
    {
        return await _challengeService.GetChallengeById(id); 
    }

    [HttpPut("UpdateChallenge")]
    public async Task<ChallengeDto> UpdateChallenge(ChallengeDto challenge)
    {
        return await _challengeService.UpdateChallenge(challenge);
    }

    [HttpGet("GetChallenge")]
    public async Task<List<ChallengeDto>> GetChallenge()
    {
        return await _challengeService.GetChallenges(); 
    }
    
    
}