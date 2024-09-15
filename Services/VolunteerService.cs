using AutoMapper;
using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto.Volunteer;
using Shared.RequestFeactures;

namespace Services
{
    internal sealed class VolunteerService : IVolunteerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public VolunteerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<VolunteerDto> CreateVolunteerAsync(VolunteerForCreationDto volunteer)
        {
            var volunterEntity = _mapper.Map<Volunteer>(volunteer);

            _repository.Volunteer.CreateVolunteer(volunterEntity);
            await _repository.SaveAsync();

            var volunteerDto = _mapper.Map<VolunteerDto>(volunterEntity);

            return volunteerDto;
        }

        public async Task DeleteVolunteerAsync(Guid id, bool trackChanges)
        {
            var volunteerEntity = await GetVolunteerAndCheckIfExistAsync(id, trackChanges);
            
            _repository.Volunteer.DeleteVolunteer(volunteerEntity);
            await _repository.SaveAsync();
        }

        public async Task<VolunteerDto> GetVolunteerAsync(Guid volunterId, bool trackChanges)
        {
            var volunteer = await GetVolunteerAndCheckIfExistAsync(volunterId, trackChanges);

            var volunteerDto = _mapper.Map<VolunteerDto>(volunteer);

            return volunteerDto;
        }

        public async Task<(VolunteerForUpdateDto volunteerToPatch, Volunteer volunteerEntity)> GetVolunteerForPatchAsync(Guid id, bool trackChanges)
        {
            var volunteerEntity = await GetVolunteerAndCheckIfExistAsync(id, trackChanges);
            
            var volunteerToPatch = _mapper.Map<VolunteerForUpdateDto>(volunteerEntity);

            return (volunteerToPatch, volunteerEntity);
        }

        public async Task<(IEnumerable<VolunteerDto> volunteerDtos, MetaData metaData)> GetVolunteersAsync(VolunteerParameters volunteerParameters, bool trackChanges)
        {
            var pageListVolunteer = await _repository.Volunteer.FindVoluteersAsync(volunteerParameters, trackChanges);

            var volunteersDtos = _mapper.Map<IEnumerable<VolunteerDto>>(pageListVolunteer);

            return (volunteersDtos, pageListVolunteer.MetaData);
        }

        public async Task SaveChangesForPatchAsync(VolunteerForUpdateDto volunteerToPatch, Volunteer volunterEntity)
        {
            _mapper.Map(volunteerToPatch, volunterEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateVolunteerAsync(Guid id, VolunteerForUpdateDto volunteer, bool trackChanges)
        {
            var volunteerEntity = await GetVolunteerAndCheckIfExistAsync(id, trackChanges);
            
            _mapper.Map(volunteer, volunteerEntity);
            await _repository.SaveAsync();
        }

        public async Task<Volunteer> GetVolunteerAndCheckIfExistAsync(Guid id, bool trackChanges)
        {
            var volunteer = await _repository.Volunteer.FindVolunteerAsync(id, trackChanges);
            
            return volunteer is null ? throw new VolunteerNotFoundException(id) : volunteer;
        }
    }
}
