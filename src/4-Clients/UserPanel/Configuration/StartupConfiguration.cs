using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using TaskoMask.BuildingBlocks.Web.Configuration.Startup;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.Clients.UserPanel.Services.Authentication;
using TaskoMask.Clients.UserPanel.Services.API;
using TaskoMask.Clients.UserPanel.Services.DragDrop;
using TaskoMask.Clients.UserPanel.Services.Http;
using TaskoMask.Clients.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Clients.UserPanel.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static class StartupConfiguration
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddProjectConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddHttpServices(configuration);
            services.AddAuthorizationServices();
            services.AddApiServices();
            services.AddComponentMessageServices();
            services.AddDragDropServices();
            services.AddBlazoredLocalStorage();
            services.AddBlazoredToast();
            services.AddBlazoredModal();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            //add HttpClient with an Interceptor to add jwt token to all requests automatically
            services.AddHttpClient(
                name: "UserPanelAPI",
                configureClient: client =>
                {
                    client.BaseAddress = new Uri(configuration.GetValue<string>("Url:UserPanelAPI"));
                    client.Timeout = TimeSpan.FromSeconds(50);
                }).AddHttpMessageHandler<HttpClientInterceptorService>();

            services.AddScoped<HttpClientInterceptorService>();
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("UserPanelAPI"));
            services.HttpClientService();

        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddAuthorizationServices(this IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

        }


        /// <summary>
        /// 
        /// </summary>
        private static void AddApiServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IAccountApiService, AccountApiService>();
            services.AddScoped<IOrganizationApiService, OrganizationApiService>();
            services.AddScoped<IProjectApiService, ProjectApiService>();
            services.AddScoped<IBoardApiService, BoardApiService>();
            services.AddScoped<ICardApiService, CardApiService>();
            services.AddScoped<ITaskApiService, TaskApiService>();
            services.AddScoped<IOwnerApiService, OwnerApiService>();
            services.AddScoped<ICommentApiService, CommentApiService>();
        }




        /// <summary>
        /// 
        /// </summary>
        private static void AddComponentMessageServices(this IServiceCollection services)
        {
            services.AddScoped<IComponentMessageService, ComponentMessageService>();

        }




        /// <summary>
        /// 
        /// </summary>
        private static void AddDragDropServices(this IServiceCollection services)
        {
            services.AddScoped<IDragDropService, DragDropService>();
        }

    }
}
