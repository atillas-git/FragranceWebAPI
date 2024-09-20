using AutoMapper;
using Application.Dtos.User;
using Domain.Entities;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        // Entity to DTO mapping
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        // DTO to Entity mapping for Create/Update operations
        CreateMap<UserCreateUpdateDto, User>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());  // Assume password is hashed in service layer
    }
}

