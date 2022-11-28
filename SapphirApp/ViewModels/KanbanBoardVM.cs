using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
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

namespace SapphirApp.ViewModels
{
    public class KanbanBoardVM : ObserveObject
    {
        #region Variables
        SapphirApplicationContext context = new SapphirApplicationContext();
        TaskRepository tasksRepository;
        private bool _IsGridVisible = false;
        private bool _isKanbanEnabled = true;
        private NewTask _newTask = new NewTask();
        public NewTask newTask
        {
            get => _newTask;
            set
            {
                _newTask = value;
                OnPropertyChanged(nameof(newTask));
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
            "Nieprzypisane", "Backlog","To Do", "W trakcie","W trakcie TST", "Review", "Gotowe"
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
        public ICommand ShowGridToAddTask { get; }
        public ICommand CancelTask { get; }
        public ICommand AddTask { get; }
        public ICommand TaskShow { get; set; }
        #endregion
        public KanbanBoardVM()
        {
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
            tasksRepository = new TaskRepository(context);            
            ShowGridToAddTask = new RelayCommand(ShowGridWithTask);
            CancelTask = new RelayCommand(CancelAddTask);
            AddTask = new RelayCommand(AddTaskToDto);
            TaskShow = new RelayCommand(ShowInfoTask);
            UpdateTasks();
        }

        private void ShowInfoTask(object obj)
        {
            IsTaskVisible = true;
            var shortName = obj as string;
            newTask = DtoTasksToModel.Converter(tasksRepository.ShowTask(shortName));
            SelectedColumn = newTask.Category;
        }

        private void AddTaskToDto(object obj)
        {
            SelectedTask.ShortName = tasksRepository.GetShortNameTask(SelectedProject.ID);
            SelectedTask.Number = tasksRepository.GetLastNumberTask(SelectedProject.ID)+1;
            CreatedTime = DateTime.Now;
            ModDate = DateTime.Now;
            Category = SelectedTask.Column;
            ProjectID = SelectedProject.ID;
            ShortNumber = $"{SelectedTask.ShortName}-{SelectedTask.Number}";
            CreatedByID = LoggedUser.ID;
            tasksRepository.AddTask(ConvertTaskToDTO.Transform(newTask));
            UpdateTasks();
            HideGrid();
        }
        public void UpdateTask()
        {
            var x1 = SelectedProject.Number;
            var x2 = SelectedTask.ID;
            var x3 = SelectedTask.Column;
            var x4 = SelectedTask.ShortName;
            var x5 = SelectedTask.Title;
            Debug.Write($@"{x1} + {x2}+{x3}+{x4}+{x5}");
            //tasksRepository.UpdateColumn();
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
        private void UpdateTasks()
        {
            Tasks = DtoTasksToModel.Transform(tasksRepository.GetAllTasks(SelectedProject.ID));
        }
        private void HideGrid()
        {
            IsGridVisible = false;
            IsKanbanEnabled = true;
            IsTaskVisible=false;
        }

    }
}
