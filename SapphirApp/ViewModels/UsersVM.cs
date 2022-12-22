using BCrypt.Net;
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
using System.Windows.Input;
using bcrypt = BCrypt.Net;

namespace SapphirApp.ViewModels
{
    public class UsersVM : ObserveObject
    {
        #region Variables
        private SapphirApplicationContext context = new SapphirApplicationContext();
        private UserRepository Repository;
        private List<UsersLists> _usersList = new List<UsersLists>();
        private UsersLists _user = new UsersLists();
        private GridLength _widthGrid = new GridLength(0);
        private UserDataChanged _userDataChanged = new UserDataChanged();
        public UserDataChanged UserChanged
        {
            get => _userDataChanged;
            set
            {
                _userDataChanged= value;
                OnPropertyChanged(nameof(UserChanged));
            }
        }
        public UsersLists User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public List<UsersLists> UsersLists
        {
            get=> _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersLists));
            }
        }
        public GridLength WidthGrid
        {
            get => _widthGrid;
            set
            {
                _widthGrid = value;
                OnPropertyChanged(nameof(WidthGrid));
            }
        }
        #endregion
        #region Commmands
        public ICommand EditUser { get; }
        public ICommand UpdateDataUser { get; }
        public ICommand DeleteUser { get; }
        public ICommand ChangePassword { get; }
        #endregion
        public UsersVM()
        {
            WidthGrid = new GridLength(0);
            Repository = new UserRepository(context);
            UsersLists = UserListConverter.Converter(Repository.GetAll());
            EditUser = new RelayCommand(EditSelectUser);
            UpdateDataUser = new RelayCommand(UpdateUser);
            DeleteUser = new RelayCommand(DeleteSelectedUser);
            ChangePassword = new RelayCommand(ChangePasswordSelectedUser);
        }
        #region Methods
        private void EditSelectUser(object obj)
        {
            try
            {
                WidthGrid = new GridLength(500);
                UserChanged = UserConverter.GetInfoUserConverter(Repository.GetUser(User.FullName));
            }
            catch (Exception ex)
            {
                NotifyPopUpVM viewModel = new NotifyPopUpVM("Zaznacz odpowiedniego użytkownika aby edytować!");
                NotifyPopUp window = new NotifyPopUp();
                window.DataContext = viewModel;
                window.Show();
            }
        }
        private void UpdateUser(object obj)
        {
            Repository.UpdateExistingUser(User.FullName, UserConverter.ConvertChangedUserToDTO(UserChanged));
            UsersLists = UserListConverter.Converter(Repository.GetAll());
        }

        private void DeleteSelectedUser(object obj)
        {
            try
            {
                Repository.DeleteUsers(User.FullName);
                UsersLists = UserListConverter.Converter(Repository.GetAll());
            }
            catch (Exception ex)
            {
                NotifyPopUpVM viewModel = new NotifyPopUpVM("Zaznacz odpowiedniego użytkownika aby skasować!");
                NotifyPopUp window = new NotifyPopUp();
                window.DataContext = viewModel;
                window.Show();
            }
        }
        private void ChangePasswordSelectedUser(object obj) 
        {
            var uniquePassword = UniquePassword.GeneratePassword();
            var encryptedPassword = bcrypt.BCrypt.HashPassword(uniquePassword);
            try
            {
                NotifyPopUpVM viewModel = new NotifyPopUpVM($"Przekaż hasło użytkownikowi:\n{uniquePassword}");
                NotifyPopUp window = new NotifyPopUp();
                window.DataContext = viewModel;
                window.Show();

                UserChanged.Password = encryptedPassword;
                Repository.UpdateExistingUser(User.FullName, UserConverter.ConvertChangedUserToDTO(UserChanged));
                UsersLists = UserListConverter.Converter(Repository.GetAll());
            }
            catch(Exception ex)
            {
                NotifyPopUpVM viewModel = new NotifyPopUpVM("Nie udało się zaktualizować hasła.");
                NotifyPopUp window = new NotifyPopUp();
                window.DataContext = viewModel;
                window.Show();
            }
        }
        #endregion
    }
}