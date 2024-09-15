using AutoMapper;
using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto.Adopter;
using Shared.RequestFeactures;

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

        public async Task<AdopterDto> CreateAdopterAsync(AdopterForCreationDto adopter)
        {
            var adopterEntity = _mapper.Map<Adopter>(adopter);

            _repository.Adopter.CreateAdopter(adopterEntity);
            await _repository.SaveAsync();

            var adopterDto = _mapper.Map<AdopterDto>(adopterEntity);

            return adopterDto;
        }

        public async Task DeleteAdopterAsync(Guid id, bool trackChanges)
        {
            var adopterEntity = await GetAdopterAndCheckIfExistAsync(id, trackChanges);
            
            _repository.Adopter.DeleteAdopter(adopterEntity);
            await _repository.SaveAsync();
        }

        public async Task<AdopterDto> GetAdopterAsync(Guid adopterId, bool trackChanges)
        {
            var adopter = await GetAdopterAndCheckIfExistAsync(adopterId, trackChanges);
            
            var AdopterDto = _mapper.Map<AdopterDto>(adopter);
                
            return AdopterDto;
        }

        public async Task<(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity)> GetAdopterForPatchAsync(Guid id, bool trackChanges)
        {
            var adopterEntity = await GetAdopterAndCheckIfExistAsync(id, trackChanges);

            var adopterToPatch = _mapper.Map<AdopterForUpdateDto>(adopterEntity); 

            return (adopterToPatch, adopterEntity);
        }

        public async Task<(IEnumerable<AdopterDto> adopterDtos, MetaData metaData)> GetAdoptersAsync(AdopterParameters adopterParameters, bool trackChanges)
        {
           var adopters = await _repository.Adopter.GetAdoptersAsync(adopterParameters, trackChanges);

           var adoptersDtos = _mapper.Map<IEnumerable<AdopterDto>>(adopters);

           return (adopterDtos: adoptersDtos, metaData: adopters.MetaData);
        }

        public async Task SaveChangesForPatchAsync(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity)
        {
            _mapper.Map(adopterToPatch, adopterEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateAdopterAsync(Guid id, AdopterForUpdateDto adopter, bool trackChanges)
        {
            var adopterEntity = await GetAdopterAndCheckIfExistAsync(id, trackChanges);
            
            _mapper.Map(adopter, adopterEntity);
            await _repository.SaveAsync();
        }
        
        public async Task<Adopter> GetAdopterAndCheckIfExistAsync(Guid id, bool trackChanges)
        {
            var adopterEntity = await _repository.Adopter.GetAdopterAsync(id, trackChanges);

            return adopterEntity is null ? throw new AdopterNotFountException(id) : adopterEntity;
        }
    }
}
