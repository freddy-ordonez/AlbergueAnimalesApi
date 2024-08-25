using Domain.Enums.Adoption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adoption
    {
        public Guid Id { get; set; }

        public Guid AnimalId { get; set; }
        public Animal? Animal { get; set; }

        public Guid VolunteerId { get; set; }
        public Volunteer? Volunteer { get; set; }

        public Guid AdopterId { get; set; }
        public Adopter? Adopter { get; set; }

        public DateTime DateAdoption { get; set; } = DateTime.Now;

        public State State { get; set; }
    }
}
