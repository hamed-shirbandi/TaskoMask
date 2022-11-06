using Serilog;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;

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

            builder.Services.AddBuildingBlocksInfrastructure(builder.Configuration, typeof(Program), typeof(Program));

            builder.Services.AddBuildingBlocksApplication(typeof(Program));

            builder.Services.AddMapper();

            builder.Services.AddMongoDbContext(builder.Configuration);

            builder.Services.AddWebApiPreConfigured(builder.Configuration);

            builder.Services.AddGrpc(options =>
            {
                options.Interceptors.Add<GrpcExceptionInterceptor>();
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

            app.Services.InitialDatabases();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcServices();
                endpoints.MapControllers();
            });

            return app;
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("MongoDB");
            services.AddScoped<OwnerReadDbContext>().AddOptions<MongoDbOptions>().Bind(options);
        }

    }
}