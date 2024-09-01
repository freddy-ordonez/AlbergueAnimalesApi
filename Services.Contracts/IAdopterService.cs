using Shared.Dto.Adopter;

namespace Services.Contracts
{
    public interface IAdopterService
    {
        IEnumerable<AdopterDto> GetAdopters(bool trackChanges);
        AdopterDto GetAdopter(Guid adopterId, bool trackChanges);
    }
}
