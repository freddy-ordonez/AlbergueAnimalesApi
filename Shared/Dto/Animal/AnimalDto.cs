using Domain.Enums.Animal;

namespace Shared.Dto
{
    public record AnimalDto {
       public Guid Id {get; init;}
       public string? Name {get; init;}
       public AnimalType Type {get; init;}
       public AnimalState State {get; init;}
       public DateTime DateDelivery {get; init;}
    }
}
