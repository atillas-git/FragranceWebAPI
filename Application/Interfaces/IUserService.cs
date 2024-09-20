using Application.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int id);  // Retrieve a single user by ID
        Task<UserDto> GetUserByEmailAsync(string email);  // Retrieve user by email
        Task<IEnumerable<UserDto>> GetAllUsersAsync();  // Retrieve all users
        Task AddUserAsync(UserCreateUpdateDto userDto);  // Add a new user
        Task UpdateUserAsync(int id, UserCreateUpdateDto userDto);  // Update an existing user
        Task DeleteUserAsync(int id);  // Delete a user
    }
}


