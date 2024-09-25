using AutoMapper;
using Application.Dtos.Comment;
using Domain.Entities;
using Application.Dtos.User;
using Application.Dtos.Fragrance;

namespace Application.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            // Entity to DTO mapping
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Pros, opt => opt.MapFrom(src => src.Pros))
                .ForMember(dest => dest.Cons, opt => opt.MapFrom(src => src.Cons))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.User , opt => opt.MapFrom(src => new UserDto()
                {
                    Email = src.User.Email,
                    Id = src.User.Id,
                    PictureUrl = src.User.PictureUrl,
                }))
                .ForMember(dest => dest.Fragrance,opt => opt.MapFrom(src => new FragranceDto()
                {
                    Name = src.Fragrance.Name,
                    PictureUrl = src.Fragrance.PictureUrl,
                    Gender = src.Fragrance.Gender.ToString(),
                }));

            // DTO to Entity mapping for Create/Update operations
            CreateMap<CommentCreateUpdateDto, Comment>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Pros, opt => opt.MapFrom(src => src.Pros))
                .ForMember(dest => dest.Cons, opt => opt.MapFrom(src => src.Cons))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }

}

