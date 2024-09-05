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

        public (AdopterForUpdateDto adopterToPatch, Adopter adopterEntity) GetAdopterForPatch(Guid id, bool trackChanges)
        {
            var adopterEntity = _repository.Adopter.GetAdopter(id, trackChanges);
            if(adopterEntity is null)
                throw new AdopterNotFountException(id);

            var adopterToPatch = _mapper.Map<AdopterForUpdateDto>(adopterEntity); 

            return (adopterToPatch, adopterEntity);
        }

        public IEnumerable<AdopterDto> GetAdopters(bool trackChanges)
        {
           var adopters = _repository.Adopter.GetAdopters(trackChanges);

           var adoptersDtos = _mapper.Map<IEnumerable<AdopterDto>>(adopters);

           return adoptersDtos;
        }

        public void SaveChangesForPatch(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity)
        {
            _mapper.Map(adopterToPatch, adopterEntity);
            _repository.Save();
        }

        public void UpdateAdopter(Guid id, AdopterForUpdateDto adopter, bool trackChanges)
        {
            var adopterEntity = _repository.Adopter.GetAdopter(id, trackChanges);
            if(adopterEntity is null)
                throw new AdopterNotFountException(id);
            
            _mapper.Map(adopter, adopterEntity);
            _repository.Save();
        }
    }
}
