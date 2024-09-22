using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }

        // Relationships
        public ICollection<Fragrance> RelatedFragrances { get; set; }
        public ICollection<Brand> RelatedBrands { get; set; }
        public ICollection<Creator> RelatedCreators { get; set; }
    }

}
