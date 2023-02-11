using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId;
using TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById;
using TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId;

namespace TaskoMask.Services.Owners.Read.Api.Configuration
{
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
        }


    }
}
