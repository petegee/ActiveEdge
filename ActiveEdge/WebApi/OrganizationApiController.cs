using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Organization;
using ActiveEdge.Read.Query.Organization;
using AutoMapper;
using Domain.Command;
using Domain.Context;
using Shared;

namespace ActiveEdge.WebApi
{
    [AuthorizeRoles(Roles.SystemAdministrator)]
    [RoutePrefix("api/organization")]
    public class OrganizationApiController : ApiController
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;

        public OrganizationApiController(IBus bus, IMapper mapper)
        {
            _bus = bus;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{organizationId}", Name = "GetOrganizationApi")]
        public OrganizationModel GetOrganization(int organizationId)
        {
            return _bus.ExecuteQuery(new GetOrganization(organizationId));
        }

        [HttpPost]
        [Route("", Name = "CreateOrganizationApi")]
        public HttpResponseMessage Create(OrganizationModel model)
        {
            var command = _mapper.Map<CreateNewOrganizationCommand>(model);

            _bus.ExecuteCommand(command);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("{organizationId}", Name = "UpdateOrganizationApi")]
        public HttpResponseMessage Update(int organizationId, OrganizationModel model)
        {
            var command = _mapper.Map<UpdateOrganizationCommand>(model);
            command.Id = organizationId;
            _bus.ExecuteCommand(command);

            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}