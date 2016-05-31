using ActiveEdge.Models;
using AutoMapper;
using Domain.Model;

namespace ActiveEdge.Infrastructure.Mapping
{
    public class ViewModelToDomainModel : Profile
    {
        /// <summary>
        /// Override this method in a derived class and call the CreateMap method to associate that map with this profile.
        /// Avoid calling the <see cref="T:AutoMapper.Mapper" /> class from this method.
        /// </summary>
        protected override void Configure()
        {
            CreateMap<SessionModel, Session>();

            CreateMap<ClientModel, ContraIndications>();
            CreateMap<ClientModel, TermsAndConditions>();

            CreateMap<ClientModel, Client>()
                .ForMember(dst => dst.ContraIndications, options => options.Unflatten());

            CreateMap<ClientModel, Client>()
                .ForMember(dst => dst.TermsAndConditions, options => options.Unflatten());


        }

        
    }
}