using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IAnimalRepository Animal { get; }
        IAdopterRepository Adopter { get; }
        IVolunteerRepository Volunteer { get; }
        IAdoptionRepository Adoption { get; }

        void Save();
    }
}
