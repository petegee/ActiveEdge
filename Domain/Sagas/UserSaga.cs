using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Command.User;
using Domain.Context;
using Domain.Event.User;
using Domain.Model;
using Marten;
using Shared;

namespace Domain.Sagas
{
    public class UserSaga : IAsyncCommandHandler<CreateNewUser>, IAsyncCommandHandler<UpdateUser>
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;
        private readonly IApplicationUserManager _userManager;

        public UserSaga(IApplicationUserManager userManager, IDocumentSession session, IBus bus, IMapper mapper)
        {
            _userManager = userManager;
            _session = session;
            _bus = bus;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateNewUser message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var user = new ApplicationUser
            {
                UserName = message.Email,
                Email = message.Email,
                OrganizationId = message.OrganizationId
            };

            var userId = Guid.NewGuid();
            var result = await _userManager.CreateAsync(user, userId.ToString());

            if (!result.Succeeded)
                throw new BusinessRuleException(result.Errors);

            var roles = new List<string> {Roles.Therapist};

            if (message.IsAdministrator)
                roles.Add(Roles.OrganizationAdministrator);

            await _userManager.AddToRolesAsync(user.Id, roles.ToArray());

            await _session.SaveChangesAsync();

            var domainEvent = _mapper.Map<UserCreated>(message);

            _bus.PublishDomainEvent(domainEvent);

            return userId;
        }

        public async Task<Guid> Handle(UpdateUser message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var user = await _userManager.FindByIdAsync(message.Id);

            user.FirstName = message.FirstName;
            user.LastName = message.LastName;
            user.Email = message.Email;
            user.PhoneNumber = message.PhoneNumber;
            
            if (message.IsAdministrator)
            {
                if (user.Roles.Contains(Roles.OrganizationAdministrator) == false)
                {
                    user.Roles.Add(Roles.OrganizationAdministrator);
                }
            }
            else
            {
                if (user.Roles.Contains(Roles.OrganizationAdministrator))
                {
                    user.Roles.Remove(Roles.OrganizationAdministrator);
                }
            }
            
            await _userManager.UpdateAsync(user);

            //await _session.SaveChangesAsync();

            return Guid.Parse(user.Id);
        }
    }
}