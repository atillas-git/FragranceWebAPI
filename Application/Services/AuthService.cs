using Application.Dtos.Auth;
using Application.Interfaces;
using Application.Messages;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static BCrypt.Net.BCrypt;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public async Task<AuthResponseDto> LoginAsync(AuthRequestDto authRequest)
        {
            var user = await _userRepository.GetUserByEmailAsync(authRequest.Email);
            if(user == null || !Verify(authRequest.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException(ResponseMessages.Auth_AuthUnauthorized);
            }

            var token = GenerateJwtToken(user);

            return new AuthResponseDto()
            {
                Token = token,
                Role = user.Role,
                UserId = user.Id,
            };

        }

        public async Task<bool> RegisterAsync(RegisterRequestDto registerRequest)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerRequest.Email);
            if(existingUser != null)
            {
                throw new KeyNotFoundException(ResponseMessages.Auth_AuthUserNotFound);
            }
            var hashedPassword = HashPassword(registerRequest.Password);

            var newUser = new User
            {
                Email = registerRequest.Email,
                PasswordHash = hashedPassword,
                Role = "User"  // Default role
            };

            await _userRepository.AddUserAsync(newUser);

            return true;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name,user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
