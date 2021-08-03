using BLL.Services;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.Profiles;
using DAL.Contexts;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GroupProviders
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
            var responsesConString = Configuration["Data:ConnectionString:DefaultConnection"];
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(responsesConString));

            services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddTransient<IGroupService,GroupService>();
            services.AddTransient<IProviderService, ProviderService>();
            services.AddAutoMapper(typeof(ProviderProfile));
            services.AddAutoMapper(typeof(GroupProfile));
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Provider}/{action=Index}/{id?}");
            });
        }
    }
}
