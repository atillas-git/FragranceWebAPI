using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }

        // Relationship: A post belongs to one forum
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }

}
