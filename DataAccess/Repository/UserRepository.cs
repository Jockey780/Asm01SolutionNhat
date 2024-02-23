using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository: IUserRepository
    {
        public User GetUserByUsernameAndPassword(string username, string password)=>UserDAO.Instance.GetUserByUsernameAndPassword(username, password);
        public List<User> GetUsers()=>UserDAO.Instance.GetUsers();
    }
}
