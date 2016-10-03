using System.Collections.Generic;
using System.Linq;
using ActiveEdge.Read.Model.Organization;
using AutoMapper;
using Marten;
using Shared;

namespace ActiveEdge.Read.Query.Organization
{
    public class OrganizationQueryRepository : IQueryHandler<FindAllOrganizations, OrganizationModel>,
        IQueryForSingleHandler<GetOrganization, OrganizationModel>
    {
        private readonly IDocumentSession _session;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public OrganizationQueryRepository(IDocumentSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<OrganizationModel> Handle(FindAllOrganizations message)
        {
            var organisations = _session.Query<Domain.Model.Organization>().ToList();

            var models = _mapper.Map<List<Domain.Model.Organization>, List<OrganizationModel>>(organisations);

            return models;
        }

        public OrganizationModel Handle(GetOrganization message)
        {
            var organisation = _session.Load<Domain.Model.Organization>(message.Id);

            var model = _mapper.Map<Domain.Model.Organization, OrganizationModel>(organisation);

            return model;
        }
    }
}