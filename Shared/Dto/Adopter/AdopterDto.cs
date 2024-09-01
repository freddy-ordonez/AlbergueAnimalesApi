using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums.Adopter;

namespace Shared.Dto.Adopter
{
    public record AdopterDto(Guid Id, string Name, string LastName, string Email, AdopterState State);
}