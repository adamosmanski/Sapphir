using SapphirApp.Core;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.ViewModels
{
    public class KanbanBoardVM : ObserveObject
    {
        public KanbanBoardVM()
        {
            Tasks = new List<TaskProject>();
            Tasks.Add(new TaskProject()
            {
                Name = "Pisda",
                Category = "In Progress"
            });
        }

        public List<TaskProject> Tasks { get; set; }
    }
}
