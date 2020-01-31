using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.ApplicationService.Command
{
    public interface ICommandHandler<Tcommand, Tresult> where Tcommand : ICommand<Tresult>
    {
        Task<Tresult> HandleAsync(Tcommand tcommand);
    }
}

