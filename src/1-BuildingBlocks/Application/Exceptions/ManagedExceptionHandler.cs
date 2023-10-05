using TaskoMask.BuildingBlocks.Application.Notifications;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TaskoMask.BuildingBlocks.Contracts.Exceptions;
using System.Text.Json;

namespace TaskoMask.BuildingBlocks.Application.Exceptions
{
    /// <summary>
    /// Handle all managed exceptions (DomainException,ApplicationException,ValidationException)
    /// </summary>
    public class ManagedExceptionHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException> where TException : ManagedException
    {
        #region Fields


        private readonly INotificationHandler _notifications;
        private readonly ILogger<ManagedExceptionHandler<TRequest, TResponse, TException>> _logger;

        #endregion

        #region Ctors


        public ManagedExceptionHandler(INotificationHandler notifications, ILogger<ManagedExceptionHandler<TRequest, TResponse, TException>> logger)
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
            var exceptionType = exception.GetType();

            //notify exception message if any
            if (!string.IsNullOrEmpty(exception.Message))
                _notifications.Add(exceptionType.Name, exception.Message);

            _logger.LogWarning(exception, $"request : {JsonSerializer.Serialize(request)}");

            state.SetHandled(default);

            return Task.CompletedTask;
        }


        #endregion
    }
}