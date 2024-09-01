using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums.Animal;

namespace Shared.Dto.Animal
{
    public record AnimalForCreationDto
    {
       public string? Name {get; init;}
       public AnimalType Type {get; init;}
       public AnimalState State {get; init;} 
    }
}