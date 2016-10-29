using AutoMapper;
using Domain.Command.Client;
using Domain.Command.Organization;
using Domain.Command.Session;
using Domain.Command.User;
using Domain.Event;
using Domain.Event.Organization;
using Domain.Event.Session;
using Domain.Event.User;
using Clinic = Domain.Command.Organization.Clinic;

namespace Domain.Mapping
{
    public class CommandToEventProfile : Profile
    {
        /// <summary>
        ///     Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        ///     Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            // Clients
            CreateMap<RegisterNewClient, ClientRegistered>();
            CreateMap<UpdateClient, ClientUpdated>();

            // Sessions
            CreateMap<CreateNewSession, SessionCreated>();
            CreateMap<AddPlanToSession, PlanAddedToSession>();
            CreateMap<UpdateSession, SessionUpdated>();

            // Organization
            CreateMap<CreateNewOrganization, OrganizationCreated>();
            CreateMap<Clinic, Event.Organization.Clinic>();
            CreateMap<UpdateOrganization, OrganizationUpdated>();

            // Users
            CreateMap<CreateNewUser, UserCreated>();
        }
    }
}