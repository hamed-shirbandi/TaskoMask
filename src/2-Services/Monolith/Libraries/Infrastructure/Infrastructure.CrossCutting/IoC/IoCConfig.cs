using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Services;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;
using TaskoMask.Services.Monolith.Application.Membership.Roles.Services;
using TaskoMask.Services.Monolith.Application.Membership.Operators.Services;
using TaskoMask.Services.Monolith.Application.Membership.Permissions.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Services;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Workspace;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Membership;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Authorization;
using TaskoMask.Services.Monolith.Application.Authorization.Users.Services;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Services;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Activities.Services;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Services;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mediator;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Services;
using TaskoMask.BuildingBlocks.Infrastructure.Extensions;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.IoC
{

    /// <summary>
    /// 
    /// </summary>
    public static class IoCConfig
    {

  
        /// <summary>
        /// 
        /// </summary>
        public static void AddProjectConfigureServices(this IServiceCollection services)
        {
            services.AddBuildingBlocksApplicationServices();
            services.AddBuildingBlocksInfrastructureServices();

            services.AddApplicationServices();
            services.AddInfrastructureReadDataServices();
            services.AddInfrastructureWriteDataServices();

            services.AddAutoMapperSetup();
            services.AddMediatorHandlers();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICommentService, CommentService>();

        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddInfrastructureReadDataServices(this IServiceCollection services)
        {
            services.AddScoped<IReadDbContext, ReadDbContext>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddInfrastructureWriteDataServices(this IServiceCollection services)
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

    }
}
