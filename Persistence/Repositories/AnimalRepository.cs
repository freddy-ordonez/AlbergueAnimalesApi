﻿using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>, IAnimalRepository
    {
        public AnimalRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreateAnimal(Animal animal) => Create(animal);

        public void DeleteAnimal(Animal animal) => Delete(animal);

        public IEnumerable<Animal> GetAll(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(a => a.Name)
            .ToList();

        public Animal GetAnimal(Guid animalId, bool trackChanges) => 
            FinByCondition(a => a.Id.Equals(animalId), trackChanges)
            .SingleOrDefault();
    }
}
