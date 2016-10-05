using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Marten;
using Shared;

namespace ActiveEdge.Read.Query.User
{
    public class UserQueryRepository : IQueryHandler<FindAllUsersForOrganization, ApplicationUser>
    {
        private readonly IDocumentSession _session;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public UserQueryRepository(IDocumentSession session)
        {
            _session = session;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public IList<ApplicationUser> Handle(FindAllUsersForOrganization message)
        {
            return _session.Query<ApplicationUser>().Where(user => user.OrganizationId == message.OrganizationId).ToList();
        }
    }
}
