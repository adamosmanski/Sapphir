using Microsoft.IdentityModel.Tokens;
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
    public class AddingUserVM : ObserveObject
    {
        public AddingUserVM() 
        {
            Repository = new UserRepository(context);
            UsersList = UserListConverter.Converter(Repository.GetAll());
            AddUserToDTO = new RelayCommand(Add);
        }
        #region Variables
        private SapphirApplicationContext context = new SapphirApplicationContext();
        private UserRepository Repository;
        private AddUser _addUser = new AddUser();
        public AddUser addUser
        {
            get => _addUser;
            set
            {
                _addUser = value;
                OnPropertyChanged(nameof(addUser));
            }
        }
        private List<UsersLists> _usersList = new List<UsersLists>();
        public List<UsersLists> UsersList
        {
            get => _usersList;
            set
            {
                _usersList= value;
                OnPropertyChanged(nameof(UsersList));
            }
        }
        #endregion
        #region Commands
        public ICommand AddUserToDTO { get; }
        #endregion
        #region Methods
        private void Add(object obj)
        {
            Repository.InsertUsers(UserConverter.ConvertAddUser(addUser), LoggedUser.Login);
            UsersList = UserListConverter.Converter(Repository.GetAll());
        }

        #endregion
    }
}
