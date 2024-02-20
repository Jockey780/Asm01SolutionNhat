using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        public UserService() 
        {
            userRepository = new UserRepository();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return userRepository.GetUserByUsernameAndPassword(username, password);
        }
    }
}
