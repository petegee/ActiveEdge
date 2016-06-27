using AutoMapper;
using Domain.Command.Session;
using Domain.Event;
using Domain.Model;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class DomainModelToDomainEvent : Profile
    {
        /// <summary>
        ///     Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        ///     Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<Clinic, NewOrganizationCreated.Clinic>();
            CreateMap<Organization, NewOrganizationCreated>();
           
        }
    }
}