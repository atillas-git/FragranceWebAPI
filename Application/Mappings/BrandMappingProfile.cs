using Application.Dtos.Brand;
using AutoMapper;
using Domain.Entities;
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
                .ForMember(dest => dest.Fragrances , opt => opt.MapFrom(src => src.Fragrances))
                .ForMember(dest => dest.RelatedArticles, opt => opt.MapFrom(src => src.RelatedArticles));

            CreateMap<BrandCreateUpdateDto, Brand>();
        }
    }
}
