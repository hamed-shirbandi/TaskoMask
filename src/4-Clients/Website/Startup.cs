using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;

namespace TaskoMask.Clients.Website;

internal static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.AddCustomSerilog();

        builder.Services.AddMvcPreConfigured(builder.Configuration);

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
    {
        app.UseSerilogRequestLogging();

        app.UseMvcPreConfigured(app.Environment, configuration);

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

        return app;
    }
}
