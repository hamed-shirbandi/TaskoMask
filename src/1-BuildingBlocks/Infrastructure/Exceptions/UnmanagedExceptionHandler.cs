using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.BuildingBlocks.Infrastructure.Exceptions;

/// <summary>
/// Handle all unmanaged exceptions
/// </summary>
public class UnmanagedExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
    where TException : Exception
{
    #region Fields


    private readonly INotificationService _notifications;
    private readonly ILogger<UnmanagedExceptionHandler<TRequest, TResponse, TException>> _logger;

    #endregion

    #region Ctors


    public UnmanagedExceptionHandler(INotificationService notifications, ILogger<UnmanagedExceptionHandler<TRequest, TResponse, TException>> logger)
    {
        _notifications = notifications;
        _logger = logger;
    }

    #endregion

    #region Handler



    /// <summary>
    ///
    /// </summary>
    public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
    {
        _notifications.Add("Unknown exception happened");

        _logger.LogError(exception, $"request : {JsonSerializer.Serialize(request)}");

        state.SetHandled(default);

        return Task.CompletedTask;
    }

    #endregion
}
