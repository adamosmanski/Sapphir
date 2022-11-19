using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Models
{
    public  class TaskProject
    {
        public int Id { get; set; }

        public int IdProjects { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string? AssignedUser { get; set; }

        public string? Tag { get; set; }

        public DateTime? ModDate { get; set; }

        public int? ModUser { get; set; }
        public string Category { get; set; }
        public string ShortNumber { get; set; }
    }
}
