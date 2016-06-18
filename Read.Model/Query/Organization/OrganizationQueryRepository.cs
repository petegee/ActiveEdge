using System.Collections.Generic;
using System.Linq;
using ActiveEdge.Read.Model.Organization;
using AutoMapper;
using Domain.Context;
using Shared;

namespace ActiveEdge.Read.Query.Organization
{
    public class OrganizationQueryRepository : IQueryHandler<FindAllOrganizations, OrganizationModel>,
        IQueryForSingleHandler<GetOrganization, OrganizationModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly MapperConfiguration _mapperConfiguration;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public OrganizationQueryRepository(IApplicationDbContext dbContext, MapperConfiguration mapperConfiguration)
        {
            _dbContext = dbContext;
            _mapperConfiguration = mapperConfiguration;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<OrganizationModel> Handle(FindAllOrganizations message)
        {
            return _dbContext.Organizations.ProjectToList<OrganizationModel>(_mapperConfiguration);
        }

        public OrganizationModel Handle(GetOrganization message)
        {
            return _dbContext.Organizations.Where(organization => organization.Id == message.Id).ProjectToSingleOrDefault<OrganizationModel>(_mapperConfiguration);
        }
    }
}