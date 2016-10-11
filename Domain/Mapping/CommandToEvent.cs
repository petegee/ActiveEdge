using AutoMapper;
using Domain.Command.Client;
using Domain.Command.Session;
using Domain.Event;

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
        }
    }
}