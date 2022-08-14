using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Services;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.DbContext;
using TaskoMask.BuildingBlocks.Infrastructure.EventSourcing;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Monolith.Application.Membership.Roles.Services;
using TaskoMask.Services.Monolith.Application.Membership.Operators.Services;
using TaskoMask.Services.Monolith.Application.Membership.Permissions.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Services;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Workspace;
using TaskoMask.Services.Monolith.Infrastructure.Data.Write.Repositories.Membership;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Data;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.BuildingBlocks.Domain.Data;
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
using TaskoMask.BuildingBlocks.Infrastructure.Repositories;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Activities.Services;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Services;
using TaskoMask.Services.Monolith.Infrastructure.Services.Security;
using TaskoMask.BuildingBlocks.Infrastructure.Services.Security;

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
        public static void ConfigureIocContainer(this IServiceCollection services)
        {
            #region Application

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

            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
            


            #endregion

            #region Infrastructure

            services.AddScoped<IReadDbContext, ReadDbContext>();
            services.AddScoped<IWriteDbContext, WriteDbContext>();
            services.AddScoped<IEventStore, RedisEventStore>();
            services.AddScoped<IInMemoryBus, InMemoryBus>();

            services.AddScoped<IEncryptionService, EncryptionService>();
            services.AddScoped<IUserAccessManagementService, UserAccessManagementService>();

            services.AddScoped<ITaskValidatorService, TaskValidatorService>();
            services.AddScoped<IBoardValidatorService, BoardValidatorService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //ReadModel Repositories
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            //Aggregate repositories
            services.AddScoped<IOwnerAggregateRepository, OwnerAggregateRepository>();
            services.AddScoped<IBoardAggregateRepository, BoardAggregateRepository>();
            services.AddScoped<ITaskAggregateRepository, TaskAggregateRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperatorRepository, OperatorRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            

            #endregion

        }
    }
}
