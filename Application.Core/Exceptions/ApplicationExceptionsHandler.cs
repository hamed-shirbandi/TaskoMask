using TaskoMask.Application.Core.Notifications;
using MediatR;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Exceptions;

namespace TaskoMask.Application.Core.Exceptions
{
    public class ApplicationExceptionsHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException> where TException : DomainException
    {
        #region Fields


        private readonly IDomainNotificationHandler _notifications;


        #endregion


        #region Ctor


        public ApplicationExceptionsHandler(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }


        #endregion


        #region Handler


        public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            var exceptionType = exception.GetType();

            if (exceptionType == typeof(DomainException))
            {
                //log DomainException or ...
            }

            if (exceptionType == typeof(ApplicationException))
            {
                //log ApplicationException or ...
            }

            state.SetHandled(default);

            _notifications.Add(exceptionType.Name, exception.Message);
        }


        #endregion
    }
}