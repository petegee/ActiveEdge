using System.Linq;
using Domain.Model;
using MediatR;

namespace Domain.Query.Clients
{
    public class GetClientForOrganization : IQueryForSingleOrDefault<Client>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetClientForOrganization(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}