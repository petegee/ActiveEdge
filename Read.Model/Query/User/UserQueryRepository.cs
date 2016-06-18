using System.Collections.Generic;
using System.Linq;
using Domain.Context;
using Domain.Model;
using Shared;

namespace ActiveEdge.Read.Query.User
{
    public class UserQueryRepository : IQueryHandler<FindAllUsersForOrganization, ApplicationUser>
    {
        private readonly IApplicationDbContext _dbContext;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public UserQueryRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<ApplicationUser> Handle(FindAllUsersForOrganization message)
        {
            return _dbContext.Users.Where(user => user.OrganizationId == message.OrganizationId).ToList();
        }
    }
}
