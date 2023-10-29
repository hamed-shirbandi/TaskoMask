using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DI;
using TaskoMask.BuildingBlocks.Web.Grpc.Configuration;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Owners.Read.Api.Configuration
{
    internal static class HostingExtensions
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcServices();
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
