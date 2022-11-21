using SapphirApp.Data.Models;
using System.Collections.Generic;

namespace SapphirApp.Data.Interface
{
    public interface IUserRepository
    {
        bool IsUserExist(string InputPassword, string Login);
        string GetAccesUser(string Login);
        void UpdatePassword(string Password, string Login);
        IEnumerable<string> GetAllLogins();
    }
}