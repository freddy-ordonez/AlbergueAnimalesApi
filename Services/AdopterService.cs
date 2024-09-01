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
    internal sealed class AdopterService : IAdopterService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _loggerManager;

        public AdopterService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repository = repositoryManager;
            _loggerManager = loggerManager;
        }

        public Adopter GetAdopter(Guid adopterId, bool trackChanges)
        {
            var adopter = _repository.Adopter.GetAdopter(adopterId, trackChanges);
            if(adopter is null)
                throw new AdopterNotFountException(adopterId);
                
            return adopter;
        }

        public IEnumerable<Adopter> GetAdopters(bool trackChanges)
        {
           var adopters = _repository.Adopter.GetAdopters(trackChanges);

           return adopters;
        }
    }
}
