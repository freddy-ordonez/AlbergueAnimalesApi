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
    }
}
