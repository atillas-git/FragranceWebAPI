using Application.Dtos.Fragrance;
using Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Rating
{
    public class RatingDto
    {
        public int? Id { get; set; }
        public float? OverallRating { get; set; }
        public float? PriceRating { get; set; }
        public float? FemininityRating { get; set; }
        public float? MasculinityRating { get; set; }
        public UserDto? User { get; set; }  // Nested user details
        public FragranceDto? Fragrance { get; set; }  // Nested fragrance details
    }
}
