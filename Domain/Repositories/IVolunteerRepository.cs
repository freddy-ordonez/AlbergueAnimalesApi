using Domain.Entities;

namespace Domain.Repositories
{
    public interface IVolunteerRepository
    {
        Task<IEnumerable<Volunteer>> FindVoluteersAsync(bool trackChanges);
        Task<Volunteer> FindVolunteerAsync(Guid volunteerId, bool trackChanges);
        void CreateVolunteer(Volunteer volunteer);
        void DeleteVolunteer(Volunteer volunteer);
    }
}
