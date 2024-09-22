using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Auth
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
