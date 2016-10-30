using ActiveEdge.Read.Model.Client;
using ActiveEdge.Read.Model.Organization;
using ActiveEdge.Read.Model.Session;
using ActiveEdge.Read.Model.Users;
using AutoMapper;
using Domain.Command.Client;
using Domain.Command.Organization;
using Domain.Command.Session;
using Domain.Command.User;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class ViewModelToCommandProfile : Profile
    {
        /// <summary>
        ///     Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        ///     Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            // User
            CreateMap<UserModel, CreateNewUser>();
            CreateMap<UserModel, UpdateUser>();

            // Organizations
            CreateMap<ClinicModel, Clinic>();
            CreateMap<OrganizationModel, CreateNewOrganization>();
            CreateMap<OrganizationModel, UpdateOrganization>();

            // Clients
            CreateMap<ClientModel, RegisterNewClient>();
            CreateMap<ClientModel, UpdateClient>();

            // Sessions
            CreateMap<SessionModel, CreateNewSession>();
            CreateMap<SessionPlanModel, AddPlanToSession>();
            CreateMap<SessionModel, UpdateSession>();
        }
    }
}