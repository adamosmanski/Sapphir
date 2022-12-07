using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Interface;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using SapphirApp.Views;
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
        private UserRepository userRepository;
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
        private MessagesInTask _message = new MessagesInTask();
        public MessagesInTask Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
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
        public ICommand ChangeAssignedUser { get; }
        public ICommand AddComment { get; }
        public ICommand CloseDetailsTask { get; }
        #endregion
        public MyTaskVM()
        {
            IsShowed = _isVisible;
            TaskFromDB = _taskFromDB;
            taskRepository = new TaskRepository(context);
            userRepository = new UserRepository(context);
            MyTaskList = DtoTasksToModel.TransformToMyTask(taskRepository.GetUserTasks(LoggedUser.Login));
            commentsRepository = new CommentsRepository(context);
            ShowDetailsTask = new RelayCommand(ShowTask);
            CloseDetailsTask = new RelayCommand(CloseTask);
            ChangeAssignedUser = new RelayCommand(ChangeUser);
            AddComment = new RelayCommand(AddCommentToTask);
        }


        #region Methods
        private void ChangeUser(object obj)
        {
            var isExistUser = userRepository.isExist(TaskFromDB.AssignedUser);
            if (isExistUser == true)
            {
                taskRepository.UpdateColumn(SelectedTask.ShortName,TaskFromDB.Category ,TaskFromDB.AssignedUser);               
            }
            else
            {
                NotifyPopUp window = new NotifyPopUp();
                NotifyPopUpVM model = new NotifyPopUpVM("Podany użytkownik nie istnieje.");
                window.DataContext = model;
            }
        }
        private void AddCommentToTask(object obj)
        {
            var shortName = obj.ToString();
            Message.ShortTaskName = shortName;
            Message.UserName = LoggedUser.Login;
            Message.Time = DateTime.Now;
            commentsRepository.AddComment(DtoTasksToModel.ConverterComments(Message));
            Messages = DtoTasksToModel.TransformComment(commentsRepository.ShowAllComment(shortName));
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
        #endregion
    }
}
