using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FragranceNote
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<FragranceFragranceNote> FragranceFragranceNotes { get; set; }
    }

}
