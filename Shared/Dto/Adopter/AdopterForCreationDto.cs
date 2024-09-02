using Domain.Enums.Adopter;

namespace Shared.Dto.Adopter
{
    public class AdopterForCreationDto
    {
        public string? Name {get; init;}
        public string? LastName {get; init;} 
        public string? Email {get; init;}
        public AdopterState State {get; init;}
    }
}