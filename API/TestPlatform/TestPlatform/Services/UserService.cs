using AutoMapper;
using TestPlatform.API.DataTransfer;
using TestPlatform.Core.Entities;
using TestPlatform.Core.Specifications;
using TestPlatform.DAL.Repositories;

namespace TestPlatform.API.Services
{
    public class UserService : IUserService
    {
        public readonly IGenericRepository<User> _userRepository;
        public readonly IMapper _mapper;

        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper; 
        }

        public async Task<object> ReadSpecefiedAsync(ISpecification<User> specification)
        {
            var readedUser = await _userRepository.GetEntityAsync(specification);
            
            if (readedUser == null)
            {
                return null;
            }

            if (readedUser.Teacher is not null)
            {
                return _mapper.Map<TeacherUserReadDto>(readedUser);
            }

            if (readedUser.Student is not null)
            {
                return _mapper.Map<StudentReadDto>(readedUser);
            }

            return _mapper.Map<UserReadDto>(readedUser);
        }

        public async Task<IEnumerable<object>> SearchAsync(ISpecification<User> specification)
        {
            var readedList = await _userRepository.GetListAsync(specification);

            if (readedList == null || !readedList.Any())
            {
                return null;
            }
            else
            {
                List<object> list = new List<object>();

                foreach (var readedUser in readedList.ToList())
                {
                    if (readedUser.Teacher is not null)
                    {
                        list.Add(_mapper.Map<TeacherUserReadDto>(readedUser));
                    }

                    if (readedUser.Student is not null)
                    {
                        list.Add(_mapper.Map<StudentReadDto>(readedUser));
                    }
                }

                return list;
            }
        }
    }
}
