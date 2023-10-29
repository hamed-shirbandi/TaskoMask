using System.Net.Http.Json;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Web.Helpers;

public static class HttpClientRetryHelper
{
    /// <summary>
    ///
    /// </summary>
    public static async Task<Result<TResult>> RetryAsync<TResult>(
        Func<Task<HttpResponseMessage>> sendHttpRequestAsync,
        int maxRetryCount = 3,
        int retryTimeoutInMilliseconds = 200
    )
    {
        var errors = new List<string> { };
        var retryCount = 1;

        if (sendHttpRequestAsync != null)
        {
            while (retryCount <= maxRetryCount)
            {
                try
                {
                    var httpResponse = await sendHttpRequestAsync();
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        return await httpResponse.Content.ReadFromJsonAsync<Result<TResult>>();
                    }
                    else
                    {
                        errors.Add("Response was not success");
                        break;
                    }
                }
                catch
                {
                    errors.Add($"Retry number {retryCount} failed");

                    if (retryCount <= maxRetryCount)
                        await Task.Delay(retryTimeoutInMilliseconds);

                    ++retryCount;
                }
            }
        }

        return Result.Failure<TResult>(message: $"Request failed!", errors: errors);
    }
}
