using System;
using ActiveEdge.Read.Model;
using Shared;

namespace ActiveEdge.Read.Query.Clients
{
    public class GetAllClientsForOrganization : IQuery<ClientModel>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetAllClientsForOrganization(Guid? organizationId)
        {
            OrganizationId = organizationId;
        }

        public Guid? OrganizationId { get; }
    }
}