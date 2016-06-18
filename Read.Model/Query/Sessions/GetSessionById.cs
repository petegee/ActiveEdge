using ActiveEdge.Read.Model;
using Shared;

namespace ActiveEdge.Read.Query.Sessions
{
    public class GetSessionById : IQueryForSingleOrDefault<SessionModel>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetSessionById(int sessionId)
        {
            SessionId = sessionId;
        }

        public int SessionId { get; set; }
    }
}