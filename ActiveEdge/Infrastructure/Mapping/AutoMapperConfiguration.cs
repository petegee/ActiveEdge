using ActiveEdge.Models;
using ActiveEdge.Models.Clients.Command;
using ActiveEdge.Models.WebApi.Search;
using AutoMapper;
using Domain;
using Domain.Model;
using Client = Domain.Model.Client;

namespace ActiveEdge.Infrastructure.Mapping
{
  public static class AutoMapperConfiguration
  {
    public static MapperConfiguration Create()
    {
      var configuration = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<SessionModel, Session>();
        cfg.CreateMap<Session, SessionModel>();

        cfg.CreateMap<Client, Models.ClientModel>();

        cfg.CreateMap<RegisterNewClient, ContraIndications>();
        cfg.CreateMap<RegisterNewClient, TermsAndConditions>();

        cfg.CreateMap<RegisterNewClient, Client>()
          .ForMember(dst => dst.ContraIndications, options => options.Unflatten());

        cfg.CreateMap<RegisterNewClient, Client>()
          .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());

        cfg.CreateMap<Client, SearchResult>()
          .ForMember(result => result.DisplayValue, options => options.MapFrom(client => client.FullName));
      });

      return configuration;
    }
  }
}