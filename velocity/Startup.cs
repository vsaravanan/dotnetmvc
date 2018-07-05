using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using velocity.DataManager;
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

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
