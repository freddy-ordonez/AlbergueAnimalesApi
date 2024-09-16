using System;
using Domain.Enums.Volunteer;

namespace Shared.RequestFeactures;

public class VolunteerParameters : RequestParameters
{
    public VolunteerState? State { get; set; }
    public string? SearchTerm { get; set; }
}
