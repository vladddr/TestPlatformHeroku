using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.Services
{
    public interface ITeacherService : IGenericService<Teacher, TeacherBaseDto, TeacherBaseDto, TeacherReadDto>
    {
        Task<UserReadDto> RegisterTeacherAsync(TeacherBaseDto teacherDto);
    }
}
