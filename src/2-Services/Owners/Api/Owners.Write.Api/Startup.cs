using Microsoft.AspNetCore.Builder;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.Services.Owners.Write.Api.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Owners.Write.Api.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Owners.Write.Api;

internal static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddModules(builder.Configuration);

        builder.AddWebApiPreConfigured();

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        app.UseWebApiPreConfigured();

        app.Services.InitialDatabasesAndSeedEssentialData();

        app.MapControllers();

        return app;
    }
}
