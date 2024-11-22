using Serilog;
using TaskoMask.ApiGateways.UserPanel.Aggregator.Configuration;
using TaskoMask.ApiGateways.UserPanel.Aggregator.Infrastructure.DI;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator;

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

        builder.Services.AddGrpcClients(builder.Configuration);

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
    {
        app.UseSerilogRequestLogging();

        app.UseWebApiPreConfigured(app.Environment, configuration);

        app.MapControllers();

        return app;
    }
}
