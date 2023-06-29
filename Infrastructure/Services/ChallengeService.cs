using Domain.Dtos.Challenge;
using Domain.Dtos.Employee;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ChallengeService:IChallengeService
{
    private readonly DataContext _context;

    public ChallengeService(DataContext context)
    {
        _context = context;
    }

    public async Task<ChallengeDto> AddChallenge(ChallengeDto model)
    {
        var challenge = new Challenge(model.Id, model.Title, model.Description);
        await _context.Challenges.AddAsync(challenge);
        await _context.SaveChangesAsync();
        model.Id = challenge.Id;
        return model;
    } 
    
    public async Task<bool> DeleteChallenge(int id)
    {
        var find = await _context.Challenges.FindAsync(id);
        _context.Challenges.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ChallengeDto> UpdateChallenge(ChallengeDto model)
    {
        var find =await _context.Challenges.FindAsync(model.Id);
        find.Title = model.Title;
        find.Description = model.Description;
        await _context.SaveChangesAsync();
        return model; 
    }
    public async Task<List<ChallengeDto>> GetChallenges()
    {
        return await _context.Challenges.Select(e => new ChallengeDto()
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description
        }).ToListAsync();  
    }
    public async Task<ChallengeDto> GetChallengeById(int id)
    {
        var find = await _context.Challenges.
            Include(e =>e.Groups).SingleOrDefaultAsync(x=>x.Id==id);
        if (find != null)
        {
            return  new ChallengeDto()
            {
                Id = find.Id,
                Title = find.Title,
                Description = find.Description,
                CountGroup = find.Groups.Count 
            };
        }
        else
        {
            return new ChallengeDto(); 
        }
    }
}