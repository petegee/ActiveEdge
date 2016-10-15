using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Client;
using ActiveEdge.Read.Model.WebApi.Search;
using AutoMapper;
using Domain.Filters;
using Domain.Model;
using Marten;
using Shared;

namespace ActiveEdge.WebApi
{
    [RoutePrefix("api/search")]
    public class SearchApiController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ILoggedOnUser _loggedOnUser;
        private readonly IDocumentSession _session;

        public SearchApiController(IDocumentSession session, IMapper mapper, ILoggedOnUser loggedOnUser)
        {
            _session = session;
            _mapper = mapper;
            _loggedOnUser = loggedOnUser;
        }

        [HttpGet]
        [Route("clients/{fullname}")]
        public IEnumerable<SearchResult> Clients(string fullName)
        {
            fullName = fullName.ToLower();
            
            var searchResults = _session.Query<ClientModel>()
                .FilterForOrganization(_loggedOnUser)
                .Select(client => new SearchResult { Id = client.Id.ToString(), DisplayValue = client.FullName })
                .Where(result => result.DisplayValue.StartsWith(fullName, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            return searchResults;
        }

        [HttpGet]
        [Route("suburbs/{name}")]
        public IEnumerable<SearchResult> Suburbs(string name)
        {
            name = name.ToLower();
            var addresses = _session.Query<Address>()
                .Where(address => address.Suburb.ToLower().StartsWith(name)).ToList();

            var searchResults = _mapper.Map<List<Address>, List<SearchResult>>(addresses);

            return searchResults;
        }

        [HttpGet]
        [Route("cities/{name}")]
        public IEnumerable<SearchResult> Cities(string name)
        {
            name = name.ToLower();
            var addresses = _session.Query<Address>()
                .Where(address => address.City.ToLower().StartsWith(name)).ToList();

            var searchResults = _mapper.Map<List<Address>, List<SearchResult>>(addresses);

            return searchResults;
        }
    }
}