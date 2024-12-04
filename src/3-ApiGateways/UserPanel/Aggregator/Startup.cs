using Serilog;
using TaskoMask.ApiGateways.UserPanel.Aggregator.Configuration;
using TaskoMask.ApiGateways.UserPanel.Aggregator.Infrastructure.DI;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator;

internal static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddModules(builder.Configuration);

        builder.AddWebApiPreConfigured();

        builder.Services.AddGrpcClients(builder.Configuration);

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        app.UseWebApiPreConfigured();

        app.MapControllers();

        return app;
    }
}
