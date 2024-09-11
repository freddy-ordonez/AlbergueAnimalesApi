using Domain.Entities;
using Shared.RequestFeactures;
namespace Domain.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAllAsync(AnimalParameters animalParameters, bool trackChanges);
        Task<Animal> GetAnimalAsync(Guid animalId, bool trackChanges);
        void CreateAnimal(Animal animal);

        void DeleteAnimal(Animal animal);
    }
}
