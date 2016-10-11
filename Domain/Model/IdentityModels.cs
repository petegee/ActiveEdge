using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Shared;
using Shared.Authorization;

namespace Domain.Model
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            if (OrganizationId.HasValue)
            {
                userIdentity.AddClaim(new Claim(ActiveEdgeClaims.OrganizationId, OrganizationId.Value.ToString(), ClaimValueTypes.Integer32));
            }
            
            return userIdentity;
        }

        public Guid? OrganizationId { get; set; }
        

    }
}