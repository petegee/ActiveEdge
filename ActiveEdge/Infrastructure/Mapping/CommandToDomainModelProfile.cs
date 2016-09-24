using AutoMapper;
using Domain.Command;
using Domain.Command.Client;
using Domain.Command.Session;
using Domain.Model;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class CommandToDomainModelProfile : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<RegisterNewClientCommand, ContraIndications>();
            CreateMap<RegisterNewClientCommand, TermsAndConditions>();
            CreateMap<RegisterNewClientCommand, Client>()
                .ForMember(dst => dst.ContraIndications, options => options.Unflatten());
            CreateMap<RegisterNewClientCommand, Client>()
                .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());

            CreateMap<UpdateClientCommand, ContraIndications>();
            CreateMap<UpdateClientCommand, TermsAndConditions>();
            CreateMap<UpdateClientCommand, Client>()
                .ForMember(dst => dst.ContraIndications, options => options.Unflatten());
            CreateMap<UpdateClientCommand, Client>()
                .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());


            CreateMap<CreateNewOrganizationCommand.Clinic, Clinic>()
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
                .ForMember(dest => dest.Organization, options => options.Ignore());

            CreateMap<CreateNewOrganizationCommand, Organization>()
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.Clinics, options => options.MapFrom(model => model.Clinics));

            CreateMap<UpdateOrganizationCommand.Clinic, Clinic>()
                .ForMember(dest => dest.Address, options => options.ResolveUsing(
                    model => new Address
                    {
                        Address1 = model.AddressLine1,
                        Address2 = model.AddressLine2,
                        Suburb = model.Suburb,
                        City = model.City,
                        PostCode = model.PostCode
                    }))
                .ForMember(dest => dest.Id, options => options.Ignore())
                .ForMember(dest => dest.OrganizationId, options => options.Ignore())
                .ForMember(dest => dest.Organization, options => options.Ignore());

            CreateMap<UpdateOrganizationCommand, Organization>()
                .ForMember(dest => dest.Clinics, options => options.MapFrom(model => model.Clinics));



            CreateMap<CreateNewSessionCommand, Session>();

            CreateMap<UpdateSessionCommand, Session>();
        }
    }
}