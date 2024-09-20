using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Fragrance
{
    public class FragranceCreateUpdateDto
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Gender { get; set; }  // Gender as string, convert to enum in service
        public IEnumerable<int> CreatorIds { get; set; }  // List of Creator IDs
        public IEnumerable<int> NoteIds { get; set; }  // List of Fragrance Note IDs
    }
}
