using AutoMapper;
using Domain.Entities;
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
            try
            {
                var animals = _repository.Animal.GetAll(trackChanges);

                var animalsDto = animals.Select(a => new AnimalDto(a.Id, a.Name, a.Type.Value, a.State.Value, a.DateDelivery.Value));
                return animalsDto;
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetAllAnimals)} service method {ex}");
                throw;
            }
        }
    }
}
