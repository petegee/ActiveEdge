using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ActiveEdge.Infrastructure.MVC;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Organization;
using AutoMapper;
using Domain.Command.Organization;
using Domain.Context;
using Marten;
using Shared;

namespace ActiveEdge.WebApi
{
    [AuthorizeRoles(Roles.SystemAdministrator)]
    [RoutePrefix("api/organization")]
    public class OrganizationApiController : ApiController
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;
        private readonly IUrlHelper _urlHelper;

        public OrganizationApiController(IBus bus, IDocumentSession session, IMapper mapper, IUrlHelper urlHelper)
        {
            _bus = bus;
            _session = session;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }

        [HttpGet]
        [Route("{organizationId}", Name = "getOrganizationApi")]
        public async Task<OrganizationModel> GetOrganization(Guid organizationId)
        {
            var model = await _session.LoadAsync<OrganizationModel>(organizationId);

            return model;
        }

        [HttpPost]
        [Route("", Name = "createOrganizationApi")]
        public async Task<HttpResponseMessage> Create(OrganizationModel model)
        {
            var command = _mapper.Map<CreateNewOrganization>(model);

            var organizationId = await _bus.ExecuteAsyncCommand(command);

            var response = Request.CreateResponse(HttpStatusCode.Created, model);

            var uri = _urlHelper.Action("Details", new {controller = "Organization", id = organizationId});

            response.Headers.Location = new Uri(Request.RequestUri, uri);

            return response;
        }

        [HttpPut]
        [Route("{organizationId}", Name = "updateOrganizationApi")]
        public async Task<HttpResponseMessage> Update(Guid organizationId, OrganizationModel model)
        {
            var command = _mapper.Map<UpdateOrganization>(model);

            command.Id = organizationId;

            await _bus.ExecuteAsyncCommand(command);

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}