using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.ApplicationService.Query
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandlerAsync(TQuery query);
    }

}
