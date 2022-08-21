using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mediator;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;

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
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddBuildingBlocksApplicationServices();
            services.AddBuildingBlocksInfrastructureServices();

            services.AddApplicationServices();
            services.AddInfrastructureReadDataServices();
            services.AddInfrastructureWriteDataServices();

            services.AddAutoMapperSetup();
            services.AddMediatorHandlers();
        }


    }
}
