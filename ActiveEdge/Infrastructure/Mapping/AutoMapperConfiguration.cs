using System;
using AutoMapper;

namespace ActiveEdge.Infrastructure.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Create()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToCommandProfile>();
                cfg.AddProfile<CommandToDomainModelProfile>();
                cfg.AddProfile<DomainModelToDomainEventProfile>();
                cfg.AddProfile<DomainModelToViewModel>();
            });

            return configuration;
        }
    }
}