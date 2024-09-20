using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Fragrance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public Gender Gender { get; set; }

        // Navigation properties
        public ICollection<FragranceCreator> FragranceCreators { get; set; }
        public ICollection<FragranceFragranceNote> FragranceFragranceNotes { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

}
