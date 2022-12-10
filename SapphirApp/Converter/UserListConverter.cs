using SapphirApp.Data.Models;
using SapphirApp.Models;
using System.Collections.Generic;

namespace SapphirApp.Converter
{
    public static class UserListConverter
    {
        public static List<UsersLists> Converter(List<UsersList> collection)
        {
            var result = new List<UsersLists>();
            foreach (var item in collection)
            {
                var User = new UsersLists();
                User.Surname = item.Surname;
                User.PhoneNumber = item.PhoneNumber;
                User.FirstName = item.FirstName;
                User.SecondName = item.SecondName;
                User.LevelAccess = item.LevelAccess;
                User.Mail = item.Mail;
                result.Add(User);
            }
            return result;
        }
    }
}