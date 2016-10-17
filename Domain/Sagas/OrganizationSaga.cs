using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Command;
using Domain.Command.Organization;
using Domain.Event;
using Domain.Event.Organization;
using Domain.Model;
using Marten;
using Shared;

namespace Domain.Sagas
{
    // ReSharper disable once UnusedMember.Global
    public class OrganizationSaga : IAsyncCommandHandler<CreateNewOrganization>
        ,IAsyncCommandHandler<UpdateOrganization>
        //,ICommandHandler<DeleteOrganizationCommand>
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
        public async Task<Guid> Handle(CreateNewOrganization message)
        {
            var domainEvent = _mapper.Map<OrganizationCreated>(message);

            var organizationId = _session.Events.StartStream<Organization>(domainEvent);

            await _session.SaveChangesAsync();
            
            return organizationId;
        }

        ///// <summary>Handles a request</summary>
        ///// <param name="message">The request message</param>
        ///// <returns>Response from the request</returns>
        //public int Handle(DeleteOrganizationCommand message)
        //{
        //    _session.Delete<Organization>(message.OrganizationId);

        //    _session.SaveChanges();

        //    return message.OrganizationId;
        //}

        public async Task<Guid> Handle(UpdateOrganization message)
        {
            var domainEvent = _mapper.Map<OrganizationUpdated>(message);
            
            _session.Events.Append(message.Id, domainEvent);

            await _session.SaveChangesAsync();
            
            return message.Id;
        }
    }
}