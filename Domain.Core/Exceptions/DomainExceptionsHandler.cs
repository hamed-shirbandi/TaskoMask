using TaskoMask.Domain.Core.Notifications;
using MediatR;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace TaskoMask.Domain.Core.Exceptions
{
    public class DomainExceptionsHandler<TRequest, TResponse, TException>
        : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : DomainException
    {
        #region Fields


        private readonly IMediator _mediator;


        #endregion


        #region Ctor


        public DomainExceptionsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        #endregion


        #region Handler


        public async Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            state.SetHandled(default);

            await _mediator.Publish(new DomainNotification("", exception.Message), cancellationToken);
        }


        #endregion
    }
}