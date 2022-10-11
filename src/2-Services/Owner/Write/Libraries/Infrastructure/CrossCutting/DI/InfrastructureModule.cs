using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Infrastructure.EntityFramework;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.Services.Owner.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Owner.Infrastructure.CrossCutting.Mediator;
using TaskoMask.Services.Owner.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Owner.Infrastructure.CrossCutting.DI
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
            services.AddMapper();
            services.AddInMemoryBus();
            services.AddRedisEventStoreService();
            services.AddDbContext(options =>
            {
                configuration.GetSection("EntityFramework").Bind(options);
            });
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddDbContext(this IServiceCollection services, Action<EFCoreDbOptions> setupAction)
        {
            services.Configure(setupAction);
            services.AddDbContext<OwnerWriteDbContext>();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
        {
            serviceProvider.InitialDatabase<OwnerWriteDbContext>();
            // no need for seeding any data
        }

    }
}
