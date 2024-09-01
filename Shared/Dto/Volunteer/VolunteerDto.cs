using Domain.Enums.Volunteer;

namespace Shared.Dto.Volunteer
{
    public record VolunteerDto {
        public Guid Id {get; init;}
        public string? Name {get; init;} 
        public string? LastName {get; init;} 
        public string? Email {get; init;}
        public VolunteerState State {get; init;}
    }
}