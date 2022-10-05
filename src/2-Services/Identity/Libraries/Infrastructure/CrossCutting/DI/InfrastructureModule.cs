using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.AspNetIdentity;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Identity.Infrastructure.CrossCutting.Mediator;
using TaskoMask.Services.Identity.Infrastructure.Data.DataProviders;
using TaskoMask.Services.Identity.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Identity.Infrastructure.CrossCutting.DI
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
            services.AddInMemoryBus();
            services.AddDbContext();
            services.AddAspNetIdentity(configuration);
            services.AddMapper();
            services.AddMediator();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabasesAndSeedEssentialData( IServiceProvider serviceProvider)
        {
            serviceProvider.InitialDatabase();
            serviceProvider.SeedEssentialData();
        }

    }
}
