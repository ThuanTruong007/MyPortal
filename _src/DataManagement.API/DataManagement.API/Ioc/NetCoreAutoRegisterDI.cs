using DataManagement.Business;
using DataManagement.Repository;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DataManagement.Common;
using DataManagement.ApplicationService.Query;
using DataManagement.ApplicationService.Command;

namespace DataManagement.API
{
    public class NetCoreAutoRegisterDI
    {
        public static void RegisterAssemblyPublicNonGenericClasses(IServiceCollection services)
        {
            var assembliesToScan = new[]
{
                Assembly.GetExecutingAssembly()
                ,Assembly.GetAssembly(typeof(UserManager))
                ,Assembly.GetAssembly(typeof(UserRepository))
                //,Assembly.GetAssembly(typeof(UserByIdHandler))
            };
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                //.Where(c => c.Name.EndsWithList(new string[] { "Repository", "Manager","Query" }))
                .Where(c => c.Name.EndsWithList(new string[] { "Repository", "Manager" }))
                .AsPublicImplementedInterfaces(ServiceLifetime.Singleton);
            services.AddCommandQueryHandlers(typeof(IQueryHandler<,>));
            services.AddCommandQueryHandlers(typeof(ICommandHandler<,>));
        }           
    }
}
