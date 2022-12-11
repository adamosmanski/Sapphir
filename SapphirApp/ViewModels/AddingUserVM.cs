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
using bcrypt = BCrypt.Net;

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
            addUser.FullName = FullName();
            addUser.Login = LoginUser();
            addUser.Password = bcrypt.BCrypt.HashPassword(Password());
            addUser.LastLoginTime = DateTime.Now;
            addUser.ModDate = DateTime.Now;
            addUser.ModUser = LoggedUser.ID;
            Repository.InsertUsers(UserConverter.ConvertAddUser(addUser), LoggedUser.Login);
            UsersList = UserListConverter.Converter(Repository.GetAll());
        }
        private string LoginUser()
        {
            var result = $"{addUser.Name.Substring(0, 1)}{addUser.Surname}";
            return result;
        }
        private string FullName()
        {
            var result = $"{addUser.Name} {addUser.SecondName} {addUser.Surname}";
            return result;
        }
        private string Password()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            const int passwordLength = 16;
            const int minUpperCaseChars = 2;
            const int minLowerCaseChars = 2;
            const int minNumericChars = 2;
            const int minSpecialChars = 2;

            StringBuilder password = new StringBuilder();
            Random random = new Random();
            int upperCaseChars = 0;
            int lowerCaseChars = 0;
            int numericChars = 0;
            int specialChars = 0;

            while (password.Length < passwordLength)
            {
                int index = random.Next(validChars.Length);
                char c = validChars[index];

                if (char.IsUpper(c))
                {
                    upperCaseChars++;
                }
                else if (char.IsLower(c))
                {
                    lowerCaseChars++;
                }
                else if (char.IsNumber(c))
                {
                    numericChars++;
                }
                else
                {
                    specialChars++;
                }
                password.Append(c);
                if (upperCaseChars >= minUpperCaseChars && lowerCaseChars >= minLowerCaseChars &&
                    numericChars >= minNumericChars && specialChars >= minSpecialChars)
                {
                    break;
                }
            }
            return password.ToString();
        }
        #endregion
    }
}
