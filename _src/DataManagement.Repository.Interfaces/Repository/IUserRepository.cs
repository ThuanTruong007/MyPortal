using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataManagement.Entities;

namespace DataManagement.Repository.Interfaces
{
    public interface IUserRepository 
    {  
        Task<int> AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
        Task<IList<User>> GetAllUser();
        Task<User> GetUserById(int userId);
    } 
}
