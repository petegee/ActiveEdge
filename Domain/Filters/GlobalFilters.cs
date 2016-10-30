using System;
using System.Linq;
using Domain.Model;
using Shared;

namespace Domain.Filters
{
    public static class GlobalFilters
    {
        public static IQueryable<ApplicationUser> FilterForOrganization(this IQueryable<ApplicationUser> users, ILoggedOnUser loggedOnUser)
        {
            return loggedOnUser.OrganizationId.HasValue
                 ? users.Where(x => x.OrganizationId == loggedOnUser.OrganizationId)
                 : users;

        }

        public static IQueryable<T> FilterForOrganization<T>(this IQueryable<T> domainModels, ILoggedOnUser loggedOnUser)
            where T : IAmLinkedToAnOrganization
        {
            return FilterFor(domainModels, loggedOnUser.OrganizationId);

        }

        public static IQueryable<T> FilterFor<T>(this IQueryable<T> domainModels, Guid? organizationId)
            where T : IAmLinkedToAnOrganization
        {
            return organizationId.HasValue
                ? domainModels.Where(x => x.OrganizationId == organizationId)
                : domainModels;
        }
    }
}