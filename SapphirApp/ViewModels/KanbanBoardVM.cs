using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Interface;
using SapphirApp.Data.Models;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using Syncfusion.UI.Xaml.Kanban;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace SapphirApp.ViewModels
{
    public class KanbanBoardVM : ObserveObject
    {
        #region Variables
        SapphirApplicationContext context = new SapphirApplicationContext();
        TaskRepository tasksRepository;
        CommentsRepository commentsRepository;
        private bool _IsGridVisible = false;
        private bool _isKanbanEnabled = true;

        private NewTask _newTask = new NewTask();
        MessagesInTask message = new MessagesInTask();
        private List<MessagesInTask> _messagesInTask = new List<MessagesInTask>();
        public List<MessagesInTask> ListMessages
        {
            get => _messagesInTask;
            set
            {
                _messagesInTask = value;
                OnPropertyChanged(nameof(ListMessages));
            }
        }
        public NewTask newTask
        {
            get => _newTask;
            set
            {
                _newTask = value;
                OnPropertyChanged(nameof(newTask));
            }
        }
        public int ID
        {
            get => newTask.ID;
            set
            {
                newTask.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Name
        {
            get=>newTask.Name;
            set
            {
                newTask.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get =>newTask.Description;
            set
            {
                newTask.Description=value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string AssignedUser
        {
            get =>newTask.AssignedUser; 
            set
            {
                newTask.AssignedUser = value;
                OnPropertyChanged(nameof(AssignedUser));
            }
        }
        public DateTime CreatedTime
        {
            get =>newTask.CreatedTime; 
            set
            {
                newTask.CreatedTime = value;
                OnPropertyChanged(nameof(CreatedTime));
            }
        }
        public int ProjectID
        {
            get =>newTask.ProjectID; 
            set
            {
                newTask.ProjectID = value;
                OnPropertyChanged(nameof(ProjectID));
            }
        }
        public string ShortNumber
        {
            get =>newTask.ShortNumber; 
            set
            {
                newTask.ShortNumber = value;
                OnPropertyChanged(nameof(ShortNumber));
            }
        }
        public string Category
        {
            get =>newTask.Category; 
            set
            {
                newTask.Category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public int CreatedByID
        {
            get =>newTask.CreatedByID; 
            set
            {
                newTask.CreatedByID = value;
                OnPropertyChanged(nameof(CreatedByID));
            }
        }
        public DateTime ModDate
        {
            get =>newTask.ModDate;
            set
            {
                newTask.ModDate = value;
                OnPropertyChanged(nameof(ModDate));
            }
        }
        public string Tag
        {
            get => newTask.Tag;
            set
            {
                newTask.Tag = value;
                OnPropertyChanged(nameof(Tag));
            }
        }
        public bool IsGridVisible
        {
            get => _IsGridVisible;
            set
            {
                _IsGridVisible = value;
                OnPropertyChanged(nameof(IsGridVisible));
            }
        }
        public bool IsKanbanEnabled
        {
            get => _isKanbanEnabled;
            set
            {
                _isKanbanEnabled = value;
                OnPropertyChanged(nameof(IsKanbanEnabled));
            }
        }
        private List<TaskProject> _task;
        public List<TaskProject> Tasks
        {
            get => _task;
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
        
        private List<string> _columns = new List<string>()
        {
            "Unassigned", "Backlog","To Do","In Progress" ,"In Test", "Review", "Completed"
        };
        private string _selectedColumn;
        private string _assignedUser;
        private bool _isTaskVisible = false;
        public bool IsTaskVisible
        {
            get => _isTaskVisible;
            set
            {
                _isTaskVisible = value;
                OnPropertyChanged(nameof(IsTaskVisible));
            }
        }
        public string OldAssignedUser
        {
            get => _assignedUser;
            set
            {
                _assignedUser = value;
                OnPropertyChanged(nameof(OldAssignedUser));
            }
        }
        public List<string> Columns
        {
            get => _columns;
            set
            {
                _columns = value;
                OnPropertyChanged(nameof(Columns));
            }
        }
        public string SelectedColumn
        {
            get => _selectedColumn;
            set
            {
                _selectedColumn = value;
                OnPropertyChanged(nameof(SelectedColumn));
            }
        }
        public string Comment
        {
            get => message.Message;
            set
            {
                message.Message = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        public ICommand ShowGridToAddTask { get; }
        public ICommand CancelTask { get; }
        public ICommand AddTask { get; }
        public ICommand TaskShow { get; }
        public ICommand CloseTask { get; }
        public ICommand UpdateTask { get; }
        public ICommand AddComments { get; }
        #endregion
        public KanbanBoardVM()
        {
            ListMessages = _messagesInTask;
            Comment = message.Message;
            Name = newTask.Name;
            Description = newTask.Description;
            AssignedUser = newTask.AssignedUser;
            CreatedTime = newTask.CreatedTime;
            ProjectID = newTask.ProjectID;
            ShortNumber = newTask.ShortNumber;
            Category = newTask.Category;
            CreatedByID = newTask.CreatedByID;
            ModDate = newTask.ModDate;
            Tag = newTask.Tag;
            IsTaskVisible = _isTaskVisible;
            Columns = _columns;
            Tasks = _task;
            IsGridVisible = _IsGridVisible;
            commentsRepository = new CommentsRepository(context);
            tasksRepository = new TaskRepository(context);            
            ShowGridToAddTask = new RelayCommand(ShowGridWithTask);
            CancelTask = new RelayCommand(CancelAddTask);
            AddTask = new RelayCommand(AddTaskToDto);
            TaskShow = new RelayCommand(ShowInfoTask);
            CloseTask = new RelayCommand(CloseTaskGrid);
            AddComments = new RelayCommand(AddCommentsToTask);
            UpdateTask = new RelayCommand(UpdateTaskDto);
            ShowTasksInMainWindow();
        }
        private void CloseTaskGrid(object obj)
        {
            IsTaskVisible = false;
        }

        private void ShowInfoTask(object obj)
        {
            IsTaskVisible = true;
            SelectedTask.ShortName = obj as string;
            newTask = DtoTasksToModel.Converter(tasksRepository.ShowTask(SelectedTask.ShortName));
            SelectedColumn = newTask.Category;
        }

        private void AddTaskToDto(object obj)
        {
            if (Tasks.Count<1)
            {
                SelectedTask.Number = 0;
            }
            else
            {
                SelectedTask.Number = tasksRepository.GetLastNumberTask(SelectedProject.ID) + 1;
            }
            SelectedTask.ShortName = tasksRepository.GetShortNameTask(SelectedProject.ID);            
            CreatedTime = DateTime.Now;
            ModDate = DateTime.Now;
            Category = SelectedTask.Column;
            ProjectID = SelectedProject.ID;
            ShortNumber = $"{SelectedTask.ShortName}-{SelectedTask.Number}";
            CreatedByID = LoggedUser.ID;
            tasksRepository.AddTask(ConvertTaskToDTO.Transform(newTask));
            ShowTasksInMainWindow();
            HideGrid();
            ClearNewTask();
        }
       
        public void UpdateTaskDto(object obj)
        {
            tasksRepository.UpdateColumn(SelectedTask.ShortName, SelectedColumn, newTask.AssignedUser);
            ShowTasksInMainWindow();
            HideGrid();
            ShowTasksInMainWindow();
        }

        private void AddCommentsToTask(object obj)
        {
            message.ShortTaskName = SelectedTask.ShortName;
            message.UserName = LoggedUser.Login;
            message.Time = DateTime.Now;            
            commentsRepository.AddComment(message);

        }
        private void ShowGridWithTask(object obj)
        {
            SelectedTask.Column = obj.ToString();
            IsGridVisible = true;
            IsKanbanEnabled = false;
        }
        private void CancelAddTask(object obj)
        {
            HideGrid();
        }
        private void ShowTasksInMainWindow()
        {
            Tasks = DtoTasksToModel.Transform(tasksRepository.GetAllTasks(SelectedProject.ID));
        }
        private void ClearNewTask()
        {
            Name = String.Empty;
            Description = String.Empty;
            AssignedUser = String.Empty;
            Tag = String.Empty;
        }
        private void HideGrid()
        {
            IsGridVisible = false;
            IsKanbanEnabled = true;
            IsTaskVisible=false;
        }

    }
}
