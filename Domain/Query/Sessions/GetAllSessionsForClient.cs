using Domain.Model;

namespace Domain.Query.Sessions
{
    public class GetAllSessionsForClient : IQuery<Session>
    {
        public int ClientId { get; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GetAllSessionsForClient(int clientId)
        {
            ClientId = clientId;
        }
    }
}