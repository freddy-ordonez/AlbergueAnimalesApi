using System.ComponentModel.DataAnnotations;
using Domain.Enums.Animal;

namespace Shared.Dto.Animal
{
    public abstract record AnimalForManipulation
    {
        [Required(ErrorMessage = "Animal name is required.")]
        [MaxLength(20, ErrorMessage = "Maximun length for the Name is 20 characters.")]
        public string? Name {get; init;}

        [Required(ErrorMessage = "Animal type is required")]
        public AnimalType? Type {get; init;}

        [Required(ErrorMessage = "Animal state is required")]
        public AnimalState? State {get; init;} 
    }
}