using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using TaskoMask.Clients.UserPanel.Services.DragDrop;
using TaskoMask.Clients.UserPanel.Services.ComponentMessage;
using TaskoMask.BuildingBlocks.Web.Configuration;
using TaskoMask.BuildingBlocks.Web.ApiContracts;
using TaskoMask.Clients.UserPanel.Services.API;

namespace TaskoMask.Clients.UserPanel.Configuration
{

    /// <summary>
    /// 
    /// </summary>
    public static class HostingExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddHttpServices(configuration);
            services.AddApiServices();
            services.AddComponentMessageServices();
            services.AddDragDropServices();
            services.AddBlazoredToast();
            services.AddBlazoredModal();
            services.AddOidcAuthentication(options =>
            {
                configuration.Bind("oidc", options.ProviderOptions);
            });
        }



        /// <summary>
        /// 
        /// </summary>
        private static void AddHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(
                name: "UserPanelApiGateway",
                configureClient: client =>
                {
                    client.BaseAddress = new Uri(configuration.GetValue<string>("Url:UserPanelApiGateway"));
                    client.Timeout = TimeSpan.FromSeconds(50);
                }).AddHttpMessageHandler<IdentityServerAuthorizationHandler>();

            services.AddScoped<IdentityServerAuthorizationHandler>();
           
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("UserPanelApiGateway"));
           
            services.AddHttpClientService();

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



        /// <summary>
        /// 
        /// </summary>
        private static void AddApiServices(this IServiceCollection services)
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
