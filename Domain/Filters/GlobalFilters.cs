using System.Linq;
using Domain.Model;
using Shared;

namespace Domain.Filters
{
    public static class GlobalFilters
    {
        public static IQueryable<T> FilterForOrganization<T>(this IQueryable<T> domainModels, ILoggedOnUser loggedOnUser)
            where T : IAmLinkedToAnOrganization
        {
            return loggedOnUser.OrganizationId.HasValue
                ? domainModels.Where(x => x.OrganizationId == loggedOnUser.OrganizationId)
                : domainModels;
        }
    }
}