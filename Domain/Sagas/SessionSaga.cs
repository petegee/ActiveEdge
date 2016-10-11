//using System.Linq;
//using AutoMapper;
//using Domain.Command.Session;
//using Domain.Model;
//using Marten;
//using Shared;

//namespace Domain.Sagas
//{
//    public class SessionSaga : ICommandHandler<CreateNewSessionCommand>, ICommandHandler<UpdateSessionCommand>, ICommandHandler<DeleteSessionCommand>
//    {
//        private readonly IDocumentSession _session;
//        private readonly ILoggedOnUser _loggedOnUser;
//        private readonly IMapper _mapper;

//        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
//        public SessionSaga(IDocumentSession session, ILoggedOnUser loggedOnUser, IMapper mapper)
//        {
//            _session = session;
//            _loggedOnUser = loggedOnUser;
//            _mapper = mapper;
//        }

//        /// <summary>Handles a request</summary>
//        /// <param name="message">The request message</param>
//        /// <returns>Response from the request</returns>
//        public int Handle(CreateNewSessionCommand message)
//        {
//            if (_loggedOnUser.OrganizationId.HasValue == false)
//            {
//                throw new BusinessRuleException("You cannot create a session if an organization is not specified.");
//            }
            
//            var domain = _mapper.Map<Session>(message);

//            domain.OrganizationId = _loggedOnUser.OrganizationId.Value;

//            _session.Store(domain);
//            _session.SaveChanges();

//            return domain.Id;
//        }

//        /// <summary>Handles a request</summary>
//        /// <param name="message">The request message</param>
//        /// <returns>Response from the request</returns>
//        public int Handle(UpdateSessionCommand message)
//        {
//            var session = _session.Query<Session>().SingleOrDefault(s => s.Id == message.Id);

//            if (session == null)
//            {
//                throw new BusinessRuleException($"The session with id: '{message.Id}' either does not exist or you are not authorised to view it.");
//            }

//            _mapper.Map(message, session);

//            _session.SaveChanges();

//            return session.Id;
//        }

//        /// <summary>Handles a request</summary>
//        /// <param name="message">The request message</param>
//        /// <returns>Response from the request</returns>
//        public int Handle(DeleteSessionCommand message)
//        {
//            var session = _session.Query<Session>().SingleOrDefault(s => s.Id == message.Id);

//            if (session == null)
//            {
//                throw new BusinessRuleException($"The session with id: '{message.Id}' either does not exist or you are not authorised to view it.");
//            }

//            _session.Delete(session);

//            _session.SaveChanges();

//            return session.Id;
//        }
//    }
//}