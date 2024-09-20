using AutoMapper;
using Application.Dtos.Creator;
using Domain.Entities;

public class CreatorMappingProfile : Profile
{
    public CreatorMappingProfile()
    {
        // Entity to DTO mapping
        CreateMap<Creator, CreatorDto>();

        // DTO to Entity mapping for Create/Update operations
        CreateMap<CreatorCreateUpdateDto, Creator>();
    }
}
