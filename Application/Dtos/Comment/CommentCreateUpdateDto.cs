using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Comment
{
    public class CommentCreateUpdateDto
    {
        public string? Content { get; set; }
        public string? Pros { get; set; }
        public string? Cons { get; set; }
        public int? UserId { get; set; }  // ID of the user leaving the comment
        public int? FragranceId { get; set; }  // ID of the fragrance being commented on
    }
}
