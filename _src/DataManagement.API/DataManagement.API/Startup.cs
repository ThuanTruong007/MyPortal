using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataManagement.Repository;
using DataManagement.Repository.Interfaces;
using DataManagement.Entities.Enums;

namespace DataManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseConnections = new Dictionary<DatabaseConnection, string>
            {
                {DatabaseConnection.AppDb,Configuration.GetConnectionString("appDb") },
                {DatabaseConnection.LogDb,Configuration.GetConnectionString("logDb") },
                {DatabaseConnection.StagingDB,Configuration.GetConnectionString("stagingDb") }
            };
            services.AddSingleton<IDictionary<DatabaseConnection, string>>(databaseConnections);

            // Inject the factory
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();


            //services.AddSingleton(typeof(IRepository<>),sp=> 
            //{
            //    return new Object();
            //}
            //);
            //services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            //services.AddSingleton(typeof(IRepository<>), typeof(AppDbConnectionRepository<>));
            services.AddSingleton(typeof(IAppDbRepository<>), typeof(AppDbRepositoryExt<>));

            //services.AddSingleton<IAppDbConnectionString,DbConnectionString>()
            //services.AddSingleton(typeof(IHandlerService<>), typeof(HandlerService<>));
            //services.AddSingleton<IUserRepository, UserRepository>();

            //var assembly = Assembly.GetExecutingAssembly();


            //services.AddSingleton<IUserManager, UserManager>();
            //services.AddSingleton<IUserManager>(
            //    sp =>
            //    {
            //        return new UserManager(new UserRepository(new DbConnectionFactory(databaseConnections)));
            //    }
            //    );
            NetCoreAutoRegisterDI.RegisterAssemblyPublicNonGenericClasses(services);
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapDefaultControllerRoute();
               
                    //name: "default"
                    //, pattern: "{controller}/{action}/{ id ?}");
            });
        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    builder.RegisterModule<AutofacModule>();
        //}
    }
}
