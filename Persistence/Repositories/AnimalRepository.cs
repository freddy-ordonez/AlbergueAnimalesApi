using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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
            var animals = await FindAll(trackChanges).ToListAsync();

            if(animalParameters.State.HasValue)
            {
                animals = animals.Where(a => a.State == animalParameters.State.Value).ToList();
            }
            
            animals = animals.OrderBy(a => a.Name)
                .Skip((animalParameters.PageNumber - 1) * animalParameters.PageSize)
                .Take(animalParameters.PageSize)
                .ToList();

            var count = await FindAll(trackChanges).CountAsync();
            
            return new PagedList<Animal>(animals, count, animalParameters.PageNumber, animalParameters.PageSize);

        }

        public async Task<Animal> GetAnimalAsync(Guid animalId, bool trackChanges) => 
            await FinByCondition(a => a.Id.Equals(animalId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
