using AutoMapper;
using Application.Dtos.Creator;
using Domain.Entities;

namespace Application.Mappings
{
    public class CreatorMappingProfile : Profile
    {
        public CreatorMappingProfile()
        {
            // Entity to DTO mapping
            CreateMap<Creator, CreatorDto>()
                        .ForMember(dest => dest.RelatedArticles,
                                   opt => opt.MapFrom(src => src.RelatedArticles));

            // DTO to Entity mapping for Create/Update operations
            CreateMap<CreatorCreateUpdateDto, Creator>();
        }
    }
}
