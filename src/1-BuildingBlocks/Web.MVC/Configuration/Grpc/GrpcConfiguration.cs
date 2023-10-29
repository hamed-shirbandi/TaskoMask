using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Web.MVC.Exceptions;

namespace TaskoMask.BuildingBlocks.Web.Grpc.Configuration
{
    /// <summary>
    ///
    /// </summary>
    public static class GrpcConfiguration
    {
        /// <summary>
        ///
        /// </summary>
        public static void AddGrpcPreConfigured(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddGrpc(options =>
            {
                options.Interceptors.Add<GrpcGlobalExceptionHandler>();
            });
        }
    }
}
