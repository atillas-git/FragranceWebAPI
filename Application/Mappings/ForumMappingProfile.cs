using Application.Dtos.Forum;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class ForumMappingProfile:Profile
    {
        public ForumMappingProfile()
        {
            CreateMap<Forum, ForumDto>()
                .ForMember(dest => dest.Posts , opt => opt.MapFrom(src => src.Posts));
            
            CreateMap<ForumCreateUpdateDto, Forum>();

            CreateMap<ForumPost, ForumPostDto>()
                .ForMember(dest => dest.Forum,opt => opt.MapFrom(src => src.Forum));

            CreateMap<ForumPostCreateUpdateDto, ForumPost>();
        }
    }
}
