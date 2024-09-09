using AutoMapper;
using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto.Volunteer;

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
            var volunteerEntity = await _repository.Volunteer.FindVolunteerAsync(id, trackChanges);
            if(volunteerEntity is null)
                throw new VolunteerNotFoundException(id);
            
            _repository.Volunteer.DeleteVolunteer(volunteerEntity);
            await _repository.SaveAsync();
        }

        public async Task<VolunteerDto> GetVolunteerAsync(Guid volunterId, bool trackChanges)
        {
            var volunteer = await _repository.Volunteer.FindVolunteerAsync(volunterId, trackChanges);
            if(volunteer is null)
                throw new VolunteerNotFoundException(volunterId);

            var volunteerDto = _mapper.Map<VolunteerDto>(volunteer);

            return volunteerDto;
        }

        public async Task<(VolunteerForUpdateDto volunteerToPatch, Volunteer volunteerEntity)> GetVolunteerForPatchAsync(Guid id, bool trackChanges)
        {
            var volunteerEntity = await _repository.Volunteer.FindVolunteerAsync(id, trackChanges);
            if(volunteerEntity is null)
                throw new VolunteerNotFoundException(id);
            
            var volunteerToPatch = _mapper.Map<VolunteerForUpdateDto>(volunteerEntity);

            return (volunteerToPatch, volunteerEntity);
        }

        public async Task<IEnumerable<VolunteerDto>> GetVolunteersAsync(bool trackChanges)
        {
            var volunteers = await _repository.Volunteer.FindVoluteersAsync(trackChanges);

            var volunteersDto = _mapper.Map<IEnumerable<VolunteerDto>>(volunteers);

            return volunteersDto;
        }

        public async Task SaveChangesForPatchAsync(VolunteerForUpdateDto volunteerToPatch, Volunteer volunterEntity)
        {
            _mapper.Map(volunteerToPatch, volunterEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateVolunteerAsync(Guid id, VolunteerForUpdateDto volunteer, bool trackChanges)
        {
            var volunteerEntity = await _repository.Volunteer.FindVolunteerAsync(id, trackChanges);
            if(volunteerEntity is null)
                throw new VolunteerNotFoundException(id);
            
            _mapper.Map(volunteer, volunteerEntity);
            await _repository.SaveAsync();
        }
    }
}
