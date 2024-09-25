using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.User
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? PictureUrl { get; set; }
        public string? Role { get; set; }
    }
}
