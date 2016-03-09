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
        
        cfg.CreateMap<Domain.Customer, Models.Customer>();

        cfg.CreateMap<Models.Customer, Domain.Customer>();
      });

      return configuration;
    }
  }
}