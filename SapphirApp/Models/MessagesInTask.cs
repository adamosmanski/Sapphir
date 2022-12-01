using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Models
{
    public class MessagesInTask
    {
        public string ShortTaskName { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
