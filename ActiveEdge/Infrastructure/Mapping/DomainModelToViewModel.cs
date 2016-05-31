using ActiveEdge.Models;
using ActiveEdge.Models.Organization;
using ActiveEdge.Models.WebApi.Search;
using AutoMapper;
using Domain.Model;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class DomainModelToViewModel : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<Clinic, ClinicModel>()
                .ForMember(dest => dest.AddressLine1, options => options.MapFrom(src => src.Address.Address1))
                .ForMember(dest => dest.AddressLine2, options => options.MapFrom(src => src.Address.Address2))
                .ForMember(dest => dest.Suburb, options => options.MapFrom(src => src.Address.Suburb))
                .ForMember(dest => dest.City, options => options.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.PostCode, options => options.MapFrom(src => src.Address.PostCode))
                ;
            CreateMap<Organization, OrganizationModel>()
                .ForMember(dest => dest.Clinics, options => options.MapFrom(organization => organization.Clinics));

            CreateMap<Session, SessionModel>();


            CreateMap<Client, ClientModel>();


            CreateMap<Client, SearchResult>()
                .ForMember(result => result.DisplayValue, options => options.MapFrom(client => client.FullName));

        }
    }
}