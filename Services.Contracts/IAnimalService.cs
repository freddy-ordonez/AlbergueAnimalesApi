using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Shared.Dto;

namespace Services.Contracts
{
    public interface IAnimalService
    {
        IEnumerable<AnimalDto> GetAllAnimals(bool trackChanges);
        AnimalDto GetAnimal(Guid animalId, bool trackChanges);
    }
}
