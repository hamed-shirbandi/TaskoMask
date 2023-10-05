using TaskoMask.BuildingBlocks.Application.Notifications;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

namespace TaskoMask.BuildingBlocks.Application.Exceptions
{
    /// <summary>
    /// Handle all unmanaged exceptions
    /// </summary>
    public class UnmanagedExceptionHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException> where TException : Exception
    {
        #region Fields


        private readonly INotificationHandler _notifications;
        private readonly ILogger<UnmanagedExceptionHandler<TRequest, TResponse, TException>> _logger;

        #endregion

        #region Ctors


        public UnmanagedExceptionHandler(INotificationHandler notifications, ILogger<UnmanagedExceptionHandler<TRequest, TResponse, TException>> logger)
        {
            _notifications = notifications;
            this._logger = logger;
        }


        #endregion

        #region Handler



        /// <summary>
        /// 
        /// </summary>
        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            _notifications.Add("Unknown Exception", "Unknown exception happened");

            _logger.LogError(exception, $"request : {JsonSerializer.Serialize(request)}");

            state.SetHandled(default);

            return Task.CompletedTask;
        }


        #endregion
    }
}