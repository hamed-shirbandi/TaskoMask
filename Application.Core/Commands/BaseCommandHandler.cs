using MediatR;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IMediator _mediator;
        protected readonly DomainNotificationHandler _notifications;


        #endregion


        #region constructors


        protected BaseCommandHandler(IMediator mediator, INotificationHandler<DomainNotification> notifications)
        {
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;

        }


        #endregion


        #region Protected Methods





        protected async Task PublishValidationErrorAsync(BaseCommand request)
        {
            foreach (var error in request.ValidationResult.Errors)
                await _mediator.Publish(new DomainNotification(request.GetType().Name, error.ErrorMessage));
        }



        protected async Task PublishValidationErrorAsync(BaseCommand request,string error)
        {
            await _mediator.Publish(new DomainNotification(request.GetType().Name, error));
        }




        #endregion
    }
}