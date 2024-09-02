using Domain.Entities;
using Domain.Repositories;
using System;

namespace Persistence.Repositories
{
    public class AdopterRepository : RepositoryBase<Adopter>, IAdopterRepository
    {
        public AdopterRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAdopter(Adopter adopter) => Create(adopter);

        public void DeleteAdopter(Adopter adopter) => Delete(adopter);

        public Adopter GetAdopter(Guid adopterId, bool trackChanges) =>
            FinByCondition(a => a.Id.Equals(adopterId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Adopter> GetAdopters(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();

        
    }
}
