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

        public UserDAO()
        {
            if (dbContext == null)
            {
                dbContext = new SalesManagementContext();
            }
        }

        public static UserDAO getInstance()
        {
            if (instance == null)
            {
                instance = new UserDAO();
            }
            return instance;
        }
        public User GetUserByUserId(string id)
        {
            return dbContext.Users.FirstOrDefault(m => m.UserId.Equals(id));
        }        
    }
}
