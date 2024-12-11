using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.OpenTelemetry;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Services;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;

/// <summary>
///
/// </summary>
public static class MvcConfiguration
{
    /// <summary>
    ///
    /// </summary>
    public static void AddMvcPreConfigured(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddCustomSerilog();

        builder.Services.AddControllersWithViews();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddCurrentUserService();

        builder.Services.AddWebServerOptions();

        builder.AddOpenTelemetry();
    }

    /// <summary>
    ///
    /// </summary>
    public static void UseMvcPreConfigured(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error/Unknown");
            app.UseHsts();
        }

        app.UseCustomSerilog();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();
    }

    /// <summary>
    ///
    /// </summary>
    public static void AddWebServerOptions(this IServiceCollection services)
    {
        // If using Kestrel:
        services.Configure<KestrelServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });
        // If using IIS:
        services.Configure<IISServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });
    }

    public static IServiceCollection AddCurrentUserService(this IServiceCollection services)
    {
        return services.AddScoped<ICurrentUser, CurrentUser>();
    }
}
