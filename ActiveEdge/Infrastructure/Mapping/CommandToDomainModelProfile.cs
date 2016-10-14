using System;
using AutoMapper;
using Domain.Command;
using Domain.Command.Client;
using Domain.Command.Session;
using Domain.Model;

namespace ActiveEdge.Infrastructure.Mapping
{
    [Obsolete]
    public class CommandToDomainModelProfile : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<RegisterNewClient, ContraIndications>();
            CreateMap<RegisterNewClient, TermsAndConditions>();
            CreateMap<RegisterNewClient, Client>()
                .ForMember(dst => dst.ContraIndications, options => options.Unflatten());
            CreateMap<RegisterNewClient, Client>()
                .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());

            CreateMap<UpdateClient, ContraIndications>();
            CreateMap<UpdateClient, TermsAndConditions>();
            CreateMap<UpdateClient, Client>()
                .ForMember(dst => dst.ContraIndications, options => options.Unflatten());
            CreateMap<UpdateClient, Client>()
                .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());


            CreateMap<CreateNewOrganizationCommand.Clinic, Clinic>()
                .ForMember(dest => dest.Address, options => options.ResolveUsing(
                    model => new Address
                    {
                        Line1 = model.AddressLine1,
                        Line2 = model.AddressLine2,
                        Suburb = model.Suburb,
                        City = model.City,
                        PostCode = model.PostCode
                    }))
                .ForMember(dest => dest.OrganizationId, options => options.Ignore())
                .ForMember(dest => dest.Organization, options => options.Ignore());

            CreateMap<CreateNewOrganizationCommand, Organization>()
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.Clinics, options => options.MapFrom(model => model.Clinics));

            CreateMap<UpdateOrganizationCommand.Clinic, Clinic>()
                .ForMember(dest => dest.Address, options => options.ResolveUsing(
                    model => new Address
                    {
                        Line1 = model.AddressLine1,
                        Line2 = model.AddressLine2,
                        Suburb = model.Suburb,
                        City = model.City,
                        PostCode = model.PostCode
                    }))
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.OrganizationId, options => options.Ignore())
                .ForMember(dest => dest.Organization, options => options.Ignore());

            CreateMap<UpdateOrganizationCommand, Organization>()
                .ForMember(dest => dest.Clinics, options => options.MapFrom(model => model.Clinics));



            CreateMap<CreateNewSession, Session>();

            CreateMap<UpdateSession, Session>();
        }
    }
}