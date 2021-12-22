using System.Net.Http.Json;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        #region Fields

        private readonly HttpClient _httpClient;


        #endregion

        #region Ctor



        /// <summary>
        /// 
        /// </summary>
        public HttpClientService(HttpClient httpClient)
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
            var httpResponse = await _httpClient.PostAsJsonAsync(uri, input);
            return await GetResponseAsync<T>(httpResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> PutAsync<T>(Uri uri, object input)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(uri, input);
            return await GetResponseAsync<T>(httpResponse);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> PutAsync<T>(Uri uri)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(uri, new { });
            return await GetResponseAsync<T>(httpResponse);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> GetAsync<T>(Uri uri)
        {
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


        #endregion
    }
}
