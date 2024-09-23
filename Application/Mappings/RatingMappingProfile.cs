using AutoMapper;
using Application.Dtos.Rating;
using Domain.Entities;

namespace Application.Mappings
{
    public class RatingMappingProfile : Profile
    {
        public RatingMappingProfile()
        {
            // Entity to DTO mapping
            CreateMap<Rating, RatingDto>()
                .ForMember(dest => dest.OverallRating, opt => opt.MapFrom(src => src.OverallRating))
                .ForMember(dest => dest.PriceRating, opt => opt.MapFrom(src => src.PriceRating))
                .ForMember(dest => dest.FemininityRating, opt => opt.MapFrom(src => src.FemininityRating))
                .ForMember(dest => dest.MasculinityRating, opt => opt.MapFrom(src => src.MasculinityRating));

            // DTO to Entity mapping for Create/Update operations
            CreateMap<RatingCreateUpdateDto, Rating>()
                .ForMember(dest => dest.OverallRating, opt => opt.MapFrom(src => src.OverallRating))
                .ForMember(dest => dest.PriceRating, opt => opt.MapFrom(src => src.PriceRating))
                .ForMember(dest => dest.FemininityRating, opt => opt.MapFrom(src => src.FemininityRating))
                .ForMember(dest => dest.MasculinityRating, opt => opt.MapFrom(src => src.MasculinityRating));
        }
    }
}

