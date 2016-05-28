using System;
using ActiveEdge.Models;
using ActiveEdge.Models.Organization;
using ActiveEdge.Models.WebApi.Search;
using AutoMapper;
using Domain.Model;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class ViewModelToDomainModel : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<SessionModel, Session>();

            CreateMap<ClientModel, ContraIndications>();
            CreateMap<ClientModel, TermsAndConditions>();

            CreateMap<ClientModel, Client>()
                .ForMember(dst => dst.ContraIndications, options => options.Unflatten());

            CreateMap<ClientModel, Client>()
                .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());


            CreateMap<ClinicModel, Clinic>()
                .ForMember(dest => dest.Address, options => options.ResolveUsing(
                    model => new Address
                    {
                        Address1 = model.AddressLine1,
                        Address2 = model.AddressLine2,
                        Suburb = model.Suburb,
                        City = model.City,
                        PostCode = model.PostCode
                    }))
                .ForMember(dest => dest.OrganizationId, options => options.Ignore())
                .ForMember(dest => dest.Organization, options => options.Ignore())
                ;

            CreateMap<OrganizationModel, Organization>()
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.Clinics, options => options.MapFrom(model => model.Clinics))
                ;

        }

        
    }

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

    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Create()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ViewModelToDomainModel>();
                cfg.AddProfile<DomainModelToViewModel>();


            });

            return configuration;
        }
    }
}