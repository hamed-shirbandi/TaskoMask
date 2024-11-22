using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
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
        builder.AddCustomSerilog();

        builder.Services.AddModules(builder.Configuration);

        builder.Services.AddWebApiPreConfigured(builder.Configuration);

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
    {
        app.UseSerilogRequestLogging();

        app.UseWebApiPreConfigured(app.Environment, configuration);

        app.Services.InitialDatabasesAndSeedEssentialData();

        app.MapControllers();

        return app;
    }
}
