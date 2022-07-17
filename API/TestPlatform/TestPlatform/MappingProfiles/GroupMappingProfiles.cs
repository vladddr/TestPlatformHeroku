using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.MappingProfiles
{
    public class GroupMappingProfiles : Profile
    {
        public GroupMappingProfiles()
        {
            CreateMap<Group, GroupBaseDto>()
            .ReverseMap();

            CreateMap<Group, GroupReadDto>()
            .ReverseMap();
        }
    }
}
