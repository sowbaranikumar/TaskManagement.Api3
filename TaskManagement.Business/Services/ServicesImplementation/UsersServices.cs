using AutoMapper;

using TaskManagement.Business.DTOs;
using TaskManagement.Business.Interfaces;
using TaskManagement.Data.Repositories.Interfaces;
using TaskManagement.Entity.Entities;

namespace TaskManagement.Business.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersServices(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _usersRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _usersRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }
    }
}
