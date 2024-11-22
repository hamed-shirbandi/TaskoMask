using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Grpc;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.Services.Owners.Read.Api.Configuration;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DI;

namespace TaskoMask.Services.Owners.Read.Api;

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

        builder.Services.AddGrpcPreConfigured();

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
    {
        app.UseSerilogRequestLogging();

        app.UseWebApiPreConfigured(app.Environment, configuration);

        app.Services.InitialDatabase();

        app.MapGrpcServices();

        app.MapControllers();

        return app;
    }
}
