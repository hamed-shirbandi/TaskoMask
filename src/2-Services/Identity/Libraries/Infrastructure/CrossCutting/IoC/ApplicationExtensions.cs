using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Identity.Application.Users.Services;

namespace TaskoMask.Services.Identity.Infrastructure.CrossCutting.IoC
{
    public static class ApplicationExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }


    }
}
