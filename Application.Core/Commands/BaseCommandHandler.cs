using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IMediator _mediator;


        #endregion


        #region constructors


        protected BaseCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }


        #endregion


        #region Protected Methods





        protected async Task PublishValidationErrorAsync(BaseCommand request)
        {
            foreach (var error in request.ValidationResult.Errors)
                await _mediator.Publish(new DomainNotification(request.GetType().Name, error.ErrorMessage));
        }



        protected async Task PublishValidationErrorAsync(DomainNotification notification)
        {
            await _mediator.Publish(notification);
        }



        #endregion
    }
}