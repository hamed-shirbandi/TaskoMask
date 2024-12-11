using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Jwt;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.OpenTelemetry;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Observation.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Swagger;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;

namespace TaskoMask.BuildingBlocks.Web.MVC.Configuration.MVC;

/// <summary>
///
/// </summary>
public static class WebApiConfiguration
{
    /// <summary>
    ///
    /// </summary>
    public static void AddWebApiPreConfigured(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddCustomSerilog();

        builder.Services.AddControllers().WithPreventAutoValidation();

        builder.Services.AddSwaggerPreConfigured(options =>
        {
            builder.Configuration.GetSection("Swagger").Bind(options);
        });

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddCurrentUserService();

        builder.Services.AddWebServerOptions();

        builder.Services.AddJwtAuthentication(builder.Configuration);

        builder.Services.AddCors();

        builder.AddOpenTelemetry();

        builder.Services.AddGlobalExceptionHandler();
    }

    /// <summary>
    ///
    /// </summary>
    public static void UseWebApiPreConfigured(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseCustomSerilog();

        app.UseGlobalExceptionHandler();

        app.UseSwaggerPreConfigured();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseAuthentication();

        app.UseAuthorization();
    }

    /// <summary>
    /// Prevent auto validate on model binding
    /// </summary>
    private static void WithPreventAutoValidation(this IMvcBuilder builder)
    {
        builder.ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
    }

    /// <summary>
    ///
    /// </summary>
    private static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<HttpGlobalExceptionHandler>();
    }

    /// <summary>
    ///
    /// </summary>
    private static void AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddTransient<HttpGlobalExceptionHandler>();
    }
}
