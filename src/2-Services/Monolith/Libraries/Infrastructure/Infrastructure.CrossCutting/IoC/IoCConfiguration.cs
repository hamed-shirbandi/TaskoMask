using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mediator;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC
{

    /// <summary>
    /// 
    /// </summary>
    public static class IoCConfiguration
    {

  
        /// <summary>
        /// 
        /// </summary>
        public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBuildingBlocksApplicationServices();
            services.AddBuildingBlocksInfrastructureServices();

            services.AddApplicationServices();
            services.AddInfrastructureWriteDataServices(configuration);
            services.AddInfrastructureReadDataServices(configuration);

            services.AddAutoMapperSetup();
            services.AddMediatorHandlers();
        }


    }
}
