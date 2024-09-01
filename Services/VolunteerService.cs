using Domain.Entities;
using Domain.Entities.Exceptions;
using Domain.Repositories;
using Services.Contracts;
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

        public VolunteerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repository = repositoryManager;
            _loggerManager = loggerManager;
        }

        public Volunteer GetVolunteer(Guid volunterId, bool trackChanges)
        {
            var volunteer = _repository.Volunteer.FindVolunteer(volunterId, trackChanges);
            if(volunteer is null)
                throw new VolunteerNotFoundException(volunterId);

            return volunteer;
        }

        public IEnumerable<Volunteer> GetVolunteers(bool trackChanges)
        {
            var volunteers = _repository.Volunteer.FindVoluteers(trackChanges);

            return volunteers;
        }
    }
}
