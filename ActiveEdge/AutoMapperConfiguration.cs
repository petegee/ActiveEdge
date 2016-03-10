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

        cfg.CreateMap<Models.Client, Domain.Client>();
      });

      return configuration;
    }
  }
}