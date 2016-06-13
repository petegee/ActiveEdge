using Domain.Model;

namespace Domain.Query.Sessions
{
    public class GetSessionById : IQueryForSingleOrDefault<Session>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetSessionById(int sessionId)
        {
            SessionId = sessionId;
        }

        public int SessionId { get; set; }
    }
}