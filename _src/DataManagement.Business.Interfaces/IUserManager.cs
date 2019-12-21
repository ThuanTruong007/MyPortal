using DataManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManagement.Business.Interfaces
{
    public interface IUserManager
    {
        Task<int> AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
        Task<IList<User>> GetAllUser();
        Task<User> GetUserById(int userId);
    }
}