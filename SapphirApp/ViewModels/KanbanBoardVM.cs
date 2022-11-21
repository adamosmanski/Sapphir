using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Models;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public NewTask newTask = new NewTask();
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
        public ICommand ShowGridToAddTask { get; }
        public ICommand CancelTask { get; }
        public ICommand AddTask { get; }
        #endregion
        public KanbanBoardVM()
        {
            IsGridVisible = _IsGridVisible;
            tasksRepository = new TaskRepository(context);
            UpdateTasks();
            ShowGridToAddTask = new RelayCommand(ShowGridWithTask);
            CancelTask = new RelayCommand(CancelAddTask);
            AddTask = new RelayCommand(AddTaskToDto);
        }

        private void AddTaskToDto(object obj)
        {
            SelectedProject.ShortName = tasksRepository.GetShortNameTask(SelectedProject.ID);
            SelectedProject.Number = tasksRepository.GetLastNumberTask(SelectedProject.ID)+1;
            CreatedTime = DateTime.Now;
            ModDate = DateTime.Now;
            Category = SelectedProject.SelectedColumn;
            ProjectID = SelectedProject.ID;
            ShortNumber = $"{SelectedProject.ShortName}-{ SelectedProject.Number}";
            CreatedByID = LoggedUser.ID;
            tasksRepository.AddTask(ConvertTaskToDTO.Transform(newTask));
            UpdateTasks();
            HideGrid();
        }
        private void ShowGridWithTask(object obj)
        {
            SelectedProject.SelectedColumn = obj.ToString();
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
        }
        
    }
}
