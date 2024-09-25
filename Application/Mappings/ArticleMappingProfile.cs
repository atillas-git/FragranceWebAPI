using Application.Dtos.Article;
using Application.Dtos.Brand;
using Application.Dtos.Creator;
using Application.Dtos.Fragrance;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ArticleMappingProfile:Profile
    {
        public ArticleMappingProfile()
        {
            // Map from Article to ArticleDto
            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.RelatedFragrances, opt => opt.MapFrom(src => src.RelatedFragrances))
                .ForMember(dest => dest.RelatedBrands, opt => opt.MapFrom(src => src.RelatedBrands))
                .ForMember(dest => dest.RelatedCreators, opt => opt.MapFrom(src => src.RelatedCreators))
                .PreserveReferences(); // Prevent cycles in JSON serialization

            // Map from ArticleCreateUpdateDto to Article
            CreateMap<ArticleCreateUpdateDto, Article>()
                .ForMember(dest => dest.RelatedFragrances, opt => opt.MapFrom(src => src.RelatedFragranceIds != null ?
                    src.RelatedFragranceIds.Select(fid => new FragranceDto(){ Id = fid })
                    :Enumerable.Empty<FragranceDto>()))
                .ForMember(dest => dest.RelatedBrands, opt => opt.MapFrom(src => src.RelatedBrandIds != null ?
                    src.RelatedBrandIds.Select(id => new BrandDto() { Id = id})
                    :Enumerable.Empty<BrandDto>()))
                .ForMember(dest => dest.RelatedCreators, opt => opt.MapFrom(src => src.RelatedCreatorIds != null ?
                    src.RelatedCreatorIds.Select(id => new CreatorDto() { Id = id})
                    :Enumerable.Empty<CreatorDto>()))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .PreserveReferences();

        }

    }
}
