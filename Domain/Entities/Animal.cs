using Domain.Enums.Animal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Animal name is required")]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Animal type is required")]
        [MaxLength(20)]
        public Enums.Animal.Type? Type { get; set; }

        [Required(ErrorMessage = "Animal state is required")]
        [MaxLength(20)]
        public State? State { get; set; }

        public DateTime? DateDelivery { get; set; }
    }
}
