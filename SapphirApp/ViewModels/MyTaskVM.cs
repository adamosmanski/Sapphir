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
        private TaskRepository taskRepository;
        private CommentsRepository commentsRepository;
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
        private List<MessagesInTask> _messagesInTask;
        public List<MessagesInTask> Messages
        {
            get=> _messagesInTask;
            set
            {
                _messagesInTask = value;
                OnPropertyChanged(nameof(Messages));
            }
        }
        private bool _isVisible = false;
        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        public bool IsShowed
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsShowed));
            }
        }
        #endregion
        #region Commands
        public ICommand ShowDetailsTask { get; }
        public ICommand CloseDetailsTask { get; }
        #endregion
        public MyTaskVM()
        {
            IsShowed = _isVisible;
            TaskFromDB = _taskFromDB;
            taskRepository = new TaskRepository(context);
            MyTaskList = DtoTasksToModel.TransformToMyTask(taskRepository.GetUserTasks(LoggedUser.Login));
            commentsRepository = new CommentsRepository(context);
            ShowDetailsTask = new RelayCommand(ShowTask);
            CloseDetailsTask = new RelayCommand(CloseTask);
        }

        private void CloseTask(object obj)
        {
            IsShowed = false;
        }

        private void ShowTask(object obj)
        {
            IsShowed = true;
            TaskFromDB = DtoTasksToModel.ConverterTask(taskRepository.ShowTask(TaskSelected.ShortNumber));
            Messages = DtoTasksToModel.TransformComment(commentsRepository.ShowAllComment(TaskSelected.ShortNumber));
        }
    }
}
