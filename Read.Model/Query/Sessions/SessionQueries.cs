using System.Collections.Generic;
using System.Linq;
using ActiveEdge.Read.Model;
using AutoMapper;
using Domain.Context;
using Shared;

namespace ActiveEdge.Read.Query.Sessions
{
    public class SessionQueries : IQueryHandler<GetAllSessions, SessionModelListItem>,
        IQueryHandler<GetAllSessionsForClient, SessionModelListItem>,
        IQueryForSingleHandler<GetSessionById, SessionModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SessionQueries(IApplicationDbContext dbContext, MapperConfiguration mapperConfiguration, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapperConfiguration = mapperConfiguration;
            _mapper = mapper;
            _dbContext.EnableOrganizationTenant();
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public SessionModel Handle(GetSessionById message)
        {
            var session = _dbContext.Sessions.Single(s => s.Id == message.SessionId);
                    
            return  _mapper.Map<SessionModel>(session);
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<SessionModelListItem> Handle(GetAllSessions message)
        {
            return _dbContext.Sessions.ProjectToList<SessionModelListItem>(_mapperConfiguration);
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<SessionModelListItem> Handle(GetAllSessionsForClient message)
        {
            return
                _dbContext.Sessions.Where(session => session.ClientId == message.ClientId)
                    .ProjectToList<SessionModelListItem>(_mapperConfiguration);
        }
    }
}