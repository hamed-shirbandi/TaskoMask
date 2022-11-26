using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Tasks.Write.Application.Resources;
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
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration,Type consumerAssemblyMarkerType)
        {
            services.AddBuildingBlocksInfrastructure(configuration, consumerAssemblyMarkerType, handlerAssemblyMarkerType: typeof(ApplicationMessages));

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
