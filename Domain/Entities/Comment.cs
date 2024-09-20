using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int FragranceId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Fragrance Fragrance { get; set; }

        // Comment content
        public string Content { get; set; }

        // Pros and Cons
        public string Pros { get; set; }
        public string Cons { get; set; }

        // Timestamp
        public DateTime CreatedAt { get; set; }
    }

}
