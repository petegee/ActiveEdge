using System;
using ActiveEdge.Read.Model.Session;
using Shared;

namespace ActiveEdge.Read.Query.Sessions
{
    public class GetSessionById : IQueryForSingleOrDefault<SessionModel>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetSessionById(Guid sessionId)
        {
            SessionId = sessionId;
        }

        public Guid SessionId { get; set; }
    }
}