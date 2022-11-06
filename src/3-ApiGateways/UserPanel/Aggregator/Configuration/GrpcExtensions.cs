using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationsByOwnerIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectsByOrganizationIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Configuration
{
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

            services.AddGrpcClient<GetProjectsByOrganizationIdGrpcServiceClient>(options =>
            {
                options.Address = new Uri(configuration["Url:Owner-Read-Service"]);
            });
        }


    }
}
