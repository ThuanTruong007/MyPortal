//using Autofac;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;
//using DataManagement.Business;
//using DataManagement.Repository;

//namespace DataManagement.API.Ioc
//{
//    public class AutofacModule : Autofac.Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
//            // It was then registered with Autofac using the Populate method. All of this starts
//            // with the services.AddAutofac() that happens in Program and registers Autofac
//            // as the service provider.
//            var assemblies = new[]
//            {
//                Assembly.GetExecutingAssembly()
//                ,Assembly.GetAssembly(typeof(UserManager))
//                ,Assembly.GetAssembly(typeof(UserRepository))
//            };
//            builder.RegisterAssemblyTypes(assemblies)
//                   .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("Manager"))
//                   .PublicOnly()
//                   .AsImplementedInterfaces()
//                   .SingleInstance();
//        }
//    }
//}

