using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string WebsiteUrl { get; set; }
        public string Description { get; set; }
        public ICollection<Fragrance> Fragrances { get; set; }
        public ICollection<Article> RelatedArticles { get; set; }
    }
}
