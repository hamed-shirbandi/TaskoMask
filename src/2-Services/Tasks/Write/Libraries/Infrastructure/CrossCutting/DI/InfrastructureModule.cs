using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Tasks.Write.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Tasks.Write.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    public static class InfrastructureModule
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddBuildingBlocksInfrastructure(configuration, typeof(SomeClassInApplicationLayer), typeof(SomeClassInApplicationLayer));

            services.AddMongoDbContext(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("MongoDB");
            services.AddScoped<TaskWriteDbContext>().AddOptions<MongoDbOptions>().Bind(options);
        }

    }
}
