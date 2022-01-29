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
        public async Task<Result<TResult>> PostAsync<TResult>(Uri uri, object input)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(uri, input);
            return await GetResponseAsync<TResult>(httpResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> PutAsync<TResult>(Uri uri, object input)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(uri, input);
            return await GetResponseAsync<TResult>(httpResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> PutAsync<TResult>(Uri uri)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(uri, new { });
            return await GetResponseAsync<TResult>(httpResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> DeleteAsync<TResult>(Uri uri)
        {
            var httpResponse = await _httpClient.DeleteAsync(uri);
            return await GetResponseAsync<TResult>(httpResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> GetAsync<TResult>(Uri uri)
        {
            var httpResponse = await _httpClient.GetAsync(uri);
            return await GetResponseAsync<TResult>(httpResponse);
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
        private async Task<Result<TResult>> GetResponseAsync<TResult>(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
                return await httpResponse.Content.ReadFromJsonAsync<Result<TResult>>();

            return Result.Failure<TResult>(message: $"Request failed!");
        }


        #endregion
    }
}
