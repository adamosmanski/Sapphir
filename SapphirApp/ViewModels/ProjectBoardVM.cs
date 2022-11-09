using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SapphirApp.ViewModels
{
    public class ProjectBoardVM : ObserveObject
    {
        ProjectRepository ProjectDTO;
        SapphirApplicationContext context = new SapphirApplicationContext();
        public ObservableCollection<Project> ListBoxSource { get; set; }

        private Project _selectedBoard = new Project();
        public Project SelectedBoard
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
            ListBoxSource = new ObservableCollection<Project>((IEnumerable<Project>)ProjectDTO.GetAll());
        }


    }
}
