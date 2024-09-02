using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Shared.Dto;
using Shared.Dto.Animal;

namespace Services.Contracts
{
    public interface IAnimalService
    {
        IEnumerable<AnimalDto> GetAllAnimals(bool trackChanges);
        AnimalDto GetAnimal(Guid animalId, bool trackChanges);
        AnimalDto CreateAnimal(AnimalForCreationDto animalDto);

        void DeleteAnimal(Guid id, bool trackChanges);
    }
}
