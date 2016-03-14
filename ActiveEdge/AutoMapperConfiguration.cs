using AutoMapper;

namespace ActiveEdge
{
  public static class AutoMapperConfiguration
  {
    public static MapperConfiguration Create()
    {
      var configuration =  new MapperConfiguration(cfg =>
      {
        //cfg.ConstructServicesUsing(ObjectFactory.GetInstance);
        
        cfg.CreateMap<Domain.Client, Models.Client>();


        cfg.CreateMap<Models.Client, Domain.Client>()
          .ForMember(dst => dst.ContraIndications, options => options.MapFrom(src => src));
        cfg.CreateMap<Models.Client, Domain.ContraIndications>();
      });

      return configuration;
    }
  }
}