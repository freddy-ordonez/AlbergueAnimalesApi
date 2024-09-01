using Domain.Enums.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public record AnimalDto(Guid Id, string Name, AnimalType Type, AnimalState State, DateTime DateDelivery);
}
