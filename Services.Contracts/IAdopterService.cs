using Domain.Entities;
using Shared.Dto.Adopter;
using Shared.RequestFeactures;

namespace Services.Contracts
{
    public interface IAdopterService
    {
        Task<(IEnumerable<AdopterDto> adopterDtos, MetaData metaData)> GetAdoptersAsync(AdopterParameters adopterParameters, bool trackChanges);
        Task<AdopterDto> GetAdopterAsync(Guid adopterId, bool trackChanges);
        Task<AdopterDto> CreateAdopterAsync(AdopterForCreationDto adopter);
        Task DeleteAdopterAsync(Guid id, bool trackChanges);
        Task UpdateAdopterAsync(Guid id, AdopterForUpdateDto adopter, bool trackChanges);
        Task<(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity)> GetAdopterForPatchAsync(Guid id, bool trackChanges);
        Task SaveChangesForPatchAsync(AdopterForUpdateDto adopterToPatch, Adopter adopterEntity);

    }
}
