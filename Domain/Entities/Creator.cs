using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Creator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PictureUrl { get; set; }

        // Navigation property
        public ICollection<FragranceCreator> FragranceCreators { get; set; }
        public ICollection<Article> RelatedArticles { get; set; }
    }

}
