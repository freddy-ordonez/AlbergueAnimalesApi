using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAdopterRepository
    {
        IEnumerable<Adopter> GetAdopters(bool trackChanges);
        Adopter GetAdopter(Guid adopterId, bool trackChanges);
        void CreateAdopter(Adopter adopter);
    }
}
