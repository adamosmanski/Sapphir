using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bcrypt = BCrypt.Net;
using SapphirApp.Data.Context;
using SapphirApp.Data.Interface;
using SapphirApp.Data.Models;

namespace SapphirApp.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private SapphirApplicationContext context;
        public UserRepository(SapphirApplicationContext _context)
        {
            this.context = _context;
        }
        public bool IsUserExist(string InputPassword, string Login)
        {
            var userLogin = context.Users.SingleOrDefault(x => x.Login == Login);
            if (userLogin == null || !bcrypt.BCrypt.Verify(InputPassword, userLogin.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string GetAccesUser(string Login)
        {
            var Access = context.Users.Where(u => u.Login == Login).Select(x => x.LevelAccess).SingleOrDefault();
            return Access;
        }

        public void UpdatePassword(string Password, string Login)
        {
            using (var context = new SapphirApplicationContext())
            {
                var entity = context.Users.FirstOrDefault(x => x.Login == Login);
                entity.Password = bcrypt.BCrypt.HashPassword(Password);
                context.Update(entity);
                context.SaveChanges();
            }
        }
        public int GetID(string Login)
        {
            var GetID = context.Users.Where(x => x.Login == Login).Select(x => x.Id).SingleOrDefault();
            return GetID;
        }

        public IEnumerable<string> GetAllLogins()
        {
            var GetLogins = context.Users.Select(x => x.Login).ToList();
            return GetLogins;
        }
        public bool isExist(string AssignedUser)
        {
            var isExist = context.Users.Where(u => u.Login == AssignedUser).SingleOrDefault();
            if(isExist == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void UpdateLastLogin(string login)
        {
            using(var context = new SapphirApplicationContext())
            {
                var result = context.Users.Where(x => x.Login == login).SingleOrDefault();
                if (result != null)
                {
                    result.LastLoginDate= DateTime.Now;
                    context.Users.Update(result);
                    context.SaveChanges();
                }
            }
        }
        public List<UsersList> GetAll()
        {
            var result = context.UsersLists.ToList();
            return result;
        }

        public User GetUser(string FullName)
        {
            return context.Users.Where(x => x.FullName == FullName).FirstOrDefault();
        }
        public void UpdateExistingUser(string FullName, User User)
        {
            using(var context = new SapphirApplicationContext())
            {
                var result = context.Users.Where(x=>x.FullName == FullName).FirstOrDefault();
                if (result != null)
                {
                    result.LevelAccess = User.LevelAccess;
                    result.PhoneNumber = User.PhoneNumber;
                    result.Surname = User.Surname;
                    result.FirstName = User.FirstName;
                    result.SecondName = User.SecondName;
                    result.Mail = User.Mail;
                    result.FullName = $"{User.FirstName} {User.SecondName} {User.Surname}";
                    context.Users.Update(result);
                    context.SaveChanges();
                }
            }
        }

        public void InsertUsers(User User, string Login)
        {
            using (var context = new SapphirApplicationContext())
            {
                var newUser = new User
                {
                    ModUser = GetID(Login),
                    ModDate = DateTime.Now,
                    FirstName = User.FirstName,
                    SecondName = User.SecondName,
                    Surname = User.Surname,
                    FullName = User.FullName,
                    Mail = User.Mail,
                    Password = User.Password,
                    LevelAccess = User.LevelAccess,
                    LastLoginDate = DateTime.Now
                };
            }
        }
    }
}
