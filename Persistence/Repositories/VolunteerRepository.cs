using Domain.Entities;
using Domain.Repositories;
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

        public Volunteer FindVolunteer(Guid volunteerId, bool trackChanges) => 
            FinByCondition(v => v.Id.Equals(volunteerId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Volunteer> FindVoluteers(bool trackChanges) => 
            FindAll(trackChanges)
            .ToList();
    }
}
