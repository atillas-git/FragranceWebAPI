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
                .ForMember(dest => dest.Posts , opt => opt.MapFrom(src => src.Posts != null ?
                    src.Posts.Select(p => new ForumPostDto() { 
                        Author = p.Author,
                        Content = p.Content,
                        ForumId = p.ForumId,
                        Id = p.Id,
                        PostedDate = p.PostedDate,
                }):Enumerable.Empty<ForumPostDto>()));
            
            CreateMap<ForumCreateUpdateDto, Forum>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ForumPost, ForumPostDto>()
                .ForMember(dest => dest.Forum,opt => opt.MapFrom(src => new ForumDto() { 
                    Id = src.Forum.Id,
                    Description = src.Forum.Description,
                    CreatedDate = src.Forum.CreatedDate,
                    Title = src.Forum.Title,
                }));

            CreateMap<ForumPostCreateUpdateDto, ForumPost>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
