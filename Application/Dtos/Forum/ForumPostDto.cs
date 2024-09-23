using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Forum
{
    public class ForumPostDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public int ForumId { get; set; }
        public ForumDto Forum { get; set; }
    }

}
