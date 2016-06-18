using System.Collections.Generic;
using System.Linq;
using ActiveEdge.Read.Model;
using AutoMapper;
using Domain.Context;
using Shared;

namespace ActiveEdge.Read.Query.Clients
{
    public class ClientQueryRepository : IQueryHandler<GetAllClientsForOrganization, ClientModel>,
        IQueryForSingleHandler<GetClientForOrganization, ClientModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly MapperConfiguration _mapperConfiguration;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ClientQueryRepository(IApplicationDbContext dbContext,
            MapperConfiguration mapperConfiguration)
        {
            _dbContext = dbContext;
            _mapperConfiguration = mapperConfiguration;
            _dbContext.EnableOrganizationTenant();
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public ClientModel Handle(GetClientForOrganization message)
        {
            return
                _dbContext.Clients.Where(client => client.Id == message.ClientId)
                    .ProjectToSingleOrDefault<ClientModel>(_mapperConfiguration);
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<ClientModel> Handle(GetAllClientsForOrganization message)
        {
            return _dbContext.Clients.ProjectToList<ClientModel>(_mapperConfiguration);
        }
    }
}