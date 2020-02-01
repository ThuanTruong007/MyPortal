using DataManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.ApplicationService.Command
{
    public class DeleteUserByIdHandler : ICommandHandler<DeleteUserByIdCommand, bool>
    {
        readonly IUserRepository _userRepository;
        public DeleteUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> HandlerAsync(DeleteUserByIdCommand tcommand)
        {
            return  await _userRepository.DeleteUser(tcommand.UserId);
        }
    }
}
