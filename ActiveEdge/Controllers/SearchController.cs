using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ActiveEdge.Database;
using ActiveEdge.Models;
using AutoMapper;
using DelegateDecompiler;

namespace ActiveEdge.Controllers
{
    public class SearchController : ApiController
    {
      private readonly IApplicationDbContext _dbContext;
      private readonly MapperConfiguration _mapperConfiguration;

      public SearchController(IApplicationDbContext dbContext, MapperConfiguration mapperConfiguration)
      {
        _dbContext = dbContext;
        _mapperConfiguration = mapperConfiguration;
      }

      //public IEnumerable<Models.WebApi.Search.Client> Clients(string clientName)
      //{
      //  return _dbContext.Clients.Where(client => client.FullName.ToLower().StartsWith(clientName.ToLower()))
      //  .Decompile()
      //  .ProjectToList<Models.WebApi.Search.Client>(_mapperConfiguration);


      //}
    }
}
