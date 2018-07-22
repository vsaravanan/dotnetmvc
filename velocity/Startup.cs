using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using velocity.DataManager;
using velocity.Generic;
using velocity.Models;
using velocity.Repository;

namespace velocity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddApplicationInsightsTelemetry(Configuration);
            //services.AddMvc(
            //    config => {
            //        config.Filters.Add(typeof(ErrorHandler));
            //    }
            //);

            services.AddDbContext<VelocityContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("VelocityConnection")));
            //services.AddDbContext<TodoContext>(opt =>
            //    opt.UseInMemoryDatabase("TodoList"));

            services.AddSingleton<ITraderRepository, TraderRepository>();
            //services.AddScoped(typeof(IDataRepository<User, int>), typeof(UserManager));

            services.AddScoped<UserManager>();
            services.AddScoped<RoleManager>();
            services.AddScoped<FeatureManager>();
            services.AddScoped<RoleFeatureManager>();
            services.AddScoped<FormTemplateManager>();
            services.AddScoped<NamedBankingProductAttributeManager>();
            services.AddScoped<MifidManager>();
            services.AddScoped<ModelTemplateManager>();
            services.AddScoped<ProductTemplateManager>();
            services.AddScoped<TradeManager>();
            services.AddScoped<FeeManager>();
            services.AddScoped<MinMaxManager>();

            services.AddDistributedMemoryCache();
            var Timeout = Convert.ToDouble(Configuration.GetSection("Settings")["Timeout"]);
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(Timeout);
            });

            services.AddMvc();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {



            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware().Invoke
            });
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                Constants.Constants.IsDev = true;

            }
            else
            {
                Constants.Constants.IsDev = false;
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
