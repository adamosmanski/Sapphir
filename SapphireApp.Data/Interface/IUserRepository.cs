using SapphirApp.Data.Models;

namespace SapphirApp.Data.Interface
{
    public interface IUserRepository
    {
        bool IsUserExist(string InputPassword, string Login);
        string GetAccesUser(string Login);
        void UpdatePassword(string Password, string Login);
    }
}