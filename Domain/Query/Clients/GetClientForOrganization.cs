using System.Linq;
using Domain.Model;
using MediatR;

namespace Domain.Query.Clients
{
    public class GetClientForOrganization : IRequest<IQueryable<Client>>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetClientForOrganization(int clientId, int? organizationId)
        {
            ClientId = clientId;
            OrganizationId = organizationId;
        }

        public int ClientId { get; set; }
        public int? OrganizationId { get; set; }
    }
}