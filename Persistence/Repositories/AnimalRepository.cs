using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Animal>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(a => a.Name)
            .ToListAsync();

        public async Task<Animal> GetAnimalAsync(Guid animalId, bool trackChanges) => 
            await FinByCondition(a => a.Id.Equals(animalId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
