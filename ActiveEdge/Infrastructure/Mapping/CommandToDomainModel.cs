using AutoMapper;
using Domain.Command;
using Domain.Model;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class CommandToDomainModel : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
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


        }
    }
}