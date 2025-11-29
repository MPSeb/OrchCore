using Microsoft.AspNetCore.Builder;

namespace OrchardCore.Cms.Web1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOrchardCms();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment environment)
        {
            if(environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseOrchardCore();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

    }
}
