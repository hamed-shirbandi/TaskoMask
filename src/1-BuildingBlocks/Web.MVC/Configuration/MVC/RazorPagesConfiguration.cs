using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.OpenTelemetry;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.Serilog;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;

/// <summary>
///
/// </summary>
public static class RazorPagesConfiguration
{
    /// <summary>
    ///
    /// </summary>
    public static void AddRazorPagesPreConfigured(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddCustomSerilog();

        builder.Services.AddRazorPages();

        builder.Services.AddAuthentication();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddCurrentUserService();

        builder.AddOpenTelemetry();
    }

    /// <summary>
    ///
    /// </summary>
    public static void UseRazorPagesPreConfigured(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.UseCustomSerilog();

        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();
    }
}
