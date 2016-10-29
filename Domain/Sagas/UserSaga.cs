using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Command.User;
using Domain.Context;
using Domain.Event.User;
using Domain.Model;
using Marten;
using Microsoft.AspNet.Identity;
using Shared;

namespace Domain.Sagas
{
    public class UserSaga : IAsyncCommandHandler<CreateNewUser>
    {
        private readonly IApplicationUserManager _userManager;
        private readonly UserManager<ApplicationUser> _userManager2;
        private readonly IDocumentSession _session;
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public UserSaga(IApplicationUserManager userManager, UserManager<ApplicationUser> userManager2, IDocumentSession session, IBus bus, IMapper mapper)
        {
            _userManager = userManager;
            _userManager2 = userManager2;
            _session = session;
            _bus = bus;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateNewUser message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var user = new ApplicationUser
            {
                UserName = message.UserName,
                Email = message.Email,
                OrganizationId = message.OrganizationId
            };

            var userId = Guid.NewGuid();
            var result = _userManager2.Create(user, userId.ToString());

            if (!result.Succeeded) throw new BusinessRuleException("There was a problem creating the user");

            var roles = new List<string> {Roles.Therapist};

            if(message.IsAdministrator)
                roles.Add(Roles.OrganizationAdministrator);

            _userManager2.AddToRoles(user.Id, roles.ToArray());

            _session.SaveChanges();

            var domainEvent = _mapper.Map<UserCreated>(message);
                
            _bus.PublishDomainEvent(domainEvent);

            return userId;
        }
    }
}