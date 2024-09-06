using System.ComponentModel.DataAnnotations;
using Domain.Enums.Adopter;

namespace Shared.Dto.Adopter
{
    public abstract record AdopterForManipulation
    {
        [Required(ErrorMessage = "Adopter name is required")]
        [MaxLength(20, ErrorMessage = "Maximum legth for the Name is 20 characters")]
        public string? Name {get; init;}

        [Required(ErrorMessage = "Adopter last name is required")]
        [MaxLength(20, ErrorMessage = "Maximum legth for the LastName is 20 characters")]
        public string? LastName {get; init;} 

        [Required(ErrorMessage = "Adopter email is required")]
        [MaxLength(100, ErrorMessage = "Maximum legth for the Email is 100 characters")]
        public string? Email {get; init;}

        [Required(ErrorMessage = "Adopter State is required")]
        public AdopterState? State {get; init;}
    }
}