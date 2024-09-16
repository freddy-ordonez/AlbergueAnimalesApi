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
}
