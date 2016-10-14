using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ActiveEdge.Infrastructure.MVC;
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
        private readonly IUrlHelper _urlHelper;

        public OrganizationApiController(IBus bus, IMapper mapper, IUrlHelper urlHelper)
        {
            _bus = bus;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        [Route("{organizationId}", Name = "getOrganizationApi")]
        public OrganizationModel GetOrganization(Guid organizationId)
        {
            return _bus.ExecuteQuery(new GetOrganization(organizationId));
        }

        [HttpPost]
        [Route("", Name = "createOrganizationApi")]
        public HttpResponseMessage Create(OrganizationModel model)
        {
            var command = _mapper.Map<CreateNewOrganizationCommand>(model);

            var organizationId = _bus.ExecuteCommand(command);

            var response = Request.CreateResponse(HttpStatusCode.Created, model);

            var uri = _urlHelper.Action("Details", new {controller = "Organization", id = organizationId});
            
            response.Headers.Location = new Uri(Request.RequestUri, uri);

            return response;
        }

        [HttpPut]
        [Route("{organizationId}", Name = "updateOrganizationApi")]
        public HttpResponseMessage Update(int organizationId, OrganizationModel model)
        {
            var command = _mapper.Map<UpdateOrganizationCommand>(model);
            command.Id = organizationId;
            _bus.ExecuteCommand(command);

            return new HttpResponseMessage(HttpStatusCode.NoContent);

        }
    }
}