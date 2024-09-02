using AutoMapper;
using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto.Adopter;

namespace Services
{
    internal sealed class AdopterService : IAdopterService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public AdopterService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public AdopterDto CreateAdopter(AdopterForCreationDto adopter)
        {
            var adopterEntity = _mapper.Map<Adopter>(adopter);

            _repository.Adopter.CreateAdopter(adopterEntity);
            _repository.Save();

            var adopterDto = _mapper.Map<AdopterDto>(adopterEntity);

            return adopterDto;
        }

        public void DeleteAdopter(Guid id, bool trackChanges)
        {
            var adopterEntity = _repository.Adopter.GetAdopter(id, trackChanges);
            if(adopterEntity is null)
                throw new AdopterNotFountException(id);
            
            _repository.Adopter.DeleteAdopter(adopterEntity);
            _repository.Save();
        }

        public AdopterDto GetAdopter(Guid adopterId, bool trackChanges)
        {
            var adopter = _repository.Adopter.GetAdopter(adopterId, trackChanges);
            if(adopter is null)
                throw new AdopterNotFountException(adopterId);
            
            var AdopterDto = _mapper.Map<AdopterDto>(adopter);
                
            return AdopterDto;
        }

        public IEnumerable<AdopterDto> GetAdopters(bool trackChanges)
        {
           var adopters = _repository.Adopter.GetAdopters(trackChanges);

           var adoptersDtos = _mapper.Map<IEnumerable<AdopterDto>>(adopters);

           return adoptersDtos;
        }
    }
}
