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

        public Adopter GetAdopter(Guid adopterId, bool trackChanges) =>
            FinByCondition(a => a.Id.Equals(adopterId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Adopter> GetAdopters(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();
    }
}
