using System;
using System.Linq;
using System.Security.Claims;

namespace Shared
{
    public class LoggedOnUser : ILoggedOnUser
    {
        public Guid? OrganizationId
        {
            get
            {

                var identity = (ClaimsIdentity)ClaimsPrincipal.Current.Identity;
                var claims = identity.Claims;

                var organizationClaim = claims.FirstOrDefault(claim => claim.Type == ActiveEdgeClaims.OrganizationId);

                return organizationClaim == null ? (Guid?) null : Guid.Parse(organizationClaim.Value);
            }
        }
    }
}
