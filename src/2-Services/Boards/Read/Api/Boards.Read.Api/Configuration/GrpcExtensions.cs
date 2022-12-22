using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById;
using TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;

namespace TaskoMask.Services.Boards.Read.Api.Configuration
{
    public static class GrpcExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void MapGrpcServices(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGrpcService<GetBoardByIdGrpcEndpoint>();
            endpoints.MapGrpcService<GetCardsByBoardIdGrpcEndpoint>();
        }


    }
}
