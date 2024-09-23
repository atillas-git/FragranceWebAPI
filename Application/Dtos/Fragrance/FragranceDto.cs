using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Brand;
using Application.Dtos.Comment;
using Application.Dtos.Creator;
using Application.Dtos.FragranceNote;
using Application.Dtos.Rating;

namespace Application.Dtos.Fragrance
{
    public class FragranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Gender { get; set; }  // Assuming Gender is an enum
        public IEnumerable<CreatorDto> Creators { get; set; }
        public IEnumerable<FragranceNoteDto> FragranceNotes { get; set; }
        public IEnumerable<RatingDto> Ratings { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public BrandDto Brand { get; set; }
    }
}
