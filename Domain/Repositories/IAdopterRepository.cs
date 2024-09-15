using Domain.Entities;
using Shared.RequestFeactures;

namespace Domain.Repositories
{
    public interface IAdopterRepository
    {
        Task<PagedList<Adopter>> GetAdoptersAsync(AdopterParameters adopterParameters, bool trackChanges);
        Task<Adopter> GetAdopterAsync(Guid adopterId, bool trackChanges);
        void CreateAdopter(Adopter adopter);
        void DeleteAdopter(Adopter adopter);
    }
}
