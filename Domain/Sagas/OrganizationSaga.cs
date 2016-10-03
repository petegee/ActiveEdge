using AutoMapper;
using Domain.Command;
using Domain.Event;
using Domain.Model;
using Marten;
using Shared;

namespace Domain.Sagas
{
    // ReSharper disable once UnusedMember.Global
    public class OrganizationSaga : ICommandHandler<CreateNewOrganizationCommand>,
        ICommandHandler<UpdateOrganizationCommand>,
        ICommandHandler<DeleteOrganizationCommand>
    {
        private readonly IBus _bus;
        private readonly IDocumentSession _session;
        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public OrganizationSaga(IDocumentSession session, IMapper mapper, IBus bus)
        {
            _session = session;
            _mapper = mapper;
            _bus = bus;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(CreateNewOrganizationCommand message)
        {
            var organization = _mapper.Map<Organization>(message);

            _session.Store(organization);

            _session.SaveChanges();

            var domainEvent = _mapper.Map<NewOrganizationCreated>(organization);

            _bus.PublishDomainEvent(domainEvent);

            return organization.Id;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(DeleteOrganizationCommand message)
        {
            _session.Delete<Organization>(message.OrganizationId);

            _session.SaveChanges();

            return message.OrganizationId;
        }

        public int Handle(UpdateOrganizationCommand message)
        {
            var organization = _session.Load<Organization>(message.Id);

            if (organization == null)
            {
                throw new BusinessRuleException(
                    $"Unable to update Organization id:'{message.Id}' could not be found.");
            }

            _mapper.Map(message, organization);

            _session.Store(organization);

            _session.SaveChanges();

            var domainEvent = _mapper.Map<OrganizationUpdated>(organization);

            _bus.PublishDomainEvent(domainEvent);

            return organization.Id;
        }
    }
}