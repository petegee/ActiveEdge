using System.Collections.Generic;
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

    [Route("clients/{fullname}")]
    [HttpGet]
    public IEnumerable<Client> Clients(string fullName)
    {
      return _dbContext.Clients.Where(client => client.FullName.ToLower().StartsWith(fullName.ToLower()))
        .Decompile()
        .ProjectToList<Client>(_mapperConfiguration);
    }
  }
}