using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            AddTask = new RelayCommand(AddTaskToProject);
        }
        public List<TaskProject> Tasks { get; set; }
        public ICommand AddTask { get; }
        public void AddTaskToProject(object obj)
        {
            SelectedProject.Number = tasksRepository.GetLastNumberTask(SelectedProject.ID);
            
        }

    }
}
