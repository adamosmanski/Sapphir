﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string ShortNumber { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ModUser { get; set; }

        public DateTime? ModDate { get; set; }
    }
}
