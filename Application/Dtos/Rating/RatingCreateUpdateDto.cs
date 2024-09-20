using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Rating
{
    public class RatingCreateUpdateDto
    {
        public int OverallRating { get; set; }
        public int PriceRating { get; set; }
        public int FemininityRating { get; set; }
        public int MasculinityRating { get; set; }
        public int UserId { get; set; }  // ID of the user giving the rating
        public int FragranceId { get; set; }  // ID of the fragrance being rated
    }
}
