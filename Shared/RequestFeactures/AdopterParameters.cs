using Domain.Enums.Adopter;

namespace Shared.RequestFeactures
{
    public class AdopterParameters : RequestParameters
    {
        public AdopterState? State { get; set; }
    }
}