using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeactures;
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

        public async Task<PagedList<Adopter>> GetAdoptersAsync(AdopterParameters adopterParameters, bool trackChanges) 
        {
            var animals = await FindAll(trackChanges).ToListAsync();
            if(adopterParameters.State.HasValue)
            {
                animals = animals.Where(a => a.State == adopterParameters.State.Value).ToList();
            }
            
            animals = [.. animals.OrderBy(a => a.Name)];
            
            return PagedList<Adopter>.ToPagedList(animals, adopterParameters.PageNumber, adopterParameters.PageSize);
        }      
    }
}
