using Application.Dtos.Article;
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
            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.RelatedBrands , opt => opt.MapFrom(src => src.RelatedBrands))
                .ForMember(dest => dest.RelatedCreators , opt => opt.MapFrom(src => src.RelatedCreators))
                .ForMember(dest => dest.RelatedFragrances,opt => opt.MapFrom(src => src.RelatedFragrances));

            CreateMap<ArticleCreateUpdateDto, Article>();

        }

    }
}
