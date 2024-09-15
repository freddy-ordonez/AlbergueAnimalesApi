using Domain.Entities;
using Shared.RequestFeactures;

namespace Domain.Repositories
{
    public interface IVolunteerRepository
    {
        Task<PagedList<Volunteer>> FindVoluteersAsync(VolunteerParameters volunteerParameters, bool trackChanges);
        Task<Volunteer> FindVolunteerAsync(Guid volunteerId, bool trackChanges);
        void CreateVolunteer(Volunteer volunteer);
        void DeleteVolunteer(Volunteer volunteer);
    }
}
