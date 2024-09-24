using Application.Dtos.Brand;
using Application.Dtos.Comment;
using Application.Dtos.Creator;
using Application.Dtos.Fragrance;
using Application.Dtos.FragranceNote;
using Application.Dtos.Rating;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.Mappings
{
    public class FragranceMappingProfile : Profile
    {
        public FragranceMappingProfile()
        {
            // Map Fragrance entity to FragranceDto
            CreateMap<Fragrance, FragranceDto>()
                .ForMember(dest => dest.Gender,
                           opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Creators,
                           opt => opt.MapFrom(src => src.FragranceCreators != null
                               ? src.FragranceCreators.Select(fc => new CreatorDto()
                               {
                                   Name = fc.Creator.Name,
                                   Id = fc.CreatorId,
                               }) : Enumerable.Empty<CreatorDto>()))
                .ForMember(dest => dest.FragranceNotes,
                           opt => opt.MapFrom(src => src.FragranceFragranceNotes != null
                               ? src.FragranceFragranceNotes.Select(fn => new FragranceNoteDto()
                               {
                                   Id = fn.FragranceNoteId,
                                   Name = fn.FragranceNote.Name,
                               }) : Enumerable.Empty<FragranceNoteDto>()))
                .ForMember(dest => dest.Ratings,
                           opt => opt.MapFrom(src => src.Ratings != null
                               ? src.Ratings.Select(r => new RatingDto()
                               {
                                   Id = r.Id,
                                   FemininityRating = r.FemininityRating,
                                   MasculinityRating = r.MasculinityRating,
                                   OverallRating = r.OverallRating,
                                   PriceRating = r.PriceRating,
                               }) : Enumerable.Empty<RatingDto>()))
                .ForMember(dest => dest.Comments,
                           opt => opt.MapFrom(src => src.Comments != null
                               ? src.Comments.Select(cm => new CommentDto()
                               {
                                   Id = cm.Id,
                                   Cons = cm.Cons,
                                   Content = cm.Content,
                                   CreatedAt = cm.CreatedAt,
                                   Pros = cm.Pros,
                                   UserId = cm.User.Id,
                                   UserName = cm.User.Name,
                                   UserPictureUrl = cm.User.PictureUrl
                               }) : Enumerable.Empty<CommentDto>()))
                .ForMember(dest => dest.Brand,
                           opt => opt.MapFrom(src => new BrandDto()
                           {
                               Id = src.Brand.Id, // Use src.Brand
                               Country = src.Brand.Country,
                               Name = src.Brand.Name,
                               Description = src.Brand.Description
                           }));


            // Map FragranceCreateUpdateDto to Fragrance entity (for create/update operations)
            CreateMap<FragranceCreateUpdateDto, Fragrance>()
                .ForMember(dest => dest.Gender,
                           opt => opt.MapFrom(src => MapGender(src.Gender)))
                .ForMember(dest => dest.FragranceCreators,
                           opt => opt.MapFrom(src => src.CreatorIds != null
                               ? src.CreatorIds.Select(id => new FragranceCreator { CreatorId = id })
                               : Enumerable.Empty<FragranceCreator>()))
                .ForMember(dest => dest.FragranceFragranceNotes,
                           opt => opt.MapFrom(src => src.NoteIds != null
                               ? src.NoteIds.Select(id => new FragranceFragranceNote { FragranceNoteId = id })
                               : Enumerable.Empty<FragranceFragranceNote>()))
                .ForMember(dest => dest.BrandId,
                           opt => opt.MapFrom(src => src.BrandId ?? 0))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }

        private Gender MapGender(string genderString)
        {

            if (string.IsNullOrWhiteSpace(genderString))
            {
                return Gender.Unisex; // Or some default value
            }

            genderString = genderString.Trim(); // Trim whitespace

            if (Enum.TryParse(typeof(Gender), genderString, true, out var genderValue))
            {
                return (Gender)genderValue;
            }

            var validValues = string.Join(", ", Enum.GetNames(typeof(Gender)));
            throw new ArgumentException($"Invalid Gender value: {genderString}. Valid values are: {validValues}");
        }


    }
}

