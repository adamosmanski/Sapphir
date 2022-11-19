using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
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
        SapphirApplicationContext context = new SapphirApplicationContext();
        TaskRepository tasksRepository;
        public KanbanBoardVM()
        {
            tasksRepository = new TaskRepository(context);
            Tasks = DtoTasksToModel.Transform(tasksRepository.GetAllTasks(SelectedProject.ID));
        }
        public List<TaskProject> Tasks { get; set; }


    }
}
