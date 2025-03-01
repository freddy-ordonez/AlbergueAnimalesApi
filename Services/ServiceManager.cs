﻿using AutoMapper;
using Domain.Repositories;
using Services.Contracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAnimalService> _animalService;
        private readonly Lazy<IVolunteerService> _volunteerService;
        private readonly Lazy<IAdopterService> _adopterService;
        private readonly Lazy<IAdoptionService> _adoptionService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDataShaper<AnimalDto> dataShaperAnimal)
        {
            _animalService = new Lazy<IAnimalService>(() => new AnimalService(repositoryManager, loggerManager, mapper, dataShaperAnimal));
            _adopterService = new Lazy<IAdopterService>(() => new AdopterService(repositoryManager,loggerManager, mapper));
            _adoptionService = new Lazy<IAdoptionService>(() => new AdoptionService(repositoryManager, loggerManager));
            _volunteerService = new Lazy<IVolunteerService>(() => new VolunteerService(repositoryManager, loggerManager, mapper));
        }

        public IAnimalService AnimalService => _animalService.Value;

        public IVolunteerService VolunteerService => _volunteerService.Value;

        public IAdopterService AdopterService => _adopterService.Value;

        public IAdoptionService AdoptionService => _adoptionService.Value;
    }
}
