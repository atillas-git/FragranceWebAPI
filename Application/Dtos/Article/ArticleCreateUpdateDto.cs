﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Article
{
    public class ArticleCreateUpdateDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedDate { get; set; }
        public IEnumerable<int>? RelatedFragranceIds { get; set; }
        public IEnumerable<int>? RelatedBrandIds { get; set; }
        public IEnumerable<int>? RelatedCreatorIds { get; set; }
    }
}
