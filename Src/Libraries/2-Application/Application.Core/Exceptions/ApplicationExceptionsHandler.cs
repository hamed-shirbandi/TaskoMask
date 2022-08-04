using TaskoMask.Application.Core.Notifications;
using MediatR;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Exceptions;

namespace TaskoMask.Application.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationExceptionsHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException> where TException : DomainException
    {
        #region Fields


        private readonly IDomainNotificationHandler _notifications;


        #endregion


        #region Ctors


        public ApplicationExceptionsHandler(IDomainNotificationHandler notifications)
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


            if (exceptionType == typeof(DomainException))
            {
                //log DomainException or ...
            }

            else if (exceptionType == typeof(ApplicationException))
            {
                //log ApplicationException or ...
            }

            else if (exceptionType == typeof(ValidationException))
            {
                //log ValidationException or ...
            }

            state.SetHandled(default);

            return Task.CompletedTask;
        }


        #endregion
    }
}