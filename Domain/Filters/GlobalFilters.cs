using System;
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
            return FilterForOrganization(domainModels, loggedOnUser.OrganizationId);

        }

        public static IQueryable<T> FilterForOrganization<T>(this IQueryable<T> domainModels, Guid? organizationId)
            where T : IAmLinkedToAnOrganization
        {
            return organizationId.HasValue
                ? domainModels.Where(x => x.OrganizationId == organizationId)
                : domainModels;
        }
    }
}