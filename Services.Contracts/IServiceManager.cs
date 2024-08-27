using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAnimalService AnimalService { get; }
        IVolunteerService VolunteerService { get; }
        IAdopterService AdopterService { get; }
        IAdoptionService AdoptionService { get; }
    }
}
