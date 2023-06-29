using Domain.Dtos.LocationDto;

namespace Infrastructure.Services;

public interface ILocationService
{
    Task<LocationDto> AddLocation(LocationDto model);
    Task<bool> DeleteLocation(int id);
    Task<LocationDto> UpdateLocation(LocationDto model);
    Task<List<LocationDto>> GetLocations();
    Task<LocationDto> GetLocationById(int id);
}