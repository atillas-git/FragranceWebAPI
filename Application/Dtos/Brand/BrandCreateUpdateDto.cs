using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Brand
{
    public class BrandCreateUpdateDto
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
    }
}
