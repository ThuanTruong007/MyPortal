using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.ApplicationService.Query
{
    public class UserByIdHandler : IQueryHandler<UserByIdQuery,User>
    {
        readonly IUserRepository _userRepository;
        public UserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> HandlerAsync(UserByIdQuery query)
        {
            return await _userRepository.GetUserById(query.UserId);
        }
    }
}
