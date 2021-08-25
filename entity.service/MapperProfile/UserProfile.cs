using AutoMapper;
using entity.service.model;
using Entities = entity.data.Entity;

namespace entity.service.MapperProfile
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.User, User>().ReverseMap();
        }
    }
}
