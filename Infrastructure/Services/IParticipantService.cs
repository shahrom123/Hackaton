using Domain.Dtos.ParticipantDto;

namespace Infrastructure.Services;

public interface IParticipantService
{
    Task<ParticipantDto> AddParticipant(ParticipantDto model);
    Task<bool> DeleteParticipant(int id);
    Task<ParticipantDto> UpdateParticipant(ParticipantDto model);
    Task<List<GetParticipantDto>> GetParticipants();
    Task<GetParticipantDto> GetParticipantById(int id);
}