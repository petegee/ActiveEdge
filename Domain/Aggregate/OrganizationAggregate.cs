using System.Linq;
using AutoMapper;
using Domain.Command;
using Domain.Context;
using Domain.Event;
using Domain.Model;

namespace Domain.Aggregate
{
    // ReSharper disable once UnusedMember.Global
    public class OrganizationAggregate : ICommandHandler<CreateNewOrganizationCommand>, ICommandHandler<DeleteOrganizationCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public OrganizationAggregate(IApplicationDbContext dbContext, IMapper mapper, IBus bus)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _bus = bus;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(CreateNewOrganizationCommand message)
        {
            var organization = _mapper.Map<Organization>(message);

            _dbContext.Organizations.Add(organization);

            _dbContext.SaveChanges();

            var domainEvent = _mapper.Map<NewOrganizationCreated>(organization);

            _bus.PublishDomainEvent(domainEvent);

            return organization.Id;
        }

        /// <summary>Handles a request</summary>
        /// <param name="message">The request message</param>
        /// <returns>Response from the request</returns>
        public int Handle(DeleteOrganizationCommand message)
        {
            var organization = _dbContext.Organizations.SingleOrDefault(org => org.Id == message.OrganizationId);

            if (organization == null)
            {
                throw new BusinessRuleException($"Unable to delete Organization id:'{message.OrganizationId}' could not be found.");
            }

            _dbContext.Organizations.Remove(organization);

            _dbContext.SaveChanges();

            return organization.Id;
        }
    }
}