using System.Linq;
using Domain.Model;
using MediatR;

namespace Domain.Query.User
{
    public class FindAllUsersForOrganization : IRequest<IQueryable<ApplicationUser>>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public FindAllUsersForOrganization(int organizationId)
        {
            OrganizationId = organizationId;
        }

        public int OrganizationId { get; set; }
    }
}