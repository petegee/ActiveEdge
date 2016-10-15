using AutoMapper;
using Domain.Event.Organization;
using Domain.Model;
using Clinic = Domain.Model.Clinic;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class DomainModelToDomainEventProfile : Profile
    {
        /// <summary>
        ///     Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        ///     Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<Clinic, Domain.Event.Organization.Clinic>();
            CreateMap<Organization, OrganizationCreated>();

            CreateMap<Organization, OrganizationUpdated>();
        }
    }
}