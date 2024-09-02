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
        IEnumerable<Animal> GetAll(bool trackChanges);
        Animal GetAnimal(Guid animalId, bool trackChanges);
        void CreateAnimal(Animal animal);

        void DeleteAnimal(Animal animal);
    }
}
