using AutoMapper;
using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto;

namespace Services
{
    internal sealed class AnimalService : IAnimalService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public AnimalService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<AnimalDto> GetAllAnimals(bool trackChanges)
        {

            var animals = _repository.Animal.GetAll(trackChanges);

            var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);

            return animalsDto;
        }

        public AnimalDto GetAnimal(Guid animalId, bool trackChanges)
        {
            var animal = _repository.Animal.GetAnimal(animalId, trackChanges);
            if (animal is null)
                throw new AnimalNotFoundException(animalId);

            var animalDto = _mapper.Map<AnimalDto>(animal);

            return animalDto;
        }
    }
}
