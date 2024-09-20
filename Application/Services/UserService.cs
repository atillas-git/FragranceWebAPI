using AutoMapper;
using Application.Dtos.User;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);  // Use AutoMapper to map entity to DTO
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserDto>(user);  // Map entity to DTO
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task AddUserAsync(UserCreateUpdateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);  // Map DTO to entity

            // Handle password hashing if necessary, e.g.:
            // user.PasswordHash = HashPassword(userDto.Password);

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserCreateUpdateDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return;

            _mapper.Map(userDto, user);  // Map updated DTO to existing entity

            // Handle password hashing if necessary, e.g.:
            // if (!string.IsNullOrEmpty(userDto.Password))
            // {
            //     user.PasswordHash = HashPassword(userDto.Password);
            // }

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}


