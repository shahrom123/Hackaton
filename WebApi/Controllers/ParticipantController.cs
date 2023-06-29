using Domain.Dtos.LocationDto;
using Domain.Dtos.ParticipantDto;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ParticipantController
{
    private readonly IParticipantService _participantService;

    public ParticipantController(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpPost("AddParticipant")]
    public async Task<ParticipantDto> AddParticipant(ParticipantDto model)
    {
        return await _participantService.AddParticipant(model);
    }
    [HttpDelete("DeleteParticipant")]
    public async Task<bool> DeleteLocation(int id)
    {
        return await _participantService.DeleteParticipant(id); 
    }

    [HttpPut("UpdateLocation")]
    public async Task<ParticipantDto> UpdateParticipant(ParticipantDto participant)
    {
        return await _participantService.UpdateParticipant(participant);
    }

    [HttpGet("GetParticipants")]
    public async Task<List<GetParticipantDto>> GetParticipant()
    {
        return await _participantService.GetParticipants();  
    }
    [HttpGet("GetParticipantById")]
    public async Task<GetParticipantDto> GetParticipantById(int id)
    {
        return await _participantService.GetParticipantById(id);   
    }

}