using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.MappingProfiles
{
    public class TeacherMappingProfile : Profile
    {
        public TeacherMappingProfile()
        {
            CreateMap<Teacher, TeacherBaseDto>()
                .ForMember(to => to.FirstName, from => from.MapFrom(s => s.User.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(s => s.User.LastName))
                .ForMember(to => to.Login, from => from.MapFrom(s => s.User.Login))
                .ForMember(to => to.Password, from => from.MapFrom(s => s.User.Password))
                .ReverseMap();

            CreateMap<Teacher, TeacherReadDto>()
                .ForMember(to => to.FirstName, from => from.MapFrom(s => s.User.FirstName))
                .ForMember(to => to.LastName, from => from.MapFrom(s => s.User.LastName))
                .ForMember(to => to.Login, from => from.MapFrom(s => s.User.Login))
                .ForMember(to => to.Password, from => from.MapFrom(s => s.User.Password))
                .ReverseMap();

            CreateMap<User, TeacherUserReadDto>()
                .ReverseMap();
        }
    }
}
