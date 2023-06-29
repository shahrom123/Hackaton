using Domain.Dtos.LocationDto;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService : ILocationService
{
    private readonly DataContext _context;

    public LocationService(DataContext context)
    {
        _context = context;
    }

    public async Task<LocationDto> AddLocation(LocationDto model)
    {
        var location = new Location(model.Id, model.Name, model.Description);
        await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        model.Id = location.Id;
        return model;
    }

    public async Task<bool> DeleteLocation(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        _context.Locations.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<LocationDto> UpdateLocation(LocationDto model)
    {
        var find = await _context.Locations.FindAsync(model.Id);
        find.Name = model.Name;
        find.Description = model.Description;
        await _context.SaveChangesAsync();
        return model;
    }

    public async Task<List<LocationDto>> GetLocations()
    {
        return await _context.Locations.Select(e => new LocationDto() 
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description
        }).ToListAsync(); 
    }
    public async Task<LocationDto> GetLocationById(int id)
    {
        var find = await _context.Locations.FindAsync(id);
        if (find != null)
        {
            return  new LocationDto()
            {
                Id = find.Id,
                Name = find.Name,
                Description = find.Description
                
            };
        }
        else
        { 
            return new LocationDto(); 
        }
    }
}