using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Contracts
{
    public interface IVolunteerService
    {
        IEnumerable<Volunteer> GetVolunteers(bool trackChanges);
    }
}
