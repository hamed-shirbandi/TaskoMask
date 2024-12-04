using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Captcha;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;
using TaskoMask.Services.Identity.Api.Configuration;
using TaskoMask.Services.Identity.Api.Infrastructure.CrossCutting.DI;

namespace TaskoMask.Services.Identity.Api;

internal static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.AddRazorPagesPreConfigured();

        builder.Services.AddModules(builder.Configuration);

        builder.Services.AddPreConfiguredIdentityServer();

        builder.Services.AddControllers();

        builder.Services.AddCaptcha();

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        app.UseIdentityServer();

        app.UseRazorPagesPreConfigured();

        app.Services.InitialDatabasesAndSeedEssentialData();

        app.MapRazorPages().RequireAuthorization();

        app.MapControllers();

        return app;
    }
}
