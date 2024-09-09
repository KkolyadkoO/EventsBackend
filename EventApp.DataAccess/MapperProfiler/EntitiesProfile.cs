using AutoMapper;
using EventApp.Core.Models;
using EventApp.DataAccess.Entities;

namespace EventApp.DataAccess.MapperProfiler;

public class EntitiesProfile : Profile
{
    public EntitiesProfile()
    {
        
        CreateMap<MemberOfEventEntity, MemberOfEvent>().ReverseMap();
        
        CreateMap<UserEntity, User>().ReverseMap();

        CreateMap<CategoryOfEventEntity, CategoryOfEvent>().ReverseMap();

        CreateMap<EventEntity, Event>().ReverseMap();
    }
}
