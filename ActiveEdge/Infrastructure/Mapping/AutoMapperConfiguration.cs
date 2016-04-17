using ActiveEdge.Models;
using ActiveEdge.Models.Clients.Command;
using AutoMapper;
using Domain;

namespace ActiveEdge.Infrastructure.Mapping
{
  public static class AutoMapperConfiguration
  {
    public static MapperConfiguration Create()
    {
      var configuration =  new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<SoapNoteModel, SoapNote>();
        cfg.CreateMap<SoapNote, SoapNoteModel>();

        cfg.CreateMap<Domain.Client, Models.Client>();

        cfg.CreateMap<RegisterNewClient, Domain.ContraIndications>();
        cfg.CreateMap<RegisterNewClient, Domain.TermsAndConditions>();

        cfg.CreateMap<RegisterNewClient, Domain.Client>()
          .ForMember(dst => dst.ContraIndications, options => options.Unflatten());

        cfg.CreateMap<RegisterNewClient, Domain.Client>()
          .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());

        cfg.CreateMap<Domain.Client, Models.WebApi.Search.Client>();

      });

      return configuration;
    }
  }
}