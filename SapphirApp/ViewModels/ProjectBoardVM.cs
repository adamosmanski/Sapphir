using Microsoft.VisualBasic;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Models;
using SapphirApp.Data.Repository;
using SapphirApp.Converter;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using SapphirApp.Views;

namespace SapphirApp.ViewModels
{
    public class ProjectBoardVM : ObserveObject
    {
        ProjectRepository ProjectDTO;
        SapphirApplicationContext context = new SapphirApplicationContext();
        public List<ProjectModel> ListBoxSource { get; set; }
        public ProjectBoardView window;

        private ProjectModel _selectedBoard = new ProjectModel();
        public ProjectModel SelectedBoard
        {
            get { return _selectedBoard; }
            set
            {
                _selectedBoard = value;
                OnPropertyChanged(nameof(SelectedBoard));
            }
        }

        public ProjectBoardVM()
        {
            ProjectDTO = new ProjectRepository(context);
            OpenBoard = new RelayCommand(OpenExistBoard);
            ListBoxSource = ConverterProjectModelToProjectDTO.Transform(ProjectDTO.GetAllProject());
        }

        public ICommand OpenBoard { get; }
        public ICommand DeleteBoard { get; }
        private void OpenExistBoard(object obj)
        {
                   
        }
    }
}
