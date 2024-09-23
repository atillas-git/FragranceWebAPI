using AutoMapper;
using Application.Dtos.Comment;
using Domain.Entities;

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
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            // DTO to Entity mapping for Create/Update operations
            CreateMap<CommentCreateUpdateDto, Comment>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Pros, opt => opt.MapFrom(src => src.Pros))
                .ForMember(dest => dest.Cons, opt => opt.MapFrom(src => src.Cons))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));  // Automatically set created date
        }
    }

}

