using Microsoft.AspNetCore.Builder;
using OrchardCore.Cms.Module1.Drivers;
using OrchardCore.Cms.Module1.Migrations;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.Cms.Module1.Handlers;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Handlers;
using OrchardCore.Data;
using OrchardCore.Data.Migration;

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
