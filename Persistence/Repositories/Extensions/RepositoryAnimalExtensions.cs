using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
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
     
     //Utilizamos el paquete de System.Linq.Dynamic.Core para el sort
    public static IQueryable<Animal> Sort(this IQueryable<Animal> animals, string orderByQueryString)
    {
        if(string.IsNullOrWhiteSpace(orderByQueryString))
            return animals.OrderBy(a => a.Name);
        
        var orderParams = orderByQueryString.Trim().Split(",");
        var propertyInfos = typeof(Animal).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
            return animals.OrderBy(a => a.Name);
        
        return animals.OrderBy(orderQuery);
    }
}
