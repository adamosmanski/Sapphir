using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        #endregion
        public UsersVM()
        {
            WidthGrid = new GridLength(0);
            Repository = new UserRepository(context);
            UsersLists = UserListConverter.Converter(Repository.GetAll());
            EditUser = new RelayCommand(EditSelectUser);
            UpdateDataUser = new RelayCommand(UpdateUser);
        }
        #region Methods
        private void EditSelectUser(object obj)
        {
            WidthGrid = new GridLength(500);
        }
        private void UpdateUser(object obj)
        {

        }
        #endregion
    }
}
