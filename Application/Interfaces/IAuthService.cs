using System.Threading.Tasks;
using Application.Dtos.Auth;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(AuthRequestDto authRequest);  // Handle login and return JWT
        Task<bool> RegisterAsync(RegisterRequestDto registerRequest);  // Register a new user
    }
}

