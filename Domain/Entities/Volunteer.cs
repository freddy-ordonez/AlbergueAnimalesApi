using Domain.Enums.Volunteer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Volunteer
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Volunteer name is required")]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Volunter last name is required")]
        [MaxLength(20)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Volunter email is required")]
        [MaxLength(20)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Volunteer state is required")]
        [MaxLength(20)]
        public State State { get; set; }
    }
}
