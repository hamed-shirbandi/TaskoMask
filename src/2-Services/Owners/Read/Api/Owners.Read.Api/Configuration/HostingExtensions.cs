using Serilog;
using TaskoMask.BuildingBlocks.Application.Behaviors;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration.Serilog;
using TaskoMask.BuildingBlocks.Web.MVC.Configuration;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper;

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

            builder.Services.AddMediator();

            builder.Services.AddMapper();

            builder.Services.AddCachingBehavior();

            builder.Services.AddInMemoryBus();

            builder.Services.AddMongoDbContext(builder.Configuration);

            builder.Services.AddWebApiPreConfigured(builder.Configuration);

            return builder.Build();
        }



        /// <summary>
        /// 
        /// </summary>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseSerilogRequestLogging();

            app.UseWebApiPreConfigured(app.Services, app.Environment);

            app.Services.InitialDatabases();

            app.UseEndpoints(endpoints =>
            {
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



        /// <summary>
        /// 
        /// </summary>
        private static void AddMediator(this IServiceCollection services)
        {
            //Load all queries ...
            // services.AddMediatR(typeof(OwnerQueryHandlers));
        }
    }
}