using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
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

    public static IQueryable<Adopter> Sort(this IQueryable<Adopter> adopters, string orderByQueryString)
    {
        if(string.IsNullOrWhiteSpace(orderByQueryString))
            return adopters.OrderBy(a => a.Name);
        
        var orderParams = orderByQueryString.Trim().Split(",");
        var propertyInfos = typeof(Adopter).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach(var param in orderParams)
        {
            if(string.IsNullOrWhiteSpace(param))
                continue;
            
            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if(objectProperty is null)
                continue;
            
            var direction = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        if(string.IsNullOrWhiteSpace(orderQuery))
            return adopters.OrderBy(a => a.Name);
        Console.WriteLine(orderQuery);
        return adopters.OrderBy(orderQuery);
    }
}
