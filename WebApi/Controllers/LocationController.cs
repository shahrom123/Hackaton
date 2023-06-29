using Domain.Dtos.LocationDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class LocationController
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpPost("AddLocation")]
    public async Task<LocationDto> AddLocation(LocationDto location)
    {
        return await _locationService.AddLocation(location);
    }
    [HttpDelete("DeleteLocation")]
    public async Task<bool> DeleteLocation(int id)
    {
        return await _locationService.DeleteLocation(id); 
    }

    [HttpPut("UpdateLocation")]
    public async Task<LocationDto> UpdateLocation(LocationDto group)
    {
        return await _locationService.UpdateLocation(group);
    }

    [HttpGet("GetLocations")]
    public async Task<List<LocationDto>> GetLocation()
    {
        return await _locationService.GetLocations(); 
    }
    [HttpGet("GetLocationById")]
    public async Task<LocationDto> GetLocationById(int id)
    {
        return await _locationService.GetLocationById(id); 
    }
}