using System.Linq;
using Domain.Context;
using Domain.Model;
using MediatR;

namespace Domain.Query.User
{
    public class UserQueryRepository : IRequestHandler<FindAllUsersForOrganization, IQueryable<ApplicationUser>>
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
        public IQueryable<ApplicationUser> Handle(FindAllUsersForOrganization message)
        {
            return _dbContext.Users.Where(user => user.OrganizationId == message.OrganizationId);
        }
    }
}
