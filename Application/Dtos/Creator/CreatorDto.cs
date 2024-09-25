using Application.Dtos.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Creator
{
    public class CreatorDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? PictureUrl { get; set; }
        public IEnumerable<ArticleDto>? RelatedArticles { get; set; }
    }
}

