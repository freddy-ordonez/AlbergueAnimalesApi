using Domain.Entities;
using Domain.Enums.Animal;

namespace Persistence.Repositories.Extensions;

public static class RepositoryAnimalExtensions
{
    public static IQueryable<Animal> FilterAnimal(this IQueryable<Animal> animals, AnimalState? state) => 
        state.HasValue ? animals.Where(a => a.State == state.Value) : animals;
    
    public static IQueryable<Animal> Search(this IQueryable<Animal> animals, string searchTerm)
    {
        if(string.IsNullOrWhiteSpace(searchTerm))
            return animals;
        
        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return animals.Where(e => e.Name.ToLower().Contains(lowerCaseTerm)); 
    }
     

}
