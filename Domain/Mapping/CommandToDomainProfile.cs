using AutoMapper;
using Domain.Command.User;
using Domain.Model;

namespace Domain.Mapping
{
    public class CommandToDomainProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UpdateUser, ApplicationUser>()
                ;
        }
    }
}