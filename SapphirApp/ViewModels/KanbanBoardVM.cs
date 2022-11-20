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
        private bool _IsGridVisible = false;
        public bool IsGridVisible
        {
            get => _IsGridVisible;
            set
            {
                _IsGridVisible = value;
                OnPropertyChanged(nameof(IsGridVisible));
            }
        }
        public KanbanBoardVM()
        {
            IsGridVisible = _IsGridVisible;
            tasksRepository = new TaskRepository(context);
            Tasks = DtoTasksToModel.Transform(tasksRepository.GetAllTasks(SelectedProject.ID));
            ShowGridToAddTask = new RelayCommand(ShowGridWithTask);
        }
        public List<TaskProject> Tasks { get; set; }
        public ICommand ShowGridToAddTask { get; }
        public void ShowGridWithTask(object obj)
        {
           // SelectedProject.Number = tasksRepository.GetLastNumberTask(SelectedProject.ID);
            IsGridVisible = true;
            
        }

    }
}
