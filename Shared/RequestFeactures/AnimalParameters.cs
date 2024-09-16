using Domain.Enums.Animal;

namespace Shared.RequestFeactures
{
    public class AnimalParameters : RequestParameters
    {
        public AnimalParameters() => OrderBy = "name";
        public AnimalState? State { get; set; }
        public string? SearchTerm { get; set; }
    }
}