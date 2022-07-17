using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Specifications;

namespace TestPlatform.API.Services
{
    public interface IStudentService
    {
        Task<StudentUserReadDto> RegisterStudentAsync(StudentCreateDto studentDto);

        Task<StudentUserReadDto> UpdateGroupAsync(int groupId, int StudentId);

        Task<IEnumerable<StudentUserReadDto>> SearchAsync(
            ISpecification<Student> specification);
    }
}
