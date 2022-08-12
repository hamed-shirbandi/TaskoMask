using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Application.Workspace.Projects.Services;
using TaskoMask.Infrastructure.Data.Write.DbContext;
using TaskoMask.Infrastructure.Data.Write.EventSourcing;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Infrastructure.CrossCutting.Bus;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Membership.Roles.Services;
using TaskoMask.Application.Membership.Operators.Services;
using TaskoMask.Application.Membership.Permissions.Services;
using TaskoMask.Application.Workspace.Owners.Services;
using TaskoMask.Application.Workspace.Organizations.Services;
using TaskoMask.Application.Workspace.Boards.Services;
using TaskoMask.Application.Workspace.Cards.Services;
using TaskoMask.Application.Workspace.Tasks.Services;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Infrastructure.Data.Write.Repositories.Workspace;
using TaskoMask.Infrastructure.Data.Write.Repositories.Membership;
using TaskoMask.Domain.DomainModel.Membership.Data;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Infrastructure.CrossCutting.Services.Security;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Domain.DomainModel.Authorization.Data;
using TaskoMask.Infrastructure.Data.Write.Repositories.Authorization;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Infrastructure.Data.Write.Services;
using TaskoMask.Infrastructure.Data.Read.DbContext;
using TaskoMask.Infrastructure.Data.Read.Repositories;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Services;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Services;
using TaskoMask.Application.Workspace.Activities.Services;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Workspace.Comments.Services;

namespace Infrastructure.CrossCutting.IoC
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
