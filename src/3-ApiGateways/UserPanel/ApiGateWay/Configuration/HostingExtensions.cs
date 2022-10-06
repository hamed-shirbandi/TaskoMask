using Microsoft.IdentityModel.Tokens;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;

namespace TaskoMask.ApiGateways.UserPanel.ApiGateway.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.AddCustomSerilog();

            builder.Configuration.AddOcelotWithSwaggerSupport((o) =>
            {
                o.Folder = "Configuration/Ocelot";
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddOcelot();

            builder.Services.AddSwaggerForOcelot(builder.Configuration);

            builder.Services.AddCors();

            builder.Services.AddAuthentication()
             .AddJwtBearer(builder.Configuration["AuthenticationProviderKey"], x =>
             {
                 x.Authority = builder.Configuration["Url:IdentityServer"];
                 x.TokenValidationParameters.ValidateAudience = false;
             });

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

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseOcelot().Wait();

            return app;
        }
    }
}