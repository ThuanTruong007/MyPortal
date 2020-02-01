using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManagement.Business
{
    public class UserManager : IUserManager
    {
        IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }
        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }
        public async Task<IList<User>> GetAllUser()
        {
           return await _userRepository.GetAllUser();
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetUserById(userId);
        }
        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}