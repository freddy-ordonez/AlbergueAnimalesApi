using System.ComponentModel.DataAnnotations;

namespace Shared.Dto.Animal
{
    public record AnimalForUpdateDto : AnimalForManipulation
    {
        [Required(ErrorMessage = "The DateDelivery is required")]
        public DateTime? DateDelivery {get; init;}
    }
}