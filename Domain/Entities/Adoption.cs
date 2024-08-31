using Domain.Enums.Adoption;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adoption
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Animal))]
        public Guid AnimalId { get; set; }
        public Animal? Animal { get; set; }

        [ForeignKey(nameof(Volunteer))]
        public Guid VolunteerId { get; set; }
        public Volunteer? Volunteer { get; set; }

        [ForeignKey(nameof(Adopter))]
        public Guid AdopterId { get; set; }
        public Adopter? Adopter { get; set; }

        public DateTime DateAdoption { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Adoption state is required")]
        [MaxLength(20)]
        public AdoptionState State { get; set; }
    }
}
