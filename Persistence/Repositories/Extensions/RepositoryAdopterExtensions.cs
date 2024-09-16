using System;
using Domain.Entities;
using Domain.Enums.Adopter;

namespace Persistence.Repositories.Extensions;

public static class RepositoryAdopterExtensions
{
    public static IQueryable<Adopter> FilterAdopter(this IQueryable<Adopter> adopters, AdopterState? adopterState) =>
        adopterState.HasValue ? adopters.Where(a => a.State == adopterState.Value) : adopters;
    
    public static IQueryable<Adopter> Search(this IQueryable<Adopter> adopters, string searchTerm)
    {
        if(string.IsNullOrWhiteSpace(searchTerm))
            return adopters;
        
        var ToLowerTerm = searchTerm.Trim().ToLower();

        return adopters.Where(a => a.Name.ToLower().Contains(ToLowerTerm));
    }

}
