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

        public async Task<IEnumerable<Animal>> GetAllAsync(AnimalParameters animalParameters, bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(a => a.Name)
            .Skip((animalParameters.PageNumber - 1) * animalParameters.PageSize)
            .Take(animalParameters.PageSize)
            .ToListAsync();

        public async Task<Animal> GetAnimalAsync(Guid animalId, bool trackChanges) => 
            await FinByCondition(a => a.Id.Equals(animalId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
