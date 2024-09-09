using Domain.Entities;
using Shared.Dto.Volunteer;

namespace Services.Contracts
{
    public interface IVolunteerService
    {
        Task<IEnumerable<VolunteerDto>> GetVolunteersAsync(bool trackChanges);
        Task<VolunteerDto> GetVolunteerAsync(Guid volunterId, bool trackChanges);
        Task<VolunteerDto> CreateVolunteerAsync(VolunteerForCreationDto volunteer);
        Task DeleteVolunteerAsync(Guid id, bool trackChanges);
        Task UpdateVolunteerAsync(Guid id, VolunteerForUpdateDto volunteer, bool trackChanges);

        Task<(VolunteerForUpdateDto volunteerToPatch, Volunteer volunteerEntity)> GetVolunteerForPatchAsync(Guid id, bool trackChanges);
        Task SaveChangesForPatchAsync(VolunteerForUpdateDto volunteerToPatch, Volunteer volunterEntity);
    }
}
