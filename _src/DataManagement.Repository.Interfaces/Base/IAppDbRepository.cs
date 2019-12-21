using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.Repository.Interfaces
{
    public interface IAppDbRepository<T>:IRepository<T> where T:class
    {
    }
}
