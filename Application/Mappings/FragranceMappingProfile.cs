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
    public class FragranceMappingProfile : Profile
    {
        public FragranceMappingProfile()
        {
            // Map Fragrance entity to FragranceDto
            CreateMap<Fragrance, FragranceDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Creators, opt => opt.MapFrom(src => src.FragranceCreators.Select(fc => fc.Creator)))
                .ForMember(dest => dest.FragranceNotes, opt => opt.MapFrom(src => src.FragranceFragranceNotes.Select(fn => fn.FragranceNote)))
                .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            // Map FragranceCreateUpdateDto to Fragrance entity (for create/update operations)
            CreateMap<FragranceCreateUpdateDto, Fragrance>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Domain.Enums.Gender)Enum.Parse(typeof(Domain.Enums.Gender), src.Gender)))
                .ForMember(dest => dest.FragranceCreators, opt => opt.MapFrom(src => src.CreatorIds.Select(id => new FragranceCreator { CreatorId = id })))
                .ForMember(dest => dest.FragranceFragranceNotes, opt => opt.MapFrom(src => src.NoteIds.Select(id => new FragranceFragranceNote { FragranceNoteId = id })));
        }
    }
}
