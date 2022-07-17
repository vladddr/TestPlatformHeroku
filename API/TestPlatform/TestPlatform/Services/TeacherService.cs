using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Enums;
using TestPlatform.DAL.Repositories;

namespace TestPlatform.API.Services
{
    public class TeacherService : GenericService<Teacher, TeacherBaseDto, TeacherBaseDto, TeacherReadDto>, ITeacherService
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IGenericRepository<User> _userRepository;

        private readonly IMapper _mapper;

        public TeacherService(IGenericRepository<Teacher> teacherRepository, IGenericRepository<User> userRepository, IMapper mapper) : base(teacherRepository, mapper)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _userRepository= userRepository;
        }

        public async Task<UserReadDto> RegisterTeacherAsync(TeacherBaseDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);

            var teacherUser = new User
            {
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                Login = teacherDto.Login,
                Password = teacherDto.Password,
                UserRole = Role.Teacher,
                Teacher = teacher
            };

            // Execute entity adding
            var addedTeacher = await _userRepository.AddAsync(teacherUser);

            // Map to the view level
            return _mapper.Map<UserReadDto>(addedTeacher);
        }
    }
}
