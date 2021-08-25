using AutoMapper;
using entity.service.model;
using Entities = entity.data.Entity;

namespace entity.service.MapperProfile
{
    internal class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Entities.Job, Job>().ReverseMap();
        }
    }
}
