using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Services;
using TaskoMask.Services.Monolith.Infrastructure.Data.Generator;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Membership;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Workspace;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Services;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC
{
    public static class InfrastructureExtensions
    {

        #region Public Methods




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
        public static void InitialDatabasesAndSeedEssentialData(this IServiceProvider serviceProvider)
        {
            WriteDbInitialization.Initial(serviceProvider);
            ReadDbInitialization.Initial(serviceProvider);
            WriteDbSeedData.SeedEssentialData(serviceProvider);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void GenerateAndSeedSampleData(this IServiceProvider serviceProvider)
        {
            SampleDataGenerator.GenerateAndSeedSampleData(serviceProvider);
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
            services.AddScoped<IOwnerAggregateRepository, OwnerAggregateRepository>();
            services.AddScoped<IBoardAggregateRepository, BoardAggregateRepository>();
            services.AddScoped<ITaskAggregateRepository, TaskAggregateRepository>();
            services.AddScoped<IOperatorRepository, OperatorRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
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
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }




        /// <summary>
        /// 
        /// </summary>
        private static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskValidatorService, TaskValidatorService>();
            services.AddScoped<IBoardValidatorService, BoardValidatorService>();
        }


        #endregion
    }
}
