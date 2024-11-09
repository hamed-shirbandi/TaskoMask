using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Web.MVC.Exceptions;

public class HttpGlobalExceptionHandler : IMiddleware
{
    private readonly ILogger<HttpGlobalExceptionHandler> _logger;

    public HttpGlobalExceptionHandler(ILogger<HttpGlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            await HandleExceptionAsync(context);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var result = Result.Failure();
        await httpContext.Response.WriteAsJsonAsync(result);
    }
}
