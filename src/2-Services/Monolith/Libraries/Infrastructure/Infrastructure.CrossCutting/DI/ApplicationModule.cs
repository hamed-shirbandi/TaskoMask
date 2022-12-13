using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Activities.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Handlers;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Services;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Services;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Services;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.DI
{
    internal static class ApplicationModule
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddBuildingBlocksApplication(validatorAssemblyMarkerType: typeof(BoardCommandHandlers));

            services.AddApplicationServices();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IUserAccessManagementService, UserAccessManagementService>();
        }
    }
}
