using Domain.Entities;
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

        public IEnumerable<Volunteer> GetVolunteers(bool trackChanges)
        {
            var volunteers = _repository.Volunteer.FindVoluteers(trackChanges);

            return volunteers;
        }
    }
}
