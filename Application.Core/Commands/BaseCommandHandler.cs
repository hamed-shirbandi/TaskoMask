using MediatR;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Commands
{
    public abstract class BaseCommandHandler
    {
        #region Fields


        protected readonly IDomainNotificationHandler _notifications;


        #endregion


        #region constructors


        protected BaseCommandHandler(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }


        #endregion


        #region Protected Methods





        protected void PublishValidationError(BaseCommand request)
        {
            foreach (var error in request.ValidationResult.Errors)
                _notifications.Add(request.GetType().Name, error.ErrorMessage);
        }



        protected void PublishValidationError(BaseCommand request, string error)
        {
            _notifications.Add(request.GetType().Name, error);
        }




        #endregion
    }
}