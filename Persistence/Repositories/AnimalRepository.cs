using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Extensions;
using Shared.RequestFeactures;

namespace Persistence.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        public AnimalRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreateAnimal(Animal animal) => Create(animal);

        public void DeleteAnimal(Animal animal) => Delete(animal);

        public async Task<PagedList<Animal>> GetAllAsync(AnimalParameters animalParameters, bool trackChanges)
        {
            var animals = await FindAll(trackChanges)
                .FilterAnimal(animalParameters.State)
                .Search(animalParameters.SearchTerm)
                .Sort(animalParameters.OrderBy)
                .ToListAsync();
            
            return PagedList<Animal>.ToPagedList(animals, animalParameters.PageNumber, animalParameters.PageSize);

        }

        public async Task<Animal> GetAnimalAsync(Guid animalId, bool trackChanges) => 
            await FinByCondition(a => a.Id.Equals(animalId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
