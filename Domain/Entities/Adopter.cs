using Domain.Enums.Adopter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adopter
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Adopter name is required")]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Adopter last name is required")]
        [MaxLength(20)]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Adopter email is required")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Adopter state is required")]
        [MaxLength(20)]
        public State State { get; set; }
    }
}
