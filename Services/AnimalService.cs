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

        public async Task<AnimalDto> CreateAnimalAsync(AnimalForCreationDto animalDto)
        {
            var animalEntity = _mapper.Map<Animal>(animalDto);

            _repository.Animal.CreateAnimal(animalEntity);
            await _repository.SaveAsync();

            var animalReturnDto = _mapper.Map<AnimalDto>(animalEntity);

            return animalReturnDto;
        }

        public async Task DeleteAnimalAsync(Guid id, bool trackChanges)
        {
            var animalEntity = await _repository.Animal.GetAnimalAsync(id, trackChanges);
            if(animalEntity is null)
                throw new AnimalNotFoundException(id);
            
            _repository.Animal.DeleteAnimal(animalEntity);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<AnimalDto>> GetAllAnimalAsync(bool trackChanges)
        {

            var animals = await _repository.Animal.GetAllAsync(trackChanges);

            var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);

            return animalsDto;
        }

        public async Task<AnimalDto> GetAnimalAsync(Guid animalId, bool trackChanges)
        {
            var animal = await  _repository.Animal.GetAnimalAsync(animalId, trackChanges);
            if (animal is null)
                throw new AnimalNotFoundException(animalId);

            var animalDto = _mapper.Map<AnimalDto>(animal);

            return animalDto;
        }

        public async Task<(AnimalForUpdateDto animalToPatch, Animal animalEntity)> GetAnimalForPatchAsync(Guid id, bool trackChanges)
        {
            var animalEntity =  await _repository.Animal.GetAnimalAsync(id, trackChanges);
            if(animalEntity is null)
                throw new AnimalNotFoundException(id);
            
            var animalToPatch = _mapper.Map<AnimalForUpdateDto>(animalEntity);

            return (animalToPatch, animalEntity);
        }

        public async Task SaveChangesForPatchAsync(AnimalForUpdateDto animalToPatch, Animal animalEntity)
        {
            _mapper.Map(animalToPatch, animalEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateAnimalAsync(Guid id, AnimalForUpdateDto animalDto, bool trackChanges)
        {
            var animal = await _repository.Animal.GetAnimalAsync(id, trackChanges);
            if(animal is null)
                throw new AnimalNotFoundException(id);
            
            _mapper.Map(animalDto, animal);
            await _repository.SaveAsync();
        }

    }
}
