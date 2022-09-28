using Microsoft.IdentityModel.Tokens;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;

namespace TaskoMask.ApiGateways.UserPanel.ApiGateWay.Configuration
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


            var authenticationProviderKey = "IdentityApiKey";

            builder.Services.AddAuthentication()
             .AddJwtBearer(authenticationProviderKey, x =>
             {
                 x.Authority = "https://localhost:8013"; // IDENTITY SERVER URL
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false
                 };
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

            app.UseOcelot().Wait();

            return app;
        }
    }
}