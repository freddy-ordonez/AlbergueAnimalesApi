using Domain.Enums.Animal;

namespace Shared.RequestFeactures
{
    public class AnimalParameters : RequestParameters
    {
        public AnimalState? State { get; set; }
    }
}