using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Contracts.Services;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.AuthenticatedUser
{
    public static class AuthenticatedUserExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddAuthenticatedUserService(this IServiceCollection services)
        {
            return services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
        }
    }
}
