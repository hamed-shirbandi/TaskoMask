using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationReportById;
using TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId;
using TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById;
using TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId;

namespace TaskoMask.Services.Owners.Read.Api.Configuration;

public static class GrpcExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void MapGrpcServices(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGrpcService<GetOrganizationsByOwnerIdGrpcEndpoint>();
        endpoints.MapGrpcService<GetProjectsByOrganizationIdGrpcEndpoint>();
        endpoints.MapGrpcService<GetProjectByIdGrpcEndpoint>();
        endpoints.MapGrpcService<GetOrganizationReportByIdGrpcEndpoint>();
    }


    public static void AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<GetBoardsByOrganizationIdGrpcService.GetBoardsByOrganizationIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Board-Read-Service"]);
        });

        services.AddGrpcClient<GetCardsByBoardIdGrpcService.GetCardsByBoardIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Board-Read-Service"]);
        });

        services.AddGrpcClient<GetTasksByCardIdGrpcService.GetTasksByCardIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Task-Read-Service"]);
        });

    }
}
