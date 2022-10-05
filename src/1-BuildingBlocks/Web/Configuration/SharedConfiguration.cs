using Microsoft.Extensions.DependencyInjection;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.BuildingBlocks.Web.Services.API;
using TaskoMask.BuildingBlocks.Web.Services.Http;

namespace TaskoMask.BuildingBlocks.Web.Configuration
{
    /// <summary>
    /// Shared Configuration for Web projects (Blazor, MVC and WebAPI)
    /// </summary>
    public static class SharedConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddSharedService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddHttpClientService();
            services.AddApiServices();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddHttpClientService(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientService, HttpClientService>();
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationApiService, OrganizationApiService>();
            services.AddScoped<IProjectApiService, ProjectApiService>();
            services.AddScoped<IBoardApiService, BoardApiService>();
            services.AddScoped<ICardApiService, CardApiService>();
            services.AddScoped<ITaskApiService, TaskApiService>();
            services.AddScoped<IOwnerApiService, OwnerApiService>();
            services.AddScoped<ICommentApiService, CommentApiService>();
        }
    }
}
