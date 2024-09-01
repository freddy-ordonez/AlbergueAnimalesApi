using Domain.Entities;

namespace Domain.Repositories
{
    public interface IVolunteerRepository
    {
        IEnumerable<Volunteer> FindVoluteers(bool trackChanges);
    }
}
