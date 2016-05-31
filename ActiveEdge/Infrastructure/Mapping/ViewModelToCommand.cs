using ActiveEdge.Models.Organization;
using AutoMapper;
using Domain.Command;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class ViewModelToCommand : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<ClinicModel, CreateNewOrganizationCommand.Clinic>();
            CreateMap<OrganizationModel, CreateNewOrganizationCommand>();
        }
    }
}