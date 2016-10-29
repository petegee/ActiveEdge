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
                var organizationClaim = Identity.Claims.FirstOrDefault(claim => claim.Type == ActiveEdgeClaims.OrganizationId);

                return organizationClaim == null ? (Guid?) null : Guid.Parse(organizationClaim.Value);
            }
        }

        public string UserName
        {
            get
            {
                var nameIdentifier = Identity.Claims.First(claim => claim.Type == ClaimTypes.Name);

                return nameIdentifier.Value;
            }
        }

        public string Id
        {
            get
            {
                var nameIdentifier = Identity.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier);

                return nameIdentifier.Value;
            }
        }

        public ClaimsIdentity Identity => (ClaimsIdentity) ClaimsPrincipal.Current.Identity;

        public bool IsAuthenticated => Identity.IsAuthenticated;
    }
}
