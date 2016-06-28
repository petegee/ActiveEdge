using System.Web.Http;
using ActiveEdge.Infrastructure.MVC.Attributes;
using ActiveEdge.Read.Model.Organization;
using ActiveEdge.Read.Query.Organization;
using Domain.Context;
using Shared;

namespace ActiveEdge.WebApi
{
    [AuthorizeRoles(Roles.SystemAdministrator)]
    [RoutePrefix("api/organization")]
    public class OrganizationApiController : ApiController
    {
        private readonly IBus _bus;

        public OrganizationApiController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("{organizationId}")]
        public OrganizationModel GetOrganization(int organizationId)
        {
            return _bus.ExecuteQuery(new GetOrganization(organizationId));
        }
    }
}