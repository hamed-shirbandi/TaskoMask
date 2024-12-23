﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByOrganizationId;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByProjectId;
using TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById;
using TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectByIdGrpcService;

namespace TaskoMask.Services.Boards.Read.Api.Configuration;

public static class GrpcExtensions
{
    /// <summary>
    ///
    /// </summary>
    public static void MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<GetBoardByIdGrpcEndpoint>();
        app.MapGrpcService<GetCardsByBoardIdGrpcEndpoint>();
        app.MapGrpcService<GetBoardsByProjectIdGrpcEndpoint>();
        app.MapGrpcService<GetBoardsByOrganizationIdGrpcEndpoint>();
        app.MapGrpcService<GetCardByIdGrpcEndpoint>();
    }

    /// <summary>
    ///
    /// </summary>
    public static void AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<GetProjectByIdGrpcServiceClient>(options =>
        {
            options.Address = new Uri(configuration["Url:Owner-Read-Service"]);
        });
    }
}
