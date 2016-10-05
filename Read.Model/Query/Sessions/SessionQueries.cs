using System.Collections.Generic;
using System.Linq;
using ActiveEdge.Read.Model.Session;
using AutoMapper;
using Domain.Model;
using Marten;
using Shared;

namespace ActiveEdge.Read.Query.Sessions
{
    public class SessionQueries : IQueryHandler<GetAllSessions, SessionModelListItem>,
        IQueryHandler<GetAllSessionsForClient, SessionModelListItem>,
        IQueryForSingleHandler<GetSessionById, SessionModel>
    {
        private readonly ILoggedOnUser _loggedOnUser;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SessionQueries(IDocumentSession session,  IMapper mapper,
            ILoggedOnUser loggedOnUser)
        {
            _session = session;
            _mapper = mapper;
            _loggedOnUser = loggedOnUser;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public SessionModel Handle(GetSessionById message)
        {
            var session = _session.Query<Session>().SingleOrDefault(s => s.Id == message.SessionId);

            return session == null ? null : _mapper.Map<SessionModel>(session);
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<SessionModelListItem> Handle(GetAllSessions message)
        {
            var sessions =
                _session.Query<Session>().Where(session => session.Organization.Id == _loggedOnUser.OrganizationId)
                    .ToList();

            var sessionModels = _mapper.Map<List<Session>, List<SessionModelListItem>>(sessions);

            return sessionModels;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<SessionModelListItem> Handle(GetAllSessionsForClient message)
        {
            var sessions = _session.Query<Session>()
                .Where(session => session.Client.Id == message.ClientId)
                .ToList();

            var sessionModels = _mapper.Map<List<Session>, List<SessionModelListItem>>(sessions);

            return sessionModels;
        }
    }
}