using Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationsByOwnerIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectsByOrganizationIdGrpcService;
using TaskoMask.ApiGateways.UserPanel.Aggregator.Mapper;
using Microsoft.Extensions.DependencyInjection;

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

            builder.Services.AddMapper();

            builder.Services.AddWebApiPreConfigured(builder.Configuration);

            builder.Services.AddGrpcClient<GetOrganizationsByOwnerIdGrpcServiceClient>(options =>
            {
                options.Address = new Uri(builder.Configuration["Url:Owner-Read-Service"]);
            });

            builder.Services.AddGrpcClient<GetProjectsByOrganizationIdGrpcServiceClient>(options =>
            {
                options.Address = new Uri(builder.Configuration["Url:Owner-Read-Service"]);
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