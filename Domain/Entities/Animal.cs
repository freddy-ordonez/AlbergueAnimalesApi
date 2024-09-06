using Domain.Enums.Animal;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Animal name is required.")]
        [MaxLength(20, ErrorMessage = "Maximun length for the Name is 20 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Animal type is required")]
        [MaxLength(20, ErrorMessage = "Maximun length for the Type is 20 characters.")]
        public AnimalType? Type { get; set; }

        [Required(ErrorMessage = "Animal state is required")]
        [MaxLength(20, ErrorMessage = "Maximun length for the State is 20 characters.")]
        public AnimalState? State { get; set; }

        public DateTime? DateDelivery { get; set; } = DateTime.MinValue;
    }
}
