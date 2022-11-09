using SapphirApp.Core;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SapphirApp.ViewModels
{
    public class NewProjectVM : ObserveObject
    {
        public NewProjectVM()
        {
            IsVisible = _isVisible;
            CmdClose = new RelayCommand(Close);
        }
        private Project _project = new Project();
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
        public Project Project
        {
            get => _project;
            set
            {
                _project = value;
                OnPropertyChanged(nameof(Project));
            }
        }
        public ObservableCollection<Project> Projects { get; set; }

        public ICommand CmdClose { get; }
        private void Close(object obj)
        {
            IsVisible = false;
        }
    }
}
