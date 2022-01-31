using System.Net.Http.Json;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Helpers;

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
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.PostAsJsonAsync(uri, input)
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> PutAsync<TResult>(Uri uri, object input)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.PutAsJsonAsync(uri, input)
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> PutAsync<TResult>(Uri uri)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.PutAsJsonAsync(uri, new { })
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> DeleteAsync<TResult>(Uri uri)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.DeleteAsync(uri)
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> GetAsync<TResult>(Uri uri)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
            () => _httpClient.GetAsync(uri)
            );
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



        #endregion
    }
}
