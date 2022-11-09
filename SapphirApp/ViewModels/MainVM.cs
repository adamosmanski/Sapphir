using SapphirApp.Core;
using SapphirApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SapphirApp.ViewModels
{
    public class MainVM : ObserveObject
    {
        private ObserveObject _currentVM;

        public ObserveObject CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM = value;
                OnPropertyChanged(nameof(CurrentVM));
            }
        }
        public MainVM()
        {
            CurrentVM = _currentVM;
            CmdChangePassword = new RelayCommand(ChangePassword);
            CmdOpenChat = new RelayCommand(OpenChat);
            CmdKanbanBoard = new RelayCommand(OpenKanabnBoard);
            CmdNewProject = new RelayCommand(CreateNewProject);
        }
        public ICommand CmdChangePassword { get; }
        public ICommand CmdOpenChat { get; }
        public ICommand CmdKanbanBoard { get; }
        public ICommand CmdNewProject { get; }
        public void CreateNewProject(object obj)
        {
            NewProjectPopUp window = new NewProjectPopUp();
            window.DataContext = new NewProjectVM();
            window.Show();
        }
        public void OpenKanabnBoard(object obj)
        {
            //CurrentVM = new KanbanBoardVM();
        }
        public void OpenChat(object obj)
        {
            CurrentVM = new ChatVM();
        }
        public void ChangePassword(object obj)
        {
            ChangingPassword window = new ChangingPassword();
            window.DataContext = new ChangePasswordVM();
            window.Show();
        }


    }
}
