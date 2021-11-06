using MediatR;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Domain.Core.Commands
{
    public class CommandHandler
    {
        private readonly IMediator _mediator;

        public CommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                _mediator.Publish(new DomainNotification(error.PropertyName, error.ErrorMessage));
        }

    }
}