using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AdopterRepository : RepositoryBase<Adopter>, IAdopterRepository
    {
        public AdopterRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Adopter> GetAdopters(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();
    }
}
