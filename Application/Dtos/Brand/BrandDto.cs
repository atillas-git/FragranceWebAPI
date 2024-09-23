using Application.Dtos.Article;
using Application.Dtos.Fragrance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Brand
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string WebsiteUrl { get; set; }
        public string Description { get; set; }
        public IEnumerable<FragranceDto> Fragrances { get; set; }
        public IEnumerable<ArticleDto> RelatedArticles { get; set; }
    }

}
