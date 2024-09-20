using Application.Dtos.Fragrance;
using Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserDto User { get; set; }  // Nested user details
        public FragranceDto Fragrance { get; set; }  // Nested fragrance details
    }
}
