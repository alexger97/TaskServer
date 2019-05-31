using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TaskServerApp.Models;
using TaskServerApp.Controllers;
using Microsoft.IdentityModel.Protocols;

namespace TaskServerApp
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
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddSingleton<IUserController, UserController>();
            //services.AddSingleton<ITaskController, TaskController>();
            services.AddDbContextPool<AppDataBaseContextSL>(

                //options => options.UseSqlServer($"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = {nameof(AppDataBaseContextSL)}; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"));
                options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

                    //$"Data Source = taskserverappdbserver.database.windows.net; User ID = task_root;Initial Catalog ={nameof(AppDataBaseContextSL)} ; Password = TTT@@!2019au; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"));

                //  ($"Server = tcp:taskserverappdbserver.database.windows.net, 1433; Initial Catalog = appdatabasecontext; Persist Security Info = False; User ID =task-root; Password =TTT@@!2019au; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"));
                // Data Source = taskserverappdbserver.database.windows.net; User ID = task_root; Password = ********; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False
            { }
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
