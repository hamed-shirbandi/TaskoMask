using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Tasks.Write.Application.Resources;
using TaskoMask.Services.Tasks.Write.Domain.Data;
using TaskoMask.Services.Tasks.Write.Domain.Services;
using TaskoMask.Services.Tasks.Write.Infrastructure.Data.DbContext;
using TaskoMask.Services.Tasks.Write.Infrastructure.Data.Repositories;
using TaskoMask.Services.Tasks.Write.Infrastructure.Data.Services;

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

            services.AddDomainServices();

            services.AddRepositories();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("MongoDB");
            services.AddScoped<TaskWriteDbContext>().AddOptions<MongoDbOptions>().Bind(options);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskValidatorService, TaskValidatorService>();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskAggregateRepository, TaskAggregateRepository>();
        }
    }
}
