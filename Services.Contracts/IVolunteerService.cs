using Domain.Entities;
using Shared.Dto.Volunteer;

namespace Services.Contracts
{
    public interface IVolunteerService
    {
        IEnumerable<VolunteerDto> GetVolunteers(bool trackChanges);
        VolunteerDto GetVolunteer(Guid volunterId, bool trackChanges);
        VolunteerDto CreateVolunteer(VolunteerForCreationDto volunteer);
        void DeleteVolunteer(Guid id, bool trackChanges);
        void UpdateVolunteer(Guid id, VolunteerForUpdateDto volunteer, bool trackChanges);

        (VolunteerForUpdateDto volunteerToPatch, Volunteer volunteerEntity) GetVolunteerForPatch(Guid id, bool trackChanges);
        void SaveChangesForPatch(VolunteerForUpdateDto volunteerToPatch, Volunteer volunterEntity);
    }
}
