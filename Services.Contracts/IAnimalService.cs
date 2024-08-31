using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Contracts
{
    public interface IAnimalService
    {
        IEnumerable<Animal> GetAllAnimals(bool trackChanges);
    }
}
