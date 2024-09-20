using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FragranceCreator
    {
        public int FragranceId { get; set; }
        public Fragrance Fragrance { get; set; }

        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
    }

}
