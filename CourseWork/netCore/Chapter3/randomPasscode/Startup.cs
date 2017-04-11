using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
 
namespace ConsoleApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddMvc();
        }
         
        public void Configure(IApplicationBuilder app)
        { 
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}