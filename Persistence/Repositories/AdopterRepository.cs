using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Extensions;
using Shared.RequestFeactures;

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
            var animals = await FindAll(trackChanges)
                .FilterAdopter(adopterParameters.State)
                .Search(adopterParameters.SearchTerm)
                .Sort(adopterParameters.OrderBy)
                .ToListAsync();
            
            return PagedList<Adopter>.ToPagedList(animals, adopterParameters.PageNumber, adopterParameters.PageSize);
        }      
    }
}
