using Domain.Dtos.GroupDto;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }

    public async Task<GroupDto> AddGroup(GroupDto model)
    {
        var group = new Group(model.Id, model.GroupNick, model.ChallengeId, model.MinimumNumberOfMembers,
            model.TeamSlogan);
        await _context.Groups.AddAsync(group);
        await _context.SaveChangesAsync();
        model.Id = group.Id;
        return model; 
    }

    public async Task<bool> DeleteGroup(int id)
    {
        var find = await _context.Groups.FindAsync(id);
        _context.Groups.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GroupDto> UpdateGroup(GroupDto model)
    {
        var find = await _context.Groups.FindAsync(model.Id);
        find.GroupNick = model.GroupNick;
        find.ChallengeId = model.ChallengeId;
        find.MinimumNumberOfMembers = model.MinimumNumberOfMembers;
        find.TeamSlogan = model.TeamSlogan;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<List<GroupDto>> GetGroups()
    {
        return await _context.Groups.Select(e => new GroupDto()
        {
            Id = e.Id,
            GroupNick = e.GroupNick,
            ChallengeId = e.ChallengeId, 
            TeamSlogan = e.TeamSlogan,
            MinimumNumberOfMembers = e.MinimumNumberOfMembers,
            CreatedAt = e.CreatedAt
        }).ToListAsync(); 
    }
    public async Task<GroupDto> GetGroupById(int id)
    {
        var find = await _context.Groups.FindAsync(id);
        if (find != null)
        {
            return  new GroupDto()
            {
                Id = find.Id,
                GroupNick = find.GroupNick,
                ChallengeId = find.ChallengeId,
                TeamSlogan = find.TeamSlogan,
                MinimumNumberOfMembers = find.MinimumNumberOfMembers,
                CreatedAt = find.CreatedAt
            };
        }
        else
        {
            return new GroupDto(); 
        }
    }
}