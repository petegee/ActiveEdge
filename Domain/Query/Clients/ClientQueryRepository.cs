using System.Linq;
using Domain.Context;
using Domain.Model;

namespace Domain.Query.Clients
{
    public class ClientQueryRepository : IQueryHandler<GetAllClientsForOrganization, Client>, IQueryHandler<GetClientForOrganization, Client>
    {
        private readonly IApplicationDbContext _dbContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ClientQueryRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IQueryable<Client> Handle(GetAllClientsForOrganization message)
        {
            return message.OrganizationId == null
                ? _dbContext.Clients
                : _dbContext.Clients.Where(client => client.OrganizationId == message.OrganizationId.Value);
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IQueryable<Client> Handle(GetClientForOrganization message)
        {
            var clients = message.OrganizationId == null
                ? _dbContext.Clients
                : _dbContext.Clients.Where(client => client.OrganizationId == message.OrganizationId);

            return clients.Where(client => client.Id == message.ClientId);
        }
    }
}