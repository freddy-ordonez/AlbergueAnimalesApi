using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Volunteer>> FindVoluteersAsync(bool trackChanges) => 
            await FindAll(trackChanges)
            .ToListAsync();
    }
}
