using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SapphirApp.ViewModels
{
    public class MyTaskVM : ObserveObject
    {
        #region Variables
        private SapphirApplicationContext context = new SapphirApplicationContext();
        private TaskRepository Repository;
        public List<TaskProject> MyTaskList { get; set; }
        private TaskProject _taskSelected = new TaskProject();
        public TaskProject TaskSelected
        {
            get => _taskSelected;
            set
            {
                _taskSelected = value;
                OnPropertyChanged(nameof(TaskSelected));
            }
        }
        private TaskProject _taskFromDB = new TaskProject(); 
        public TaskProject TaskFromDB
        {
            get => _taskFromDB;
            set
            {
                _taskFromDB = value;
                OnPropertyChanged(nameof(TaskFromDB));
            }
        }
        private bool _isVisible = false;
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                IsVisible= value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }
        public ICommand ShowDetailsTask { get; }
        #endregion
        public MyTaskVM()
        {
            TaskFromDB = _taskFromDB;
            Repository = new TaskRepository(context);
            MyTaskList = DtoTasksToModel.TransformToMyTask(Repository.GetUserTasks(LoggedUser.Login));
            ShowDetailsTask = new RelayCommand(ShowTask);
        }
        private void ShowTask(object obj)
        {
            
        }
    }
}
