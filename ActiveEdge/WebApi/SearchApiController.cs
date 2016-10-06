using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ActiveEdge.Read.Model.WebApi.Search;
using AutoMapper;
using Domain.Model;
using Marten;

namespace ActiveEdge.WebApi
{
    [RoutePrefix("api/search")]
    public class SearchApiController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IDocumentSession _session;

        public SearchApiController(IDocumentSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("clients/{fullname}")]
        public IEnumerable<SearchResult> Clients(string fullName)
        {
            fullName = fullName.ToLower();

            var searchResults = _session.Query<Client>()
                .Select(
                    client => new SearchResult { Id = client.Id, DisplayValue = client.FullName })
                .Where(result => result.DisplayValue.StartsWith(fullName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            //var clients = _session.Query<Client>()
            //    .Where(client => client.FirstName.StartsWith(fullName, StringComparison.OrdinalIgnoreCase)).ToList();

            //var searchResults =  _mapper.Map<List<Client>, List<SearchResult>>(clients);

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