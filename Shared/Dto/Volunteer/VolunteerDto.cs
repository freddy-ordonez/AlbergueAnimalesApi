using Domain.Enums.Volunteer;

namespace Shared.Dto.Volunteer
{
    public record VolunteerDto(Guid Id, string Name, string LastName, string Email, VolunteerState State);
}