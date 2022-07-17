using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;

namespace TestPlatform.API.Services
{
    public interface ITestService : IGenericService<Test, TestCreateDto, TestCreateDto, TestReadDto>
    {

    }
}
