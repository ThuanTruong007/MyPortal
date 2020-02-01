using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.ApplicationService.Query
{
    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery,User>
    {
        readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> HandlerAsync(GetUserByIdQuery query)
        {
            return await _userRepository.GetUserById(query.UserId);
        }
    }
}
