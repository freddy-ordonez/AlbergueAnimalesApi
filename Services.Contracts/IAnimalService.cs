using Domain.Entities;
using Shared.Dto;
using Shared.Dto.Animal;
using Shared.RequestFeactures;

namespace Services.Contracts
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDto>> GetAllAnimalAsync(AnimalParameters animalParameters, bool trackChanges);
        Task<AnimalDto> GetAnimalAsync(Guid animalId, bool trackChanges);
        Task<AnimalDto> CreateAnimalAsync(AnimalForCreationDto animalDto);

        Task DeleteAnimalAsync(Guid id, bool trackChanges);
        Task UpdateAnimalAsync(Guid id, AnimalForUpdateDto animalDto, bool trackChanges);
        Task<(AnimalForUpdateDto animalToPatch, Animal animalEntity)> GetAnimalForPatchAsync(Guid id, bool trackChanges);

        Task SaveChangesForPatchAsync(AnimalForUpdateDto animalToPatch, Animal animalEntity);
    }
}
