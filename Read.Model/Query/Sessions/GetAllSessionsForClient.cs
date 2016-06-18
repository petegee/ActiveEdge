using ActiveEdge.Read.Model;
using Shared;

namespace ActiveEdge.Read.Query.Sessions
{
    public class GetAllSessionsForClient : IQuery<SessionModelListItem>
    {
        public int ClientId { get; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetAllSessionsForClient(int clientId)
        {
            ClientId = clientId;
        }
    }
}