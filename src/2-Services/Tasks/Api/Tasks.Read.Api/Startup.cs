using Microsoft.AspNetCore.Builder;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Grpc;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.Services.Tasks.Read.Api.Configuration;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DI;

namespace TaskoMask.Services.Tasks.Read.Api;

internal static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddModules(builder.Configuration);

        builder.AddWebApiPreConfigured();

        builder.Services.AddGrpcPreConfigured();

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

        app.Services.InitialDatabase();

        app.MapGrpcServices();

        app.MapControllers();

        return app;
    }
}
