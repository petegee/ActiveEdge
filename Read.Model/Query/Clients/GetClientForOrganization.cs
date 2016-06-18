using ActiveEdge.Read.Model;
using Shared;

namespace ActiveEdge.Read.Query.Clients
{
    public class GetClientForOrganization : IQueryForSingleOrDefault<ClientModel>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetClientForOrganization(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}