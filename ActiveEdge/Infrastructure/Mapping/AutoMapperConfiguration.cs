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
                cfg.AddProfile<CommandToDomainModel>();
                cfg.AddProfile<DomainModelToDomainEvent>();
                cfg.AddProfile<ViewModelToDomainModel>();
                cfg.AddProfile<DomainModelToViewModel>();
                cfg.AddProfile<ViewModelToCommand>();

            });

            return configuration;
        }
    }
}