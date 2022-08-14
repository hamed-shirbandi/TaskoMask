

using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Share.Services.Http
{
    public  interface IHttpClientService
    {
        Task<Result<TResult>> PostAsync<TResult>(string url, object input);
        Task<Result<TResult>> PutAsync<TResult>(string url, object input);
        Task<Result<TResult>> PutAsync<TResult>(string url);
        Task<Result<TResult>> GetAsync<TResult>(string url);
        Task<Result<TResult>> DeleteAsync<TResult>(string url);
        Uri GetBaseAddress();
        void SetBaseAddress(string httpClientBaseAddress);
    }
}
