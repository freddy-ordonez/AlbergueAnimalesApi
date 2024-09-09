using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Adopter> GetAdopterAsync(Guid adopterId, bool trackChanges) =>
            await FinByCondition(a => a.Id.Equals(adopterId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Adopter>> GetAdoptersAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();

        
    }
}
