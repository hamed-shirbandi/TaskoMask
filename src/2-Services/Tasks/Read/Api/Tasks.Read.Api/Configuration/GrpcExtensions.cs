using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId;
using TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId;
using TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;

namespace TaskoMask.Services.Tasks.Read.Api.Configuration
{
    public static class GrpcExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void MapGrpcServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<GetTaskByIdGrpcEndpoint>();
            endpoints.MapGrpcService<GetCommentsByTaskIdGrpcEndpoint>();
            endpoints.MapGrpcService<GetActivitiesByTaskIdGrpcEndpoint>();
        }


    }
}
