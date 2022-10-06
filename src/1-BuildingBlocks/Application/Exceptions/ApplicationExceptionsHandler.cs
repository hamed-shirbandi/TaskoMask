using TaskoMask.BuildingBlocks.Application.Notifications;
using MediatR;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Exceptions;

namespace TaskoMask.BuildingBlocks.Application.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationExceptionsHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException> where TException : DomainException
    {
        #region Fields


        private readonly INotificationHandler _notifications;


        #endregion


        #region Ctors


        public ApplicationExceptionsHandler(INotificationHandler notifications)
        {
            _notifications = notifications;
        }


        #endregion


        #region Handler



        /// <summary>
        /// 
        /// </summary>
        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            var exceptionType = exception.GetType();

            //notification exception error message if exist
            if (!string.IsNullOrEmpty(exception.Message))
                _notifications.Add(exceptionType.Name, exception.Message);


            if (exceptionType == typeof(ApplicationException))
            {
                //log ApplicationException ...
            }

            else if (exceptionType == typeof(ValidationException))
            {
                //log ValidationException ...
            }

            else if (exceptionType == typeof(DomainException))
            {
                //log DomainException ...
            }

            state.SetHandled(default);

            return Task.CompletedTask;
        }


        #endregion
    }
}