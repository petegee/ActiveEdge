using System.Linq;
using Domain.Context;
using Domain.Model;
using MediatR;

namespace Domain.Query
{
    public class FindAllOrganizations : IRequest<IQueryable<Organization>>
    {
    }

    public class OrganizationQueryHandlers : IRequestHandler<FindAllOrganizations, IQueryable<Organization>>
    {
        private readonly IApplicationDbContext _dbContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public OrganizationQueryHandlers(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IQueryable<Organization> Handle(FindAllOrganizations message)
        {
            return _dbContext.Organizations;
        }
    }
}