

using System.Net.Http.Json;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    public  class HttpClientServices: IHttpClientServices
    {
        private readonly HttpClient _httpClient;
        public HttpClientServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> PostAsync<T>(Uri uri, object input)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(uri, input);

            if (httpResponse.IsSuccessStatusCode)
                return await httpResponse.Content.ReadFromJsonAsync<Result<T>>();

            return Result.Failure<T>(message: $"Request failed!");
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<T>> GetAsync<T>(Uri uri)
        {
            var httpResponse = await _httpClient.GetAsync(uri);

            if (httpResponse.IsSuccessStatusCode)
                return await httpResponse.Content.ReadFromJsonAsync<Result<T>>();

            return Result.Failure<T>(message: $"Request failed!");
        }



        /// <summary>
        /// 
        /// </summary>
        public Uri GetBaseAddress()
        {
            return _httpClient.BaseAddress;
        }

    }
}
