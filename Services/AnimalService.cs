using Domain.Entities;
using Domain.Repositories;
using Services.Contracts;

namespace Services
{
    internal sealed class AnimalService : IAnimalService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _loggerManager;

        public AnimalService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repository = repositoryManager;
            _loggerManager = loggerManager;
        }

        public IEnumerable<Animal> GetAllAnimals(bool trackChanges) 
        {
            try
            {
                var animals = _repository.Animal.GetAll(trackChanges);
                return animals;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetAllAnimals)} service method {ex}");
                throw;
            }
        }
    }
}
