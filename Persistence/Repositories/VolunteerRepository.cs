using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Extensions;
using Shared.RequestFeactures;

namespace Persistence.Repositories
{
    public class VolunteerRepository : RepositoryBase<Volunteer>, IVolunteerRepository
    {
        public VolunteerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateVolunteer(Volunteer volunteer) => Create(volunteer);

        public void DeleteVolunteer(Volunteer volunteer) => Delete(volunteer);

        public async Task<Volunteer> FindVolunteerAsync(Guid volunteerId, bool trackChanges) => 
            await FinByCondition(v => v.Id.Equals(volunteerId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<PagedList<Volunteer>> FindVoluteersAsync(VolunteerParameters volunteerParameters, bool trackChanges) 
        {
            var volunteers = await FindAll(trackChanges)
                .FilterVolunteer(volunteerParameters.State)
                .Search(volunteerParameters.SearchTerm)
                .OrderBy(v => v.Name)
                .ToListAsync();
            
            return PagedList<Volunteer>.ToPagedList(volunteers, volunteerParameters.PageNumber, volunteerParameters.PageSize);
        }
    }
}
