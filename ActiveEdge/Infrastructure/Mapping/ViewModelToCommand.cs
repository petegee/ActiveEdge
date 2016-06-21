using ActiveEdge.Read.Model;
using ActiveEdge.Read.Model.Organization;
using AutoMapper;
using Domain.Command;
using Domain.Command.Client;
using Domain.Command.Session;

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

            // Clients
            CreateMap<ClientModel, RegisterNewClientCommand>();
            CreateMap<ClientModel, UpdateClientCommand>();

            // Sessions
            CreateMap<SessionModel, CreateNewSessionCommand>();

            CreateMap<SessionModel, UpdateSessionCommand>();
        }
    }
}