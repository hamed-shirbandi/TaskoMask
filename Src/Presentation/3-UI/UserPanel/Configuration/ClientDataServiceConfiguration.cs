using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.UI.UserPanel.Services.Data;

namespace TaskoMask.Presentation.UI.UserPanel.Configuration
{
    /// <summary>
    /// Shared Configuration for Blazor and MVC and WebAPI projects
    /// </summary>
    public static class ClientDataServiceConfiguration
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddClientDataServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IAccountClientService, AccountClientService>();
            services.AddScoped<IOrganizationClientService, OrganizationClientService>();
        }

    }
}
