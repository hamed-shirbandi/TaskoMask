using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using TaskoMask.Services.Owners.Write.Infrastructure.CrossCutting.DI;
using TaskoMask.Services.Owners.Write.Infrastructure.Data.DbContext;
using TaskoMask.Services.Owners.Write.Api.Consumers;

namespace TaskoMask.Services.Owners.Write.Api.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.AddCustomSerilog();

            builder.Services.AddModules(builder.Configuration,consumerAssemblyMarkerType:typeof(UserRegisteredConsumer));

            builder.Services.AddWebApiPreConfigured(builder.Configuration);

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseSerilogRequestLogging();

            app.UseWebApiPreConfigured(app.Environment);

            app.Services.InitialDatabasesAndSeedEssentialData();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}