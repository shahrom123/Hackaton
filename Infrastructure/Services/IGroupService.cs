using Domain.Dtos.GroupDto;

namespace Infrastructure.Services;

public interface IGroupService
{
    Task<GroupDto> AddGroup(GroupDto model);
    Task<bool> DeleteGroup(int id);
    Task<GroupDto> UpdateGroup(GroupDto model);
    Task<List<GroupDto>> GetGroups();
    Task<GroupDto> GetGroupById(int id);
}