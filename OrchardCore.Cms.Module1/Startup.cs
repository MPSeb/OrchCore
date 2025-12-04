using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Cms.Module1.Drivers;
using OrchardCore.Cms.Module1.Handlers;
using OrchardCore.Cms.Module1.Migrations;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.Cms.Module1.Indexing;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.Data;

namespace OrchardCore.Cms.Module1
{
    public sealed class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<UrgencyPart>().UseDisplayDriver<UrgencyPartDisplayDriver>().AddHandler<UrgencyPartHandler>();
            services.AddIndexProvider<UrgencyPartIndexProvider>();
            services.AddScoped<IDataMigration, UrgencyPartMigrations>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "OrchardCore.Cms.Module1",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }

}
