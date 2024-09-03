using AutoMapper;
using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto;
using Shared.Dto.Animal;

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

        public AnimalDto CreateAnimal(AnimalForCreationDto animalDto)
        {
            var animalEntity = _mapper.Map<Animal>(animalDto);

            _repository.Animal.CreateAnimal(animalEntity);
            _repository.Save();

            var animalReturnDto = _mapper.Map<AnimalDto>(animalEntity);

            return animalReturnDto;
        }

        public void DeleteAnimal(Guid id, bool trackChanges)
        {
            var animalEntity = _repository.Animal.GetAnimal(id, trackChanges);
            if(animalEntity is null)
                throw new AnimalNotFoundException(id);
            
            _repository.Animal.DeleteAnimal(animalEntity);
            _repository.Save();
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

        public void UpdateAnimal(Guid id, AnimalForUpdateDto animalDto, bool trackChanges)
        {
            var animal = _repository.Animal.GetAnimal(id, trackChanges);
            if(animal is null)
                throw new AnimalNotFoundException(id);
            
            _mapper.Map(animalDto, animal);
            _repository.Save();
        }
    }
}
