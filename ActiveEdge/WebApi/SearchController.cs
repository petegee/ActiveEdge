﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ActiveEdge.Database;
using ActiveEdge.Models.WebApi.Search;
using AutoMapper;
using DelegateDecompiler;

namespace ActiveEdge.WebApi
{
  [RoutePrefix("api/search")]
  public class SearchController : ApiController
  {
    private readonly IApplicationDbContext _dbContext;
    private readonly MapperConfiguration _mapperConfiguration;

    public SearchController(IApplicationDbContext dbContext, MapperConfiguration mapperConfiguration)
    {
      _dbContext = dbContext;
      _mapperConfiguration = mapperConfiguration;
    }

    [HttpGet]
    [Route("clients/{fullname}")]
    public IEnumerable<SearchResult> Clients(string fullName)
    {
      return _dbContext.Clients.Where(client => client.FullName.ToLower().StartsWith(fullName.ToLower()))
        .Decompile()
        .ProjectToList<SearchResult>(_mapperConfiguration);
    }

    [HttpGet]
    [Route("suburbs/{name}")]
    public IEnumerable<SearchResult> Suburbs(string name)
    {
      return _dbContext.Clients.Where(client => client.Suburb.ToLower().StartsWith(name.ToLower()))
        .Select(client => new SearchResult {DisplayValue = client.Suburb})
        .Distinct();
    }

    [HttpGet]
    [Route("cities/{name}")]
    public IEnumerable<SearchResult> Cities(string name)
    {
      return _dbContext.Clients.Where(client => client.City.ToLower().StartsWith(name.ToLower()))
        .Select(client => new SearchResult { DisplayValue = client.City })
        .Distinct();
    }
  }
}