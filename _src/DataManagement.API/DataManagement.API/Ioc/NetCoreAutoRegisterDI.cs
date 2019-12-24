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


namespace DataManagement.API
{
    public class NetCoreAutoRegisterDI
    {
        public static void RegisterAssemblyPublicNonGenericClasses(IServiceCollection service)
        {
            var assembliesToScan = new[]
{
                Assembly.GetExecutingAssembly()
                ,Assembly.GetAssembly(typeof(UserManager))
                ,Assembly.GetAssembly(typeof(UserRepository))
            };
            service.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWithList(new string[] { "Repository", "Manager" }))
                .AsPublicImplementedInterfaces(ServiceLifetime.Singleton);                
        }
    }
}
