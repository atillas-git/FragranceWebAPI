using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Rating
{
    public class RatingCreateUpdateDto
    {
        public float? OverallRating { get; set; }
        public float? PriceRating { get; set; }
        public float? FemininityRating { get; set; }
        public float? MasculinityRating { get; set; }
        public int? UserId { get; set; }  // ID of the user giving the rating
        public int? FragranceId { get; set; }  // ID of the fragrance being rated
    }
}
