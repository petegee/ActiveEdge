using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Command.Client;
using Domain.Event;
using Domain.Model;
using Marten;
using MediatR;
using Shared;

namespace Domain.Sagas
{
   

    public class ClientSaga : 
        IAsyncCommandHandler<RegisterNewClient>
        , IAsyncCommandHandler<UpdateClient>
        //ICommandHandler<DeleteClientCommand>
    {
        private readonly ILoggedOnUser _loggedOnUser;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ClientSaga(IDocumentSession session, IMapper mapper, ILoggedOnUser loggedOnUser)
        {
            _session = session;
            _mapper = mapper;
            _loggedOnUser = loggedOnUser;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        //public int Handle(DeleteClientCommand message)
        //{
        //    var customer = _session.Load<Client>(message.ClientId);

        //    _session.Delete(customer);
        //    _session.SaveChanges();

        //    return customer.Id;
        //}

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public async Task<Guid> Handle(RegisterNewClient message)
        {
            if (message.OrganizationId.HasValue == false)
            {
                throw new BusinessRuleException("You cannot register a client if an organization is not specified.");
            }
            
            var clientRegisteredEvent = _mapper.Map<RegisterNewClient, ClientRegistered>(message);
            
            var clientId = _session.Events.StartStream<Client>(clientRegisteredEvent);

            await _session.SaveChangesAsync();

            return clientId;
        }


        /// <summary>Handles an asynchronous request</summary>
        /// <param name="message">The request message</param>
        /// <returns>A task representing the response from the request</returns>
        public async Task<Guid> Handle(UpdateClient message)
        {
            var clientUpdated = _mapper.Map<UpdateClient, ClientUpdated>(message);

            _session.Events.Append(message.Id, clientUpdated);

            await _session.SaveChangesAsync();

            return message.Id;
        }
    }
}