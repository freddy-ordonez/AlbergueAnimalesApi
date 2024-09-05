using Domain.Entities;
using Shared.Dto.Adopter;

namespace Services.Contracts
{
    public interface IAdopterService
    {
        IEnumerable<AdopterDto> GetAdopters(bool trackChanges);
        AdopterDto GetAdopter(Guid adopterId, bool trackChanges);
        AdopterDto CreateAdopter(AdopterForCreationDto adopter);
        void DeleteAdopter(Guid id, bool trackChanges);
        void UpdateAdopter(Guid id, AdopterForUpdateDto adopter, bool trackChanges);
        (AdopterForUpdateDto adopterToPatch, Adopter adopterEntity) GetAdopterForPatch(Guid id, bool trackChanges);
        void SaveChangesForPatch(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity);

    }
}
