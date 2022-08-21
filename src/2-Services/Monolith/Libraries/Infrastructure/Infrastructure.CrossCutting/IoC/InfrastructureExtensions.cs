using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Services;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Services;
using TaskoMask.Services.Monolith.Infrastructure.Data.Generator;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DataProviders;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Authorization;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Membership;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Workspace;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Services;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC
{
    public static class InfrastructureExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddInfrastructureReadDataServices(this IServiceCollection services)
        {
            services.AddScoped<IReadDbContext, ReadDbContext>();
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
        public static void AddInfrastructureWriteDataServices(this IServiceCollection services)
        {
            services.AddScoped<IWriteDbContext, WriteDbContext>();
            services.AddScoped<IOwnerAggregateRepository, OwnerAggregateRepository>();
            services.AddScoped<IBoardAggregateRepository, BoardAggregateRepository>();
            services.AddScoped<ITaskAggregateRepository, TaskAggregateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperatorRepository, OperatorRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IUserAccessManagementService, UserAccessManagementService>();
            services.AddScoped<ITaskValidatorService, TaskValidatorService>();
            services.AddScoped<IBoardValidatorService, BoardValidatorService>();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void InitialAdnSeedDatabases(this IServiceProvider serviceProvider)
        {
            WriteDbInitialization.Initial(serviceProvider);
            ReadDbInitialization.Initial(serviceProvider);
            WriteDbSeedData.Seed(serviceProvider);
        }



        /// <summary>
        /// 
        /// </summary>
        public static void GenerateAndSeedSampleData(this IServiceProvider serviceProvider)
        {
            SampleDataGenerator.GenerateAndSeedSampleData(serviceProvider);
        }
    }
}
