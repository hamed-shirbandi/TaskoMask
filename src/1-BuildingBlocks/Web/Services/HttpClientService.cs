using System.Net.Http.Json;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Helpers;

namespace TaskoMask.BuildingBlocks.Web.Services;

/// <summary>
///
/// </summary>
public class HttpClientService : IHttpClientService
{
    #region Fields

    private HttpClient httpClient;
    private readonly IHttpClientFactory _clientFactory;

    #endregion

    #region Ctor



    /// <summary>
    ///
    /// </summary>
    public HttpClientService(IHttpClientFactory clientFactory)
    {
        httpClient = clientFactory.CreateClient();
        _clientFactory = clientFactory;
    }

    #endregion

    #region Public Methods



    /// <summary>
    ///
    /// </summary>
    public async Task<Result<TResult>> PostAsync<TResult>(string url, object input)
    {
        return await HttpClientRetryHelper.RetryAsync<TResult>(() => httpClient.PostAsJsonAsync(url, input));
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<TResult>> PutAsync<TResult>(string url, object input)
    {
        return await HttpClientRetryHelper.RetryAsync<TResult>(() => httpClient.PutAsJsonAsync(url, input));
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<TResult>> PutAsync<TResult>(string url)
    {
        return await HttpClientRetryHelper.RetryAsync<TResult>(() => httpClient.PutAsJsonAsync(url, new { }));
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<TResult>> DeleteAsync<TResult>(string url)
    {
        return await HttpClientRetryHelper.RetryAsync<TResult>(() => httpClient.DeleteAsync(url));
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<TResult>> GetAsync<TResult>(string url)
    {
        return await HttpClientRetryHelper.RetryAsync<TResult>(() => httpClient.GetAsync(url));
    }

    /// <summary>
    ///
    /// </summary>
    public Uri GetBaseAddress()
    {
        return httpClient.BaseAddress;
    }

    /// <summary>
    ///
    /// </summary>
    public void SetBaseAddress(string httpClientBaseAddress)
    {
        httpClient.BaseAddress = new Uri(httpClientBaseAddress);
    }

    /// <summary>
    ///
    /// </summary>
    public void SetHttpClient(string httpClientName)
    {
        httpClient = _clientFactory.CreateClient(httpClientName);
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
