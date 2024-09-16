using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using Domain.Entities;
using Domain.Enums.Volunteer;

namespace Persistence.Repositories.Extensions;

public static class RepositoryVolunteerExtensions
{
    public static IQueryable<Volunteer> FilterVolunteer(this IQueryable<Volunteer> volunteers, VolunteerState? volunteerState) =>
        volunteerState.HasValue ? volunteers.Where(v => v.State == volunteerState.Value) : volunteers;
    
    public static IQueryable<Volunteer> Search(this IQueryable<Volunteer> volunteers, string searchTerm)
    {
        if(string.IsNullOrWhiteSpace(searchTerm))
            return volunteers;
        
        var toLowerTerm = searchTerm.Trim().ToLower();

        return volunteers.Where(v => v.Name.ToLower().Contains(toLowerTerm));
    } 

    //Utilizamos el paquete de System.Linq.Dynamic.Core para el sort
    public static IQueryable<Volunteer> Sort(this IQueryable<Volunteer> volunteers, string OrderByQueryString)
    {
        if(string.IsNullOrWhiteSpace(OrderByQueryString))
            return volunteers.OrderBy(v => v.Name);
        
        var orderParams = OrderByQueryString.Trim().Split(",");
        var propertyInfos = typeof(Volunteer).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach(var param in orderParams)
        {
            if(string.IsNullOrWhiteSpace(param))
                continue;
            
            var propetryFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propetryFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if(objectProperty is null)
                continue;
            
            var direction = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        if(string.IsNullOrWhiteSpace(orderQuery))
            return volunteers.OrderBy(v => v.Name);
        
        return volunteers.OrderBy(orderQuery);
    }
}
