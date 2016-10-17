using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ActiveEdge.Read.Model.Client;
using ActiveEdge.Read.Model.Search;
using ActiveEdge.Read.Model.WebApi.Search;
using Domain.Filters;
using Marten;
using Shared;

namespace ActiveEdge.WebApi
{
    [RoutePrefix("api/search")]
    public class SearchApiController : ApiController
    {
        private readonly ILoggedOnUser _loggedOnUser;
        private readonly IDocumentSession _session;

        public SearchApiController(IDocumentSession session, ILoggedOnUser loggedOnUser)
        {
            _session = session;
            _loggedOnUser = loggedOnUser;
        }

        [HttpGet]
        [Route("clients/{fullname}")]
        public async Task<IEnumerable<SearchResult>> Clients(string fullName)
        {
            fullName = fullName.ToLower();
            
            var searchResults = await _session.Query<ClientModel>()
                .FilterForOrganization(_loggedOnUser)
                .Select(client => new SearchResult { Id = client.Id.ToString(), DisplayValue = client.FullName })
                .Where(result => result.DisplayValue.StartsWith(fullName, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
            
            return searchResults;
        }

        [HttpGet]
        [Route("suburbs/{name}")]
        public async Task<IList<SearchResult>> Suburbs(string name)
        {
            var searchResults = await _session.Query<Suburb>()
                .Where(suburb => suburb.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                .Select(suburb => new SearchResult { DisplayValue = suburb.Name, Id = suburb.Id.ToString() })
                .ToListAsync();

            return searchResults;
        }

        [HttpGet]
        [Route("cities/{name}")]
        public async Task<IEnumerable<SearchResult>> Cities(string name)
        {
            var searchResults = await _session.Query<City>()
                .Where(city => city.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                .Select(city => new SearchResult { DisplayValue = city.Name, Id = city.Id.ToString() })
                .ToListAsync();

            return searchResults;
        }
    }
}