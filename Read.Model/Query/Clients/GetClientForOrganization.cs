using System;
using ActiveEdge.Read.Model;
using Shared;

namespace ActiveEdge.Read.Query.Clients
{
    public class GetClientForOrganization : IQueryForSingleOrDefault<ClientModel>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetClientForOrganization(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}