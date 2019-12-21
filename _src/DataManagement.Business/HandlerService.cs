using DataManagement.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.Business
{
    public class HandlerService<T> : IHandlerService<T> where T : class
    {
    }
}
