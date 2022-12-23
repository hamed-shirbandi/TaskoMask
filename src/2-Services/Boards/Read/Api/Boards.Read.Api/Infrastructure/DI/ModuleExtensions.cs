using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.Mapping;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.Mapper;

namespace TaskoMask.Services.Boards.Read.Api.Infrastructure.DI
{

    /// <summary>
    /// 
    /// </summary>
    public static class ModuleExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBuildingBlocksInfrastructure(configuration, consumerAssemblyMarkerType: typeof(Program), handlerAssemblyMarkerType: typeof(GetBoardByIdHandler));

            services.AddBuildingBlocksApplication(validatorAssemblyMarkerType: typeof(Program));

            services.AddMapper(typeof(MappingProfile));

            services.AddMongoDbContext(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("MongoDB");
            services.AddScoped<BoardReadDbContext>().AddOptions<MongoDbOptions>().Bind(options);
        }

    }
}
