using System.Net.Http.Headers;
using System.Net.Http.Json;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpClientServices : IHttpClientServices
    {
        #region Fields

        private readonly HttpClient _httpClient;


        #endregion

        #region Ctor



        /// <summary>
        /// 
        /// </summary>
        public HttpClientServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> PostAsync<T>(Uri uri, object input)
        {
            SetDefaultBearerAuthorizationHeader();
            var httpResponse = await _httpClient.PostAsJsonAsync(uri, input);
            return await GetResponseAsync<T>(httpResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> PutAsync<T>(Uri uri, object input)
        {
            SetDefaultBearerAuthorizationHeader();
            var httpResponse = await _httpClient.PutAsJsonAsync(uri, input);
            return await GetResponseAsync<T>(httpResponse);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> PutAsync<T>(Uri uri)
        {
            SetDefaultBearerAuthorizationHeader();
            var httpResponse = await _httpClient.PutAsJsonAsync(uri, new { });
            return await GetResponseAsync<T>(httpResponse);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> GetAsync<T>(Uri uri)
        {
            SetDefaultBearerAuthorizationHeader();
            var httpResponse = await _httpClient.GetAsync(uri);
            return await GetResponseAsync<T>(httpResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        public Uri GetBaseAddress()
        {
            return _httpClient.BaseAddress;
        }




        /// <summary>
        /// 
        /// </summary>
        public void SetBaseAddress(string httpClientBaseAddress)
        {
            _httpClient.BaseAddress = new Uri(httpClientBaseAddress);
        }



        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<Result<T>> GetResponseAsync<T>(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
                return await httpResponse.Content.ReadFromJsonAsync<Result<T>>();

            return Result.Failure<T>(message: $"Request failed!");
        }




        /// <summary>
        /// 
        /// </summary>
        private void SetDefaultBearerAuthorizationHeader()
        {
            //TODO get from local storage
            var jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyQGV4YW1wbGUuY29tIiwianRpIjoiNDQwOWNmMzMtYzJhMy00MmY3LTk4N2UtNDM4ZWE0ZWEzM2MxIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjYxYzBkNzNiZTczOTFiODAxMDU0YzBiYiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InVzZXJAZXhhbXBsZS5jb20iLCJJZCI6IjYxYzBkNzNiZTczOTFiODAxMDU0YzBiYiIsIkRpc3BsYXlOYW1lIjoiaGFtZWRpIiwiRW1haWwiOiJ1c2VyQGV4YW1wbGUuY29tIiwiVXNlck5hbWUiOiJ1c2VyQGV4YW1wbGUuY29tIiwiZXhwIjoxNjQyNjMyNDIwLCJpc3MiOiJodHRwOi8vYXBpLnRhc2tvbWFzay5pciIsImF1ZCI6Imh0dHA6Ly9hcGkudGFza29tYXNrLmlyIn0.lv0uyMa48OvZJjROWzXUFjRjIllsvOGltSE_lPHWGWA";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwtToken);
        }


        #endregion
    }
}
