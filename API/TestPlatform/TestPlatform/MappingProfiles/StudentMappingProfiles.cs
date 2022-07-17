using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.MappingProfiles
{
    public class StudentMappingProfiles : Profile
    {
        public StudentMappingProfiles()
        {
            CreateMap<Student, StudentCreateDto>()
                .ForMember(to => to.FirstName, from => from.MapFrom(s => s.User.FirstName))
                .ForMember(to => to.LastName,  from => from.MapFrom(s => s.User.LastName))
                .ForMember(to => to.Login,     from => from.MapFrom(s => s.User.Login))
                .ForMember(to => to.Password,  from => from.MapFrom(s => s.User.Password))
                .ReverseMap();

            CreateMap<Student, StudentUserReadDto>()
                .ForMember(to => to.FirstName, from => from.MapFrom(s => s.User.FirstName))
                .ForMember(to => to.LastName,  from => from.MapFrom(s => s.User.LastName))
                .ForMember(to => to.Login,     from => from.MapFrom(s => s.User.Login))
                .ForMember(to => to.Password,  from => from.MapFrom(s => s.User.Password))
                .ReverseMap();

            CreateMap<User, StudentUserReadDto>()
                .ForMember(to => to.GroupId, from => from.MapFrom(s => s.Student!.GroupId))
                .ReverseMap();

            CreateMap<User, StudentReadDto>()
                .ForMember(to => to.Group, from => from.MapFrom(s => s.Student!.Group))
                .ReverseMap();
        }
    }
}
