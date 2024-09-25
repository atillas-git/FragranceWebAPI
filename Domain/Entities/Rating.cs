using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int FragranceId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Fragrance Fragrance { get; set; }

        // Rating properties (Assuming scale of 1-5)
        [Range(1, 5)]
        public float OverallRating { get; set; }

        [Range(1, 5)]
        public float PriceRating { get; set; }

        [Range(1, 5)]
        public float FemininityRating { get; set; }

        [Range(1, 5)]
        public float MasculinityRating { get; set; }
    }

}
