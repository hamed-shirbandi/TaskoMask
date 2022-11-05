using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationsByOwnerIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Configuration
{
    internal static class HostingExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.AddCustomSerilog();

            builder.Services.AddWebApiPreConfigured(builder.Configuration);

            builder.Services.AddGrpcClient<GetOrganizationsByOwnerIdGrpcServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:5021");
            });

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseSerilogRequestLogging();

            app.UseWebApiPreConfigured(app.Environment);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}