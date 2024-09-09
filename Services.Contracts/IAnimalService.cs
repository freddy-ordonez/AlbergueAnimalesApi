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
        Task<IEnumerable<AnimalDto>> GetAllAnimalAsync(bool trackChanges);
        Task<AnimalDto> GetAnimalAsync(Guid animalId, bool trackChanges);
        Task<AnimalDto> CreateAnimalAsync(AnimalForCreationDto animalDto);

        Task DeleteAnimalAsync(Guid id, bool trackChanges);
        Task UpdateAnimalAsync(Guid id, AnimalForUpdateDto animalDto, bool trackChanges);
        Task<(AnimalForUpdateDto animalToPatch, Animal animalEntity)> GetAnimalForPatchAsync(Guid id, bool trackChanges);

        Task SaveChangesForPatchAsync(AnimalForUpdateDto animalToPatch, Animal animalEntity);
    }
}
