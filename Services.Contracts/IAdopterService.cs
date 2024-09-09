using Domain.Entities;
using Shared.Dto.Adopter;

namespace Services.Contracts
{
    public interface IAdopterService
    {
        Task<IEnumerable<AdopterDto>> GetAdoptersAsync(bool trackChanges);
        Task<AdopterDto> GetAdopterAsync(Guid adopterId, bool trackChanges);
        Task<AdopterDto> CreateAdopterAsync(AdopterForCreationDto adopter);
        Task DeleteAdopterAsync(Guid id, bool trackChanges);
        Task UpdateAdopterAsync(Guid id, AdopterForUpdateDto adopter, bool trackChanges);
        Task<(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity)> GetAdopterForPatchAsync(Guid id, bool trackChanges);
        Task SaveChangesForPatchAsync(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity);

    }
}
