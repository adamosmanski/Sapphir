using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using SapphirApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SapphirApp.ViewModels
{
    public class MainVM : ObserveObject
    {
        #region Variables
        private ObserveObject _currentVM;
        ProjectRepository ProjectDTO;
        private VisibilityByPermission _visibility = new VisibilityByPermission();
        public VisibilityByPermission Visibile
        {
            get=> _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged(nameof(Visibile));
            }
        }
        ArchivesContext archives = new ArchivesContext();
        SapphirApplicationContext context = new SapphirApplicationContext();
        ArchivesContext contextArchive = new ArchivesContext();
        ArchRepository archRepository;
        public static List<ProjectModel> ListBoxSource { get; set; }        
        public ObserveObject CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM = value;
                OnPropertyChanged(nameof(CurrentVM));
            }
        }
        private ProjectModel _selectedBoard = new ProjectModel();
        public ProjectModel SelectedBoard
        {
            get => _selectedBoard;
            set
            {
                _selectedBoard = value;
                OnPropertyChanged(nameof(SelectedBoard));
            }
        }
        private bool _visibilityListBox;
        public bool VisibilityListBox
        {
            get => _visibilityListBox;
            set
            {
                _visibilityListBox = value;
                OnPropertyChanged(nameof(VisibilityListBox));
            }
        }
        #endregion
        #region
        private List<MessagesInTask> messagesInTasks = new List<MessagesInTask>();
        public List<MessagesInTask> MessagesInTasks
        {
            get => messagesInTasks;
            set
            {
                messagesInTasks = value;
                OnPropertyChanged(nameof(MessagesInTasks));
            }
        }

        private List<TaskProject> taskProjects = new List<TaskProject>();
        public List<TaskProject> TaskProjects
        {
            get => taskProjects;
            set
            {
                taskProjects = value;
                OnPropertyChanged(nameof(TaskProjects));
            }
        }      
        #endregion
        public MainVM()
        {
            archRepository = new ArchRepository(contextArchive);
            SelectedBoard = _selectedBoard;
            VisibilityListBox = false;
            ProjectDTO = new ProjectRepository(context);
            CurrentVM = _currentVM;
            CmdChangePassword = new RelayCommand(ChangePassword);
            CmdOpenChat = new RelayCommand(OpenChat);
            CmdNewProject = new RelayCommand(CreateNewProject);
            ListBoxSource = ConverterProjectModelToProjectDTO.Transform(ProjectDTO.GetAllProject());
            CmdOpenKanban = new RelayCommand(OpenKanbanBoard);
            CmdOpenBoard = new RelayCommand(OpenBoard);
            CmdOpenMyTask = new RelayCommand(OpenMyTask);
            DeleteBoardCommand = new RelayCommand(ArchiveBoard);
            SetPermission();
        }
        #region Command
        public ICommand CmdChangePassword { get; }
        public ICommand CmdOpenChat { get; }
        public ICommand CmdNewProject { get; }
        public ICommand CmdOpenBoard { get; }
        public ICommand CmdOpenKanban { get; }
        public ICommand CmdOpenMyTask { get; }
        public ICommand DeleteBoardCommand { get; }
        #endregion
        #region Methods
        private void OpenMyTask(object obj)
        {
            VisibilityListBox = false;
            CurrentVM = new MyTaskVM();
        }
        private void CreateNewProject(object obj)
        {
            NewProjectPopUp window = new NewProjectPopUp();
            window.DataContext = new NewProjectVM();
            window.Show();
        }
        private void OpenChat(object obj)
        {
            CurrentVM = new ChatVM();
        }
        private void ChangePassword(object obj)
        {
            ChangingPassword window = new ChangingPassword();
            window.DataContext = new ChangePasswordVM();
            window.Show();
        }
        private void OpenBoard(object obj)
        {
            VisibilityListBox = true;
            CurrentVM = null;
        }
        private void OpenKanbanBoard(object obj)
        {
            SelectedProject.Name = SelectedBoard.ShortNumber;
            SelectedProject.ID = SelectedBoard.Id;
            if (SelectedProject.ID == SelectedBoard.Id)
            {
                VisibilityListBox = false;
                CurrentVM = new KanbanBoardVM();
            }
            else if (SelectedProject.ID < 0)
            {
                NotifyPopUp window = new NotifyPopUp();
                window.Show();
                window.DataContext = new NotifyPopUpVM("Nie odnaleziono projektu");
            }            
        }
        private void ArchiveBoard(object obj)
        {
            archRepository.InsertProject(ConverterProjectModelToProjectDTO.TransformModel(SelectedBoard));
        }
        private void SetPermission()
        {
            var PermissionLevel = int.Parse(LoggedUser.LevelAcces);
            if (PermissionLevel >= 10)
            {
                Visibile.IsAddProjectVisible = true;
            }
            else if(PermissionLevel >= 5)
            {
                Visibile.IsArchivalProjectsVisible = true;
            }
        }
#endregion
    }
}