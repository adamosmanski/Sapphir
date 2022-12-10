using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SapphirApp.Core;
using System.Windows.Input;
using System.Windows;
using SapphirApp.Views;
using SapphirApp.Data.Repository;
using SapphirApp.Data.Context;

namespace SapphirApp.ViewModels
{
    public class LoginWindowVM : ObserveObject
    {
        #region Variables
        UserRepository UserRepository;
        SapphirApplicationContext context = new SapphirApplicationContext();
        private bool _isVisible = true;
        public bool isVisible
        {
            get => this._isVisible;
            set
            {
                this._isVisible = value;
                OnPropertyChanged(nameof(isVisible));
            }
        }
        public string LoginName
        {
            get => LoggedUser.Login;
            set
            {
                LoggedUser.Login = value;
                OnPropertyChanged(nameof(LoginName));
            }
        }
        public string Password
        {
            get => LoggedUser.Password;
            set
            {
                LoggedUser.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string LevelAccess
        {
            get => LoggedUser.LevelAcces;
            set
            {
                LoggedUser.LevelAcces = value;
                OnPropertyChanged(nameof(LevelAccess));
            }
        }
        #endregion;
        public LoginWindowVM()
        {
            UserRepository = new UserRepository(context);
            LoginName = LoggedUser.Login;
            Password = LoggedUser.Password;
            LevelAccess = LoggedUser.LevelAcces;
            CmdSubmitLogin = new RelayCommand(SubmitLogin, CanExecuteSubmitLogin);
            isVisible = _isVisible;
        }
        #region Commands
        public ICommand CmdSubmitLogin { get; }
        #endregion
        #region Methods
        private bool CanExecuteSubmitLogin(object obj)
        {
            bool Can = false;
            if(Password != null && Password.Length>4 && LoginName != null && LoginName.Length>3)
                Can = true;
            return Can;
        }
        private void SubmitLogin(object obj)
        {
            if (UserRepository.IsUserExist(Password, LoginName) == true)
            {
                LoggedUser.Login = LoginName;
                LoggedUser.Password = Password;
                LoggedUser.ID = UserRepository.GetID(LoggedUser.Login);
                LoggedUser.LevelAcces = UserRepository.GetAccesUser(LoginName);
                UserRepository.UpdateLastLogin(LoggedUser.Login);
                isVisible = false;
            }
            else if (UserRepository.IsUserExist(Password, LoginName) != true)
            {
                NotifyPopUp window = new NotifyPopUp();
                window.DataContext = new NotifyPopUpVM("Użytkownik nie istnieje.");
                window.ShowDialog();
                Password = String.Empty;
                LoginName = String.Empty;
            }
        }
        #endregion
    }
}