﻿using static TaskoMask.BuildingBlocks.Contracts.Protos.GetActivitiesByTaskIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardByIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardsByOrganizationIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardsByProjectIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCardsByBoardIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCommentsByTaskIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationReportIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationsByOwnerIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectByIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectsByOrganizationIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetTaskByIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetTasksByCardIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Configuration;

public static class GrpcExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<GetOrganizationsByOwnerIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Owner-Read-Service"]);
        });

        services.AddGrpcClient<GetOrganizationReportIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Owner-Read-Service"]);
        });

        services.AddGrpcClient<GetProjectsByOrganizationIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Owner-Read-Service"]);
        });

        services.AddGrpcClient<GetProjectByIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Owner-Read-Service"]);
        });

        services.AddGrpcClient<GetBoardByIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Board-Read-Service"]);
        });

        services.AddGrpcClient<GetBoardsByProjectIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Board-Read-Service"]);
        });

        services.AddGrpcClient<GetBoardsByOrganizationIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Board-Read-Service"]);
        });

        services.AddGrpcClient<GetCardsByBoardIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Board-Read-Service"]);
        });

        services.AddGrpcClient<GetTaskByIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Task-Read-Service"]);
        });

        services.AddGrpcClient<GetTasksByCardIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Task-Read-Service"]);
        });

        services.AddGrpcClient<GetCommentsByTaskIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Task-Read-Service"]);
        });

        services.AddGrpcClient<GetActivitiesByTaskIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Task-Read-Service"]);
        });
    }
}
