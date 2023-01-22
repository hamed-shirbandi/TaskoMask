using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;
using TaskoMask.BuildingBlocks.Infrastructure.Mapping;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.Profiles;
using TaskoMask.Services.Monolith.Infrastructure.Data.Generator;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.DI
{
    public static class InfrastructureModule
    {

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBuildingBlocksInfrastructure(configuration,consumerAssemblyMarkerType: typeof(InfrastructureModule),handlerAssemblyMarkerType: typeof(InfrastructureModule));

            services.AddMapper(typeof(WorkspaceMappingProfile));

            services.AddInfrastructureWriteDataServices(configuration);

            services.AddInfrastructureReadDataServices(configuration);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureReadDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddReadSideMongoDbContext(configuration);
            services.AddReadSideRepositories();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureWriteDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWriteSideMongoDbContext(configuration);
            services.AddWriteSideRepositories();
            services.AddDomainServices();

        }



        /// <summary>
        /// 
        /// </summary>
        public static void GenerateAndSeedSampleData(this IServiceProvider serviceProvider)
        {
            SampleDataGenerator.GenerateAndSeedSampleData(serviceProvider);
        }





        /// <summary>
        /// 
        /// </summary>
        public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
        {
            WriteDbInitialization.Initial(serviceProvider);
            ReadDbInitialization.Initial(serviceProvider);
            WriteDbSeedData.SeedEssentialData(serviceProvider);
        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private static void AddWriteSideMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("Mongo:Write");

            services.AddScoped<IWriteDbContext, WriteDbContext>().AddOptions<WriteDbOptions>().Bind(options);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddWriteSideRepositories(this IServiceCollection services)
        {
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddReadSideMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("Mongo:Read");

            services.AddScoped<IReadDbContext, ReadDbContext>().AddOptions<ReadDbOptions>().Bind(options);
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddReadSideRepositories(this IServiceCollection services)
        {
        }




        /// <summary>
        /// 
        /// </summary>
        private static void AddDomainServices(this IServiceCollection services)
        {
        }


        #endregion
    }
}
