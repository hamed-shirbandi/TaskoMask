using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Boards.Write.Application.Resources;
using TaskoMask.Services.Boards.Write.Domain.Data;
using TaskoMask.Services.Boards.Write.Domain.Services;
using TaskoMask.Services.Boards.Write.Infrastructure.Data.DbContext;
using TaskoMask.Services.Boards.Write.Infrastructure.Data.Repositories;
using TaskoMask.Services.Boards.Write.Infrastructure.Data.Services;

namespace TaskoMask.Services.Boards.Write.Infrastructure.CrossCutting.DI
{

    /// <summary>
    /// 
    /// </summary>
    public static class InfrastructureModule
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration, Type consumerAssemblyMarkerType)
        {
            services.AddBuildingBlocksInfrastructure(configuration, consumerAssemblyMarkerType,handlerAssemblyMarkerType: typeof(ApplicationMessages));

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
            services.AddScoped<BoardWriteDbContext>().AddOptions<MongoDbOptions>().Bind(options);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IBoardValidatorService, BoardValidatorService>();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBoardAggregateRepository, BoardAggregateRepository>();
        }
    }
}
