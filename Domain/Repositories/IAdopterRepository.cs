using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAdopterRepository
    {
        Task<IEnumerable<Adopter>> GetAdoptersAsync(bool trackChanges);
        Task<Adopter> GetAdopterAsync(Guid adopterId, bool trackChanges);
        void CreateAdopter(Adopter adopter);
        void DeleteAdopter(Adopter adopter);
    }
}
