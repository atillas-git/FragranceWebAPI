using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FragranceFragranceNote
    {
        public int FragranceId { get; set; }
        public Fragrance Fragrance { get; set; }

        public int FragranceNoteId { get; set; }
        public FragranceNote FragranceNote { get; set; }
    }

}
