using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Captcha;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.DI;

namespace TaskoMask.Services.Identity.Api.Configuration;

internal static class HostingExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.AddCustomSerilog();

        builder.Services.AddRazorPagesPreConfigured(builder.Configuration);

        builder.Services.AddModules(builder.Configuration);

        builder.Services.AddIdentityServer();

        builder.Services.AddControllers();

        builder.Services.AddCaptcha();

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
    {
        app.UseSerilogRequestLogging();

        app.UseIdentityServer();

        app.UseRazorPagesPreConfigured(app.Environment, configuration);

        app.Services.InitialDatabasesAndSeedEssentialData();

        app.MapRazorPages().RequireAuthorization();

        app.MapControllers();

        return app;
    }
}
