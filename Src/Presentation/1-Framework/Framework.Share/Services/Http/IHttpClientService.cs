

using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Services.Http
{
    public  interface IHttpClientService
    {
        Task<Result<TResult>> PostAsync<TResult>(Uri uri, object input);
        Task<Result<TResult>> PutAsync<TResult>(Uri uri, object input);
        Task<Result<TResult>> PutAsync<TResult>(Uri uri);
        Task<Result<TResult>> GetAsync<TResult>(Uri uri);
        Task<Result<TResult>> DeleteAsync<TResult>(Uri uri);
        Uri GetBaseAddress();
        void SetBaseAddress(string httpClientBaseAddress);
    }
}
