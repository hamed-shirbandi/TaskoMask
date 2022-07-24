﻿using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using TaskoMask.Presentation.Framework.Share.Configuration.Startup;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Presentation.UI.UserPanel.Services.Authentication;
using TaskoMask.Presentation.UI.UserPanel.Services.API;
using TaskoMask.Presentation.UI.UserPanel.Services.DragDrop;
using TaskoMask.Presentation.UI.UserPanel.Services.Http;
using TaskoMask.Presentation.UI.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Presentation.UI.UserPanel.Configuration
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

            services.AddSharedConfigureServices();

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

            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            services.AddClientServices();
            services.AddBlazoredLocalStorage();
            services.AddBlazoredToast();
            services.AddBlazoredModal();
        }




        /// <summary>
        /// 
        /// </summary>
        private static void AddClientServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IComponentMessageService, ComponentMessageService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAccountApiService, AccountApiService>();
            services.AddScoped<IOrganizationApiService, OrganizationClientService>();
            services.AddScoped<IProjectApiService, ProjectClientService>();
            services.AddScoped<IBoardApiService, BoardClientService>();
            services.AddScoped<ICardApiService, CardClientService>();
            services.AddScoped<ITaskApiService, TaskClientService>();
            services.AddScoped<IOwnerApiService, OwnerClientService>();
            services.AddScoped<ICommentApiService, CommentClientService>();
            services.AddScoped<IDragDropService, DragDropService>();
        }

    }
}
