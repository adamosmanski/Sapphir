using SapphirApp.Data.Models;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapphirApp.Converter
{
    public static class UserConverter
    {
        public static UserDataChanged GetInfoUserConverter(User UserDTO)
        {
            var user = new UserDataChanged();
            user.PermissionLevel = UserDTO.LevelAccess;
            user.PhoneNumber = UserDTO.PhoneNumber;
            user.Surname = UserDTO.Surname;
            user.Name = UserDTO.FirstName;
            user.SecondName = UserDTO.SecondName;
            user.Mail = UserDTO.Mail;
            return user;
        }
        public static User ConvertChangedUserToDTO(UserDataChanged UserChanged)
        {
            var user = new User();
            user.LevelAccess = UserChanged.PermissionLevel;
            user.PhoneNumber = UserChanged.PhoneNumber;
            user.Surname = UserChanged.Surname;
            user.FirstName = UserChanged.Name;
            user.SecondName = UserChanged.SecondName;
            user.Mail = UserChanged.Mail;
            user.Password = UserChanged.Password;
            return user;
        }
        public static User ConvertAddUser(AddUser User)
        {
            var user = new User();
            user.LevelAccess = User.LevelPermission;
            user.PhoneNumber = User.Phone;
            user.Surname = User.Surname;
            user.FirstName = User.Name;
            user.SecondName = User.SecondName;
            user.Mail = User.Email;
            user.ModUser = User.ModUser;
            user.Password = User.Password;
            user.ModDate = User.ModDate;
            user.FullName= User.FullName;
            user.Login = User.Login;

            return user;
        }
    }
}