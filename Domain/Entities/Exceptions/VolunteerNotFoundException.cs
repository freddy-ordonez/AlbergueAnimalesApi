using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    public class VolunteerNotFoundException : NotFoundException
    {
        public VolunteerNotFoundException(Guid volunteerId) : base($"The volunteer id: {volunteerId} doens't exist in the database.")
        {
        }
    }
}