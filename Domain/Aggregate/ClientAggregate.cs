using AutoMapper;
using Domain.Command;
using Domain.Context;
using Domain.Model;

namespace Domain.Aggregate
{
    public class ClientAggregate : ICommandHandler<RegisterNewClientCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ClientAggregate(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(RegisterNewClientCommand message)
        {
            if (message.OrganizationId == null)
            {
                throw new BusinessRuleException("You cannot register a client if an organization is not specified.");
            }
            var customerDomain = _mapper.Map<RegisterNewClientCommand, Client>(message);

            _dbContext.Clients.Add(customerDomain);

            _dbContext.SaveChanges();

            return customerDomain.Id;
        }
    }
}