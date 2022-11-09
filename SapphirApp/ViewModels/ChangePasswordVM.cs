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
using System.Windows.Input;

namespace SapphirApp.ViewModels
{
    public class ChangePasswordVM : ObserveObject
    {
        ChangePassword password = new ChangePassword();
        UserRepository UserRepository;
        SapphirApplicationContext context = new SapphirApplicationContext();
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
        public string ConfirmNewPassword
        {
            get => password.ConfirmNewPassword;
            set
            {
                password.ConfirmNewPassword = value;
                OnPropertyChanged(nameof(ConfirmNewPassword));
            }
        }

        public string NewPassword
        { 
            get=> password.NewPassword;
            set
            {
                password.NewPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        public ChangePasswordVM()
        {
            UserRepository = new UserRepository(context);
            ConfirmNewPassword = password.ConfirmNewPassword;
            NewPassword = password.NewPassword;
            IsVisible = _isVisible;
            CmdChangePass = new RelayCommand(ChangePassword,CanChange);
            CmdCancel = new RelayCommand(Cancel);
        }

        private bool CanChange(object arg)
        {
            if(NewPassword == null && ConfirmNewPassword == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ICommand CmdChangePass { get; }
        public ICommand CmdCancel { get; }
        public void ChangePassword(object obj)
        {
            if(NewPassword == ConfirmNewPassword && NewPassword != String.Empty || ConfirmNewPassword == NewPassword && NewPassword != String.Empty)
            {
                UserRepository.UpdatePassword(NewPassword, LoggedUser.Login);
                IsVisible = false;
            }
            else
            {
                NotifyPopUp window = new NotifyPopUp();
                window.DataContext = new NotifyPopUpVM("Hasła są niezgodne.");
                window.ShowDialog();
            }
        }
        public void Cancel(object obj)
        {
            IsVisible = false;
        }
    }
}
