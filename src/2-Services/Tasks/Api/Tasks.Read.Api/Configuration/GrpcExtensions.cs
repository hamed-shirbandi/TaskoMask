using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId;
using TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId;
using TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;
using TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCardByIdGrpcService;

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
            endpoints.MapGrpcService<GetTasksByCardIdGrpcEndpoint>();
            endpoints.MapGrpcService<GetCommentsByTaskIdGrpcEndpoint>();
            endpoints.MapGrpcService<GetActivitiesByTaskIdGrpcEndpoint>();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<GetCardByIdGrpcServiceClient>(options =>
            {
                options.Address = new Uri(configuration["Url:Board-Read-Service"]);
            });
        }

    }
}
