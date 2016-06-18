using ActiveEdge.Read.Model;
using Shared;

namespace ActiveEdge.Read.Query.Clients
{
    public class GetAllClientsForOrganization : IQuery<ClientModel>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetAllClientsForOrganization(int? organizationId)
        {
            OrganizationId = organizationId;
        }

        public int? OrganizationId { get; }
    }
}