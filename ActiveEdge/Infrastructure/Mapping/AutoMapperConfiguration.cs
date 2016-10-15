using System;
using AutoMapper;
using Domain.Mapping;

namespace ActiveEdge.Infrastructure.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Create()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToCommandProfile>();
                cfg.AddProfile<DomainModelToDomainEventProfile>();
                //cfg.AddProfile<DomainModelToViewModel>();
                cfg.AddProfile<CommandToEventProfile>();
            });

            return configuration;
        }
    }
}