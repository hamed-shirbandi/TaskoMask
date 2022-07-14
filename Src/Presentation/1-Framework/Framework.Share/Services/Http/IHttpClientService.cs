

using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Services.Http
{
    public  interface IHttpClientService
    {
        Task<Result<TResult>> PostAsync<TResult>(string uri, object input);
        Task<Result<TResult>> PutAsync<TResult>(string uri, object input);
        Task<Result<TResult>> PutAsync<TResult>(string uri);
        Task<Result<TResult>> GetAsync<TResult>(string uri);
        Task<Result<TResult>> DeleteAsync<TResult>(string uri);
        Uri GetBaseAddress();
        void SetBaseAddress(string httpClientBaseAddress);
    }
}
