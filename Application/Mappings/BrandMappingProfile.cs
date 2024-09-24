using Application.Dtos.Article;
using Application.Dtos.Brand;
using Application.Dtos.Fragrance;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class BrandMappingProfile:Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandDto>()
                .ForMember(dest => dest.Fragrances , 
                    opt => opt.MapFrom(src => src.Fragrances.Select(f => new FragranceDto() {
                        Id = f.Id,
                        Name = f.Name,
                        PictureUrl = f.PictureUrl,
                        Gender = f.Gender.ToString(),
                    })))
                .ForMember(dest => dest.RelatedArticles, opt => opt.MapFrom(src => src.RelatedArticles.Select(a => new ArticleDto() { 
                    Id= a.Id,
                    Content = a.Content,
                    PublishedDate = a.PublishedDate,
                    Author = a.Author
                })));

            CreateMap<BrandCreateUpdateDto, Brand>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
