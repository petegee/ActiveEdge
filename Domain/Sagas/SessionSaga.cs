using System.Linq;
using AutoMapper;
using Domain.Command.Session;
using Domain.Context;
using Domain.Model;
using Shared;

namespace Domain.Sagas
{
    public class SessionSaga : ICommandHandler<CreateNewSessionCommand>, ICommandHandler<UpdateSessionCommand>, ICommandHandler<DeleteSessionCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILoggedOnUser _loggedOnUser;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SessionSaga(IApplicationDbContext dbContext, ILoggedOnUser loggedOnUser, IMapper mapper)
        {
            _dbContext = dbContext;
            _dbContext.EnableOrganizationTenant();
            _loggedOnUser = loggedOnUser;
            _mapper = mapper;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(CreateNewSessionCommand message)
        {
            var domain = _mapper.Map<Session>(message);

            domain.OrganizationId = _loggedOnUser.OrganizationId;

            _dbContext.Sessions.Add(domain);
            _dbContext.SaveChanges();

            return domain.Id;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(UpdateSessionCommand message)
        {
            var session = _dbContext.Sessions.SingleOrDefault(s => s.Id == message.Id);

            if (session == null)
            {
                throw new BusinessRuleException($"The session with id: '{message.Id}' either does not exist or you are not authorised to view it.");
            }

            _mapper.Map(message, session);
            
            _dbContext.SaveChanges();

            return session.Id;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(DeleteSessionCommand message)
        {
            var session = _dbContext.Sessions.SingleOrDefault(s => s.Id == message.Id);

            if (session == null)
            {
                throw new BusinessRuleException($"The session with id: '{message.Id}' either does not exist or you are not authorised to view it.");
            }

            _dbContext.Sessions.Remove(session);

            _dbContext.SaveChanges();

            return session.Id;
        }
    }
}