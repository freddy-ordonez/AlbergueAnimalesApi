using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync(bool trackChanges);
        Task<Animal> GetAnimalAsync(Guid animalId, bool trackChanges);
        void CreateAnimal(Animal animal);

        void DeleteAnimal(Animal animal);
    }
}
