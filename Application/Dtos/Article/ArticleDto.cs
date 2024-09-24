using Application.Dtos.Brand;
using Application.Dtos.Creator;
using Application.Dtos.Fragrance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dtos.Article
{
    public class ArticleDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedDate { get; set; }

        public IEnumerable<FragranceDto>? RelatedFragrances { get; set; } // Include related DTOs as needed

        public IEnumerable<BrandDto>? RelatedBrands { get; set; } // Include related DTOs as needed

        public IEnumerable<CreatorDto>? RelatedCreators { get; set; } // Include related DTOs as needed
    }

}
