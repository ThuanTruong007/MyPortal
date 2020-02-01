using System;
using System.Diagnostics;

namespace DataManagement.ApplicationService.Query
{
    public sealed class QueryProcessor : IQueryProcessor
    {

        public QueryProcessor() { }

        [DebuggerStepThrough]
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = Activator.CreateInstance(handlerType);

            return handler.Handle((dynamic)query);
        }
    }
}
