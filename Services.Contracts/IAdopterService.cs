using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Contracts
{
    public interface IAdopterService
    {
        IEnumerable<Adopter> GetAdopters(bool trackChanges);
        Adopter GetAdopter(Guid adopterId, bool trackChanges);
    }
}
