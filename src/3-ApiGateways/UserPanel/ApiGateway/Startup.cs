using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Captcha;

namespace TaskoMask.ApiGateways.UserPanel.ApiGateway;

internal static class Startup
{
    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        //TODO : Swagger tries to initialize DNTCaptcha.Core built-in controller and throws an error if we remove the bellow lines
        // We need to ignore DNTCaptcha.Core during generating swagger docs
        builder.Services.AddControllers();
        builder.Services.AddCaptcha();

        builder.Configuration.AddOcelotWithSwaggerSupport(
            (o) =>
            {
                o.Folder = "Configuration/Ocelot";
            }
        );

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddOcelot();

        builder.Services.AddSwaggerForOcelot(builder.Configuration);

        builder.Services.AddCors();

        builder
            .Services.AddAuthentication()
            .AddJwtBearer(
                builder.Configuration["AuthenticationProviderKey"],
                x =>
                {
                    x.Authority = builder.Configuration["Url:IdentityServer"];
                    x.TokenValidationParameters.ValidateAudience = false;
                }
            );

        return builder.Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        app.UseStaticFiles();

        app.UseSwaggerForOcelotUI(opt =>
        {
            opt.PathToSwaggerGenerator = "/swagger/docs";
        });

        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseOcelot().Wait();

        return app;
    }
}
