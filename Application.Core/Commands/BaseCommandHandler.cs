using FluentValidation;
using FluentValidation.Results;
using TaskoMask.Application.Core.Extensions;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Core.Models;
using System.Linq;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Core.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseCommandHandler
    {
        #region Fields


        private readonly IDomainNotificationHandler _notifications;


        #endregion

        #region Ctors


        protected BaseCommandHandler(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }


        #endregion

        #region Protected Methods
         

        /// <summary>
        /// add error to notifications
        /// </summary>
        protected void NotifyValidationError(BaseCommand request, string error)
        {
            _notifications.Add(request.GetType().Name, error);
        }





        /// <summary>
        /// 
        /// </summary>
        protected bool IsValid(BaseEntity entity)
        {
            if (!entity.ValidationErrors.Any())
                return true;

            _notifications.AddRange(entity.ValidationErrors.ToList());
            return false;
        }



        ///// <summary>
        ///// 
        ///// </summary>
        //protected bool IsValid(BaseCommand request, Result result)
        //{
        //    if (result.IsSuccess)
        //        return true;

        //    foreach (var error in result.Errors)
        //        NotifyValidationError(request, error);

        //    return false;
        //}


        #endregion

        #region Private Methods



      


        #endregion
    }
}