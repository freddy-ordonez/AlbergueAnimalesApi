using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AdoptionRepository : RepositoryBase<Adoption>, IAdoptionRepository
    {
        public AdoptionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
