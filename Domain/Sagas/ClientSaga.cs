using System.Linq;
using AutoMapper;
using Domain.Command.Client;
using Domain.Context;
using Domain.Model;
using Shared;

namespace Domain.Sagas
{
    public class ClientSaga : ICommandHandler<RegisterNewClientCommand>, ICommandHandler<UpdateClientCommand>,
        ICommandHandler<DeleteClientCommand>
    {
        private readonly ILoggedOnUser _loggedOnUser;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ClientSaga(IApplicationDbContext dbContext, IMapper mapper, ILoggedOnUser loggedOnUser)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _loggedOnUser = loggedOnUser;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(DeleteClientCommand message)
        {
            var customer = _dbContext.Clients.Find(message.ClientId);
            _dbContext.Clients.Remove(customer);
            _dbContext.SaveChanges();

            return customer.Id;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(RegisterNewClientCommand message)
        {
            if (_loggedOnUser.OrganizationId == 0)
            {
                throw new BusinessRuleException("You cannot register a client if an organization is not specified.");
            }

            var customerDomain = _mapper.Map<RegisterNewClientCommand, Client>(message);

            customerDomain.OrganizationId = _loggedOnUser.OrganizationId;

            _dbContext.Clients.Add(customerDomain);

            _dbContext.SaveChanges();

            return customerDomain.Id;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(UpdateClientCommand message)
        {
            var client = _dbContext.Clients.Single(c => c.Id == message.Id);

            _mapper.Map(message, client);
            _dbContext.SaveChanges();

            return client.Id;
        }
    }
}