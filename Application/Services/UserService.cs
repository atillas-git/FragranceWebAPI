using AutoMapper;
using Application.Dtos.User;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Messages;
using Application.Exceptions;
using static BCrypt.Net.BCrypt;

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

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) {
                throw new KeyNotFoundException(ResponseMessages.User_UserDoesNotExist);
            }
            return _mapper.Map<UserDto>(user);  // Use AutoMapper to map entity to DTO
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new KeyNotFoundException(ResponseMessages.User_UserDoesNotExist);
            }
            return _mapper.Map<UserDto>(user);  // Map entity to DTO
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task AddUserAsync(UserCreateUpdateDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Email))
            {
                throw new AppException(ResponseMessages.Shared_PleaseFillTheRequiredFields);
            }
            var user = _mapper.Map<User>(userDto);  // Map DTO to entity
            if (!string.IsNullOrEmpty(userDto.Password))
            {
                var hashedPassword = HashPassword(userDto.Password);
                user.PasswordHash = hashedPassword;
            }
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, UserCreateUpdateDto userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException(ResponseMessages.User_UserDoesNotExist);
            }
            _mapper.Map(userDto, user);
            if (!string.IsNullOrEmpty(userDto.Password))
            {
                user.PasswordHash = HashPassword(userDto.Password);
            }

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException(ResponseMessages.User_UserDoesNotExist);
            }
            await _userRepository.DeleteUserAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetByNameAsync(string name)
        {
            var users = await _userRepository.GetUsersByNameAsync(name);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}


