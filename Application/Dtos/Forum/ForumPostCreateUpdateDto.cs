﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Forum
{
    public class ForumPostCreateUpdateDto
    {
        public string? Author { get; set; }
        public string? Content { get; set; }
        public int? ForumId { get; set; }
    }
}
