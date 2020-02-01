using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.ApplicationService.Query
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
    }
}
