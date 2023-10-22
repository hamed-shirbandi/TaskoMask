using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using TaskoMask.Services.Tasks.Write.Api.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Tasks.Write.Api.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.AddCustomSerilog();

            builder.Services.AddModules(builder.Configuration,consumerAssemblyMarkerType:typeof(Program));

            builder.Services.AddWebApiPreConfigured(builder.Configuration);

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app, IConfiguration configuration)
        {

            app.UseSerilogRequestLogging();

            app.UseWebApiPreConfigured(app.Environment, configuration);

            app.Services.InitialDatabasesAndSeedEssentialData();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}