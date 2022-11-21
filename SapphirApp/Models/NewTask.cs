using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Models
{
    public class NewTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssignedUser { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ProjectID { get; set; }
        public string ShortNumber { get; set; }
        public string Category { get; set; }
        public int CreatedByID { get; set; }
        public DateTime ModDate { get; set; }
        public string Tag { get; set; }
    }
}
