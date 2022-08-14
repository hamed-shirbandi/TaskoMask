using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net;
using System.Net.Http.Headers;
using TaskoMask.Services.Monolith.Presentation.UI.UserPanel.Helpers;

namespace TaskoMask.Services.Monolith.Presentation.UI.UserPanel.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpClientInterceptorService : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public HttpClientInterceptorService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // How to add a JWT to all of the requests
            var token = await _localStorage.GetItemAsync<string>(MagicKey.Jwt_Token);
            if (token is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);

        }
    }
}
