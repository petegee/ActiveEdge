using System.Linq;
using Domain.Context;

namespace Domain.Query.Organization
{
    public class OrganizationQueryRepository : IQueryHandler<FindAllOrganizations, Model.Organization>,
        IQueryHandler<GetOrganization, Model.Organization>
    {
        private readonly IApplicationDbContext _dbContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public OrganizationQueryRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IQueryable<Model.Organization> Handle(FindAllOrganizations message)
        {
            return _dbContext.Organizations;
        }

        public IQueryable<Model.Organization> Handle(GetOrganization message)
        {
            return _dbContext.Organizations.Where(organization => organization.Id == message.Id);
        }
    }
}