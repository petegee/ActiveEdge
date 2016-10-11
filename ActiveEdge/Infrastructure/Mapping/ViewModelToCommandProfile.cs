using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Organization;
using ActiveEdge.Read.Model.Session;
using AutoMapper;
using Domain.Command;
using Domain.Command.Client;
using Domain.Command.Session;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class ViewModelToCommandProfile : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<ClinicModel, CreateNewOrganizationCommand.Clinic>();
            CreateMap<OrganizationModel, CreateNewOrganizationCommand>();

            CreateMap<ClinicModel, UpdateOrganizationCommand.Clinic>();
            CreateMap<OrganizationModel, UpdateOrganizationCommand>();

            // Clients
            CreateMap<ClientModel, RegisterNewClient>();
            CreateMap<ClientModel, UpdateClient>();

            // Sessions
            CreateMap<SessionModel, CreateNewSessionCommand>();
            CreateMap<SessionModel, UpdateSessionCommand>();
        }
    }
}