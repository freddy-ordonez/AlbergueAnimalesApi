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
    }
}
