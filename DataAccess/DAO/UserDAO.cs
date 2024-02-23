using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private readonly SalesManagementContext dbContext = null;

        private UserDAO()
        {
            dbContext = new SalesManagementContext();
        }

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = dbContext.Users.SingleOrDefault(u=>u.UserName == username && u.Password == password);

            if (user != null)
            {
                User mappedUser = new User
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    UserRole = user.UserRole
                };
                return mappedUser;
            }
            return user;
        }
        public List<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }
     }
}
