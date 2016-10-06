using System.Collections.Generic;
using System.Linq;
using ActiveEdge.Read.Model;
using AutoMapper;
using Domain.Model;
using Marten;
using Shared;

namespace ActiveEdge.Read.Query.Clients
{
    public class ClientQueryRepository : IQueryHandler<GetAllClientsForOrganization, ClientModel>,
        IQueryForSingleHandler<GetClientForOrganization, ClientModel>
    {
        private readonly IDocumentSession _session;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public ClientQueryRepository(IDocumentSession session,
            IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public ClientModel Handle(GetClientForOrganization message)
        {
            var client = _session.Query<Client>().SingleOrDefault(c => c.Id == message.ClientId);

            var model = _mapper.Map<Client, ClientModel>(client);

            return model;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<ClientModel> Handle(GetAllClientsForOrganization message)
        {
            var clientsForOrganization = message.OrganizationId.HasValue == false ?
                _session.Query<Client>().ToList() : 
                _session.Query<Client>().Where(client => client.OrganizationId == message.OrganizationId.Value).ToList();

            var clientModels = _mapper.Map<List<Client>, List<ClientModel>>(clientsForOrganization);

            return clientModels;
        }
    }
}