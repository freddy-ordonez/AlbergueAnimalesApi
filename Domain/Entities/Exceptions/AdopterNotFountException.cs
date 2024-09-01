using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Exceptions
{
    public class AdopterNotFountException : NotFoundException
    {
        public AdopterNotFountException(Guid adopterId) : base($"The adopter id: {adopterId} doesn't exist in the database.")
        {
        }
    }
}