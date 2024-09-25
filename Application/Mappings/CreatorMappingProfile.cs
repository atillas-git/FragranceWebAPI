using AutoMapper;
using Application.Dtos.Creator;
using Domain.Entities;
using Application.Dtos.Article;

namespace Application.Mappings
{
    public class CreatorMappingProfile : Profile
    {
        public CreatorMappingProfile()
        {
            // Entity to DTO mapping
            CreateMap<Creator, CreatorDto>()
                        .ForMember(dest => dest.RelatedArticles,
                                   opt => opt.MapFrom(src => src.RelatedArticles.Select(ar => new ArticleDto()
                                   {
                                       Author=ar.Author,
                                       Content=ar.Content,
                                       Id=ar.Id,
                                       PublishedDate=ar.PublishedDate,
                                       Title=ar.Title,
                                   })));

            // DTO to Entity mapping for Create/Update operations
            CreateMap<CreatorCreateUpdateDto, Creator>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
