using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.MappingProfiles
{
    public class UserMappingProfiles : Profile
    {

        public UserMappingProfiles() { 
            CreateMap<User, UserReadDto>()
                .ReverseMap();

            CreateMap<User, UserUpdateDto>()
                .ReverseMap();

            CreateMap<User, UserCreateDto>()
                .ReverseMap();
        }
    }
}
