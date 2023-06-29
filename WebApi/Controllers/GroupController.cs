using Domain.Dtos.GroupDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class GroupController
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost("AddGroup")]
    public async Task<GroupDto> AddGroup(GroupDto model)
    {
        return await _groupService.AddGroup(model);
    }
    [HttpDelete("DeleteGroup")]
    public async Task<bool> DeleteGroup(int id)
    {
        return await _groupService.DeleteGroup(id); 
    }

    [HttpPut("UpdateGroup")]
    public async Task<GroupDto> UpdateGroupDto(GroupDto group)
    {
        return await _groupService.UpdateGroup(group);
    }

    [HttpGet("GetGroups")]
    public async Task<List<GroupDto>> GetGroup()
    {
        return await _groupService.GetGroups(); 
    }
    [HttpGet("GetGroupById")]
    public async Task<GroupDto> GetGroupById(int id)
    {
        return await _groupService.GetGroupById(id); 
    }

}