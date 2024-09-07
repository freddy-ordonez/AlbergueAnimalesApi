using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums.Volunteer;

namespace Shared.Dto.Volunteer
{
    public abstract record VolunteerForManipulation
    {
        [Required(ErrorMessage = "Volunteer name is required")]
        [MaxLength(20, ErrorMessage = "Maximun length for name is 20 characters")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Volunter last name is required")]
        [MaxLength(20, ErrorMessage = "Maximun length for Last Name is 20 characters")]
        public string? LastName { get; init; }

        [Required(ErrorMessage = "Volunter email is required")]
        [MaxLength(100, ErrorMessage = "Maximun length for email is 100 characters")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Volunteer state is required")]
        public VolunteerState? State { get; init; }
    }
}