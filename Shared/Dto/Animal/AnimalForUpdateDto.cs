using Domain.Enums.Animal;

namespace Shared.Dto.Animal
{
    public record AnimalForUpdateDto
    {
        public string? Name {get; init;}
        public AnimalType Type {get; init;}
        public AnimalState State {get; init;}
        public DateTime DateDelivery {get; init;}
    }
}