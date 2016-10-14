using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Command.Session;
using Domain.Event;
using Domain.Model;
using Marten;
using Shared;

namespace Domain.Sagas
{
    public class SessionSaga : IAsyncCommandHandler<CreateNewSession>
        ,IAsyncCommandHandler<AddPlanToSession>
        , IAsyncCommandHandler<UpdateSession>
        //, ICommandHandler<DeleteSessionCommand>
    {
        private readonly IDocumentSession _session;
        private readonly ILoggedOnUser _loggedOnUser;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SessionSaga(IDocumentSession session, ILoggedOnUser loggedOnUser, IMapper mapper)
        {
            _session = session;
            _loggedOnUser = loggedOnUser;
            _mapper = mapper;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public async Task<Guid> Handle(CreateNewSession message)
        {
            if (message.OrganizationId.HasValue == false)
            {
                throw new BusinessRuleException("You cannot create a session if an organization is not specified.");
            }

            if (message.Date.HasValue == false)
            {
                throw new BusinessRuleException("A date must be supplied when creating a session.");
            }

            var client = await _session.Events.AggregateStreamAsync<Client>(message.ClientId);

            var sessionCreatedEvent = _mapper.Map<CreateNewSession, SessionCreated>(message);

            sessionCreatedEvent.ContraIndications = client.ContraIndications.Conditions.ToList();
            sessionCreatedEvent.ClientFullName = client.FullName;

            var sessionId = _session.Events.StartStream<Session>(sessionCreatedEvent);
            
            await _session.SaveChangesAsync();

            return sessionId;
        }

        /// <summary>Handles an asynchronous request</summary>
        /// <param name="message">The request message</param>
        /// <returns>A task representing the response from the request</returns>
        public async Task<Guid> Handle(AddPlanToSession message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var session = await _session.Events.AggregateStreamAsync<Session>(message.Id);

            var domainEvent = _mapper.Map<PlanAddedToSession>(message);

            domainEvent.UserId = _loggedOnUser.Id;

            _session.Events.Append(message.Id, domainEvent);

            await _session.SaveChangesAsync();

            return session.Id;

        }

        /// <summary>Handles an asynchronous request</summary>
        /// <param name="message">The request message</param>
        /// <returns>A task representing the response from the request</returns>
        public async Task<Guid> Handle(UpdateSession message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var session = await _session.Events.AggregateStreamAsync<Session>(message.Id);
            
            var domainEvent = _mapper.Map(message, session);

            _session.Events.Append(message.Id, domainEvent);

            await _session.SaveChangesAsync();

            return session.Id; 
        }

        ///// <summary>Handles a request</summary>
        ///// <param name="message">The request message</param>
        ///// <returns>Response from the request</returns>
        //public int Handle(DeleteSessionCommand message)
        //{
        //    var session = _session.Query<Session>().SingleOrDefault(s => s.Id == message.Id);

        //    if (session == null)
        //    {
        //        throw new BusinessRuleException($"The session with id: '{message.Id}' either does not exist or you are not authorised to view it.");
        //    }

        //    _session.Delete(session);

        //    _session.SaveChanges();

        //    return session.Id;
        //}



    }
}