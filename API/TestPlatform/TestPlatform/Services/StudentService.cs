using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.DataTransfer.SearchParamethers;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Enums;
using TestPlatform.Core.Specifications;
using TestPlatform.DAL.Repositories;

namespace TestPlatform.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<User> _userRepository;

        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Student> studentRepository, IGenericRepository<User> userRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<StudentUserReadDto> RegisterStudentAsync(StudentCreateDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            // Create student based user
            var studentUser = new User
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Login = studentDto.Login,
                Password = studentDto.Password,
                UserRole = Role.Student,
                Student = student
            };

            // Execute entity adding
            var addedStudentUser = await _userRepository.AddAsync(studentUser);

            // Map to the view level
            return _mapper.Map<StudentUserReadDto>(addedStudentUser);
        }

        public async Task<IEnumerable<StudentUserReadDto>> SearchAsync(
            ISpecification<Student> specification)
        {
            var readedStudents = await _studentRepository.GetListAsync(specification);

            return _mapper.Map<List<StudentUserReadDto>>(readedStudents);
        }

        public async Task<StudentUserReadDto> UpdateGroupAsync(int groupId, int studentId)
        {
            Student student = await _studentRepository.GetEntityAsync(new StudentBaseSpecification(
                new StudentSearchParameters { Id = studentId } ));

            student.GroupId = groupId;

            var updatedStudent = await _studentRepository.UpdateAsync(student);

            return _mapper.Map<StudentUserReadDto>(updatedStudent);
        }
    }
}
