using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Model
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public Guid? ExternalLink { get; set; }
    }
}