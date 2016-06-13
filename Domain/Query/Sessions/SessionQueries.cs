using System.Linq;
using Domain.Context;
using Domain.Model;

namespace Domain.Query.Sessions
{
    public class SessionQueries : IQueryHandler<GetAllSessions, Session>, IQueryForSingleHandler<GetSessionById, Session>
    {
        private readonly IApplicationDbContext _dbContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SessionQueries(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.EnableOrganizationTenant();
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IQueryable<Session> Handle(GetAllSessions message)
        {
            return _dbContext.Sessions;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public Session Handle(GetSessionById message)
        {
            var session = _dbContext.Sessions.SingleOrDefault(s => s.Id == message.SessionId);

            return session;
        }
    }
}