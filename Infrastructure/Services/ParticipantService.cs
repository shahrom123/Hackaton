using System.Runtime.CompilerServices;
using Domain.Dtos.ParticipantDto;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService:IParticipantService
{
    private readonly DataContext _context;

    public ParticipantService(DataContext context)
    {
        _context = context;
    }

    public async Task<ParticipantDto> AddParticipant(ParticipantDto model)
    {

        var participant = new Participant(model.Id, model.Fullname, model.Email, model.Phone, model.Password,
            model.GroupId, model.LocationId);
        await _context.Participants.AddAsync(participant);
        await _context.SaveChangesAsync();
        model.Id =  participant.Id; 
        return model;

    }
    public async Task<bool> DeleteParticipant(int id)
    {
        var find = await _context.Participants.FindAsync(id);
        _context.Participants.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<ParticipantDto> UpdateParticipant(ParticipantDto model)
    {
        var find =await _context.Participants.FindAsync(model.Id); 
        find.Fullname = model.Fullname;
        find.Email = model.Email;
        find.Phone = model.Phone;
        find.Password = model.Password;
        find.GroupId = model.GroupId;
        find.LocationId = model.LocationId;
        await _context.SaveChangesAsync();
        return model; 
    }
    public async Task<List<GetParticipantDto>> GetParticipants()
    {
        return await _context.Participants.Select(e => new GetParticipantDto() 
        {
            Id = e.Id,
            Fullname = e.Fullname,
            Email = e.Email,
            Password = e.Password,
            Phone = e.Phone,
            GroupId = e.GroupId,
            LocationId = e.LocationId,
            CreatedAt = e.CreatedAt,
            GroupName = e.Group.GroupNick,
            LocationName = e.Location.Name
          
        }).ToListAsync();  
    }

    public async Task<GetParticipantDto> GetParticipantById(int id)
    {
        var find = await _context.Participants.
            Include(e =>e.Group).SingleOrDefaultAsync(x=>x.Id==id);
        if (find != null)
        {
            return  new GetParticipantDto()
            {
                Id = find.Id,
                Fullname = find.Fullname,
                Phone = find.Phone,
                GroupId = find.GroupId, 
                LocationId = find.LocationId,
                CreatedAt = find.CreatedAt,
                Email = find.Email,
                Password = find.Password,
                GroupName = find.Group.GroupNick,
                LocationName = find.Location.Name
            };
        } 
        else
        {
            return new GetParticipantDto(); 
        }
    }
}