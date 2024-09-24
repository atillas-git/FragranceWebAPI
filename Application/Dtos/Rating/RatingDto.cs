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
        public int? OverallRating { get; set; }
        public int? PriceRating { get; set; }
        public int? FemininityRating { get; set; }
        public int? MasculinityRating { get; set; }
        public UserDto? User { get; set; }  // Nested user details
        public FragranceDto? Fragrance { get; set; }  // Nested fragrance details
    }
}
