//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ActiveEdge.Read.Model.Users;
//using Domain.Context;
//using Domain.Model;
//using Marten;
//using Shared;

//namespace ActiveEdge.Read.Query.User
//{
//    public class UserQueryRepository : IAsyncQueryHandler<GetAllUsers, AllUsers>

//        //: IQueryHandler<FindAllUsersForOrganization, ApplicationUser>
//    {
//        private readonly IDocumentSession _session;

//        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
//        public UserQueryRepository(IDocumentSession session)
//        {
//            _session = session;
//        }

//        ///// <summary>Handles a request</summary>
//        ///// <param name="message">The request message</param>
//        ///// <returns>Response from the request</returns>
//        //public TasKIList<ApplicationUser> Handle(FindAllUsersForOrganization message)
//        //{
//        //    return _session.Query<ApplicationUser>().Where(user => user.OrganizationId == message.OrganizationId).ToList();
//        //}
//        public async Task<IList<AllUsers>> Handle(GetAllUsers message)
//        {
//            var users = await  _session.Query<ApplicationUser>().Select(user => new UserModel
//            {
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                PhoneNumber = user.PhoneNumber,
//                IsAdministrator = user.Roles.Contains(Roles.OrganizationAdministrator)
//            })
//            .ToListAsync();

//            AllUsers model = new AllUsers();

//            model.User = users;
//            return users;
//        }
//    }
//}
