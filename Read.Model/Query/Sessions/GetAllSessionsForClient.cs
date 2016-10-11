using System;
using ActiveEdge.Read.Model.Session;
using Shared;

namespace ActiveEdge.Read.Query.Sessions
{
    public class GetAllSessionsForClient : IQuery<SessionModelListItem>
    {
        public Guid ClientId { get; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetAllSessionsForClient(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}