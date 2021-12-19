using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using TaskoMask.Presentation.UI.UserPanel.Helpers;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var token = await _localStorage.GetItemAsync<string>(ConstantKeys.LocalToken);
            var token = await _localStorage.GetItemAsync<string>("");
            if (token == null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")
                        )
                    );
        }
    }
}