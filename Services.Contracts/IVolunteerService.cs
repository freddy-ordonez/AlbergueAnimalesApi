﻿using Domain.Entities;
using Shared.Dto.Volunteer;

namespace Services.Contracts
{
    public interface IVolunteerService
    {
        IEnumerable<VolunteerDto> GetVolunteers(bool trackChanges);
        VolunteerDto GetVolunteer(Guid volunterId, bool trackChanges);
    }
}
