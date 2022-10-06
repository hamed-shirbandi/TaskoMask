using System.Net.Http.Json;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Helpers;

namespace TaskoMask.BuildingBlocks.Web.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpClientService : IHttpClientService
    {
        #region Fields

        private HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;

        #endregion

        #region Ctor



        /// <summary>
        /// 
        /// </summary>
        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();
            _clientFactory = clientFactory;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> PostAsync<TResult>(string url, object input)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.PostAsJsonAsync(url, input)
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> PutAsync<TResult>(string url, object input)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.PutAsJsonAsync(url, input)
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> PutAsync<TResult>(string url)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.PutAsJsonAsync(url, new { })
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> DeleteAsync<TResult>(string url)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
                () => _httpClient.DeleteAsync(url)
                );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TResult>> GetAsync<TResult>(string url)
        {
            return await HttpClientRetryHelper.RetryAsync<TResult>(
            () => _httpClient.GetAsync(url)
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



        /// <summary>
        /// 
        /// </summary>
        public void SetHttpClient(string httpClientName)
        {
            _httpClient = _clientFactory.CreateClient(httpClientName);
        }



        /// <summary>
        /// 
        /// </summary>
        public IHttpClientService WithNamedClient(string httpClientName)
        {
            SetHttpClient(httpClientName);
            return this;
        }



        #endregion

        #region Private Methods



        #endregion
    }
}
