using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.MappingProfiles
{
    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            CreateMap<Test, TestReadDto>()
                .ReverseMap();

            CreateMap<Test, TestCreateDto>()
                .ReverseMap();

            CreateMap<TestQuestion, TestQuestionDto>()
                .ReverseMap();

            CreateMap<TestQuestion, TestQuestionReadDto>()
                .ReverseMap();

            CreateMap<QuestionOption, QuestionOptionReadDto>()
                .ReverseMap();

            CreateMap<QuestionOption, QuestionOptionCreateDto>()
                .ReverseMap();

            CreateMap<BaseEntityDto, Group>()
                .ReverseMap();
        }
    }
}
