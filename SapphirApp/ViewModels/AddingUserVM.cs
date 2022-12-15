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
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SapphirApp.Data.Models;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Net.Mail;

namespace SapphirApp.ViewModels
{
    public class AddingUserVM : ObserveObject, IDataErrorInfo
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
        public string Name
        {
            get => _addUser.Name;
            set
            {
                _addUser.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string LevelPerm
        {
            get => _addUser.LevelPermission;
            set
            {
                _addUser.LevelPermission = value;
                OnPropertyChanged(nameof(LevelPerm));
            }
        }
        public string fullName
        {
            get => _addUser.FullName;
            set
            {
                _addUser.FullName = value;
                OnPropertyChanged(nameof(fullName));
            }
        }
        public string Login
        {
            get => _addUser.Login;
            set
            {
                _addUser.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _addUser.Password;
            set
            {
                _addUser.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public DateTime LastLoginDate
        {
            get => _addUser.LastLoginTime;
            set
            {
                _addUser.LastLoginTime = value;
                OnPropertyChanged(nameof(LastLoginDate));
            }
        }
        public DateTime ModDate
        {
            get => _addUser.ModDate;
            set
            {
                _addUser.ModDate = value;
                OnPropertyChanged(nameof(ModDate));
            }
        }
        public int ModUser
        {
            get => _addUser.ModUser;
            set
            {
                _addUser.ModUser = value;
                OnPropertyChanged(nameof(ModUser));
            }

        }
        public string Surname
        {
            get=>_addUser.Surname;
            set
            {
                _addUser.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string SecondName
        {
            get => _addUser.SecondName;
            set
            {
                _addUser.SecondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        public string Email
        {
            get => _addUser.Email;
            set
            {
                _addUser.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Phone
        {
            get => _addUser.Phone;
            set
            {
                _addUser.Phone = value;
                OnPropertyChanged(nameof(Phone));
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
            fullName = FullName();
            Login = LoginUser();
            Password = bcrypt.BCrypt.HashPassword(GeneratePassword());
            LastLoginDate = DateTime.Now;
            ModDate = DateTime.Now;
            ModUser = LoggedUser.ID;
            Repository.InsertUsers(UserConverter.ConvertAddUser(_addUser), LoggedUser.Login);
            UsersList = UserListConverter.Converter(Repository.GetAll());
            //MessageBox.Show(Error);
        }
        private string LoginUser()
        {
            var result = $"{Name.Substring(0, 1)}{Surname}";
            return result;
        }
        private string FullName()
        {
            var result = $"{Name} {SecondName} {Surname}";
            return result;
        }
        private string GeneratePassword()
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
        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                var patternNumber = "^[0-9]*$";
                Regex regex = new Regex(patternNumber);
                string result = null;
                if (columnName == nameof(LevelPerm) || columnName == nameof(Phone))
                {
 
                    if (string.IsNullOrEmpty(_addUser.LevelPermission) || !regex.IsMatch(_addUser.LevelPermission))
                    {
                        result = "To pole musi zawierać cyfyr od 1-10.";
                    }
                }
                if (columnName == nameof(Phone))
                {
                    if (string.IsNullOrEmpty(_addUser.Phone) || !regex.IsMatch(_addUser.Phone) || _addUser.Phone.Length > 10)
                    {
                        result = "To pole musi zawierać do 9 cyfr.";
                    }
                }
                if (columnName == nameof(Email)) 
                { 
                    if(string.IsNullOrWhiteSpace(_addUser.Email) || !IsValid(_addUser.Email))
                    {
                        result = "Nie prawidłowy format adresu email.";
                    }
                }
                if(columnName == nameof(Name) || columnName == nameof(SecondName) || columnName == nameof(Surname))
                {
                    if(string.IsNullOrEmpty(_addUser.Name) || regex.IsMatch(_addUser.Name))
                    {
                        result = "To pole zawiera nie dozwolone znaki.";
                    }
                }
                if (columnName == nameof(SecondName))
                {
                    if (string.IsNullOrEmpty(_addUser.SecondName) || regex.IsMatch(_addUser.SecondName))
                    {
                        result = "To pole zawiera nie dozwolone znaki.";
                    }
                }
                if (columnName == nameof(Surname))
                {
                    if (string.IsNullOrEmpty(_addUser.Surname) || regex.IsMatch(_addUser.Surname))
                    {
                        result = "To pole zawiera nie dozwolone znaki.";
                    }
                }
                return result;
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion
    }
}
