using SapphirApp.Core;
using Proj = SapphirApp.Data.Models;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
using SapphirApp.Converter;

namespace SapphirApp.ViewModels
{
    public class NewProjectVM : ObserveObject
    {
        #region Variables
        ProjectRepository ProjectDTO;
        SapphirApplicationContext context = new SapphirApplicationContext();
        private ProjectModel _project = new ProjectModel();
        private bool _isVisible = true;
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public ProjectModel Project
        {
            get => _project;
            set
            {
                _project = value;
                OnPropertyChanged(nameof(Project));
            }
        }
        public ICommand CmdClose { get; }
        public ICommand CmdAdd { get; }
        #endregion
        public NewProjectVM()
        {
            ProjectDTO = new ProjectRepository(context);
            IsVisible = _isVisible;
            CmdClose = new RelayCommand(Close);
            CmdAdd = new RelayCommand(Add);
        }

        private void Add(object obj)
        {
            Project.ShortNumber = Project.Name.Substring(0, 3);
            ProjectDTO.AddProject(Project.Name, Project.Description, LoggedUser.ID, Project.ShortNumber);
            MainVM.ListBoxSource = ConverterProjectModelToProjectDTO.Transform(ProjectDTO.GetAllProject());
            IsVisible = false;
        }
        private void Close(object obj)
        {
            IsVisible = false;
        }
    }
}