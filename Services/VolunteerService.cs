using AutoMapper;
using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public VolunteerDto CreateVolunteer(VolunteerForCreationDto volunteer)
        {
            var volunterEntity = _mapper.Map<Volunteer>(volunteer);

            _repository.Volunteer.CreateVolunteer(volunterEntity);
            _repository.Save();

            var volunteerDto = _mapper.Map<VolunteerDto>(volunterEntity);

            return volunteerDto;
        }

        public VolunteerDto GetVolunteer(Guid volunterId, bool trackChanges)
        {
            var volunteer = _repository.Volunteer.FindVolunteer(volunterId, trackChanges);
            if(volunteer is null)
                throw new VolunteerNotFoundException(volunterId);

            var volunteerDto = _mapper.Map<VolunteerDto>(volunteer);

            return volunteerDto;
        }

        public IEnumerable<VolunteerDto> GetVolunteers(bool trackChanges)
        {
            var volunteers = _repository.Volunteer.FindVoluteers(trackChanges);

            var volunteersDto = _mapper.Map<IEnumerable<VolunteerDto>>(volunteers);

            return volunteersDto;
        }
    }
}
