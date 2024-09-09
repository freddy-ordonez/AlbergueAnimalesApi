using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IAnimalRepository> _animalRepository;
        private readonly Lazy<IVolunteerRepository> _volunteerRepository;
        private readonly Lazy<IAdopterRepository> _adopterRepository;
        private readonly Lazy<IAdoptionRepository> _adoptionRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            _animalRepository = new Lazy<IAnimalRepository>( () => new AnimalRepository(repositoryContext));
            _adopterRepository = new Lazy<IAdopterRepository>( () => new AdopterRepository(repositoryContext));
            _volunteerRepository = new Lazy<IVolunteerRepository>( () => new VolunteerRepository(repositoryContext));
            _adoptionRepository = new Lazy<IAdoptionRepository>(() => new AdoptionRepository(repositoryContext));
        }

        public IAnimalRepository Animal => _animalRepository.Value;

        public IAdopterRepository Adopter => _adopterRepository.Value;

        public IVolunteerRepository Volunteer => _volunteerRepository.Value;

        public IAdoptionRepository Adoption => _adoptionRepository.Value;

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
