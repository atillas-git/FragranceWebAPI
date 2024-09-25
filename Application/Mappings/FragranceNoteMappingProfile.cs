using AutoMapper;
using Application.Dtos.FragranceNote;
using Domain.Entities;

namespace Application.Mappings
{
    public class FragranceNoteMappingProfile : Profile
    {
        public FragranceNoteMappingProfile()
        {
            // Entity to DTO mapping
            CreateMap<FragranceNote, FragranceNoteDto>();

            // DTO to Entity mapping for Create/Update operations
            CreateMap<FragranceNoteCreateUpdateDto, FragranceNote>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

