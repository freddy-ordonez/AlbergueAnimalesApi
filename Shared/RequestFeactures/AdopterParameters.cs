using Domain.Enums.Adopter;

namespace Shared.RequestFeactures
{
    public class AdopterParameters : RequestParameters
    {
        public AdopterParameters() => OrderBy = "name";
        public AdopterState? State { get; set; }
        public string? SearchTerm { get; set; }
    }
}