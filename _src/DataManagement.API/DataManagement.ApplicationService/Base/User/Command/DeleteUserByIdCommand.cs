using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.ApplicationService.Command
{
    public class DeleteUserByIdCommand : ICommand<bool>
    {
        public int UserId { get; set; }
    }
}
