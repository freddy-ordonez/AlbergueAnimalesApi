using Domain.Entities;

namespace Domain.Repositories
{
    public interface IVolunteerRepository
    {
        IEnumerable<Volunteer> FindVoluteers(bool trackChanges);
        Volunteer FindVolunteer(Guid volunteerId, bool trackChanges);
        void CreateVolunteer(Volunteer volunteer);
        void DeleteVolunteer(Volunteer volunteer);
    }
}
