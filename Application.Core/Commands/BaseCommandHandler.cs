using FluentValidation;
using FluentValidation.Results;
using TaskoMask.Application.Core.Extensions;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Core.Models;
using System.Linq;
using TaskoMask.Domain.Core.Helpers;

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
        /// validate both fluent and data annotation validation and add errors to notifications
        /// it uses when a command have both of above validation
        /// </summary>
        protected bool IsValid<T>(T request, AbstractValidator<T> validator) where T : BaseCommand
        {
            var validationResult = validator.Validate(request);
            NotifyFluentValidationErrors(request, validationResult);
            return IsValid(request);
        }



        /// <summary>
        /// validate data annotation validation and add errors to notifications
        /// it uses when command have not fluent validation
        /// </summary>
        protected bool IsValid(BaseCommand request)
        {
            NotifyDataAnnotationValidationErrors(request);
            return !_notifications.HasAny();
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



        /// <summary>
        /// 
        /// </summary>
        protected bool IsValid(BaseCommand request, Result result)
        {
            if (result.IsSuccess)
                return true;

            foreach (var error in result.Errors)
                NotifyValidationError(request, error);

            return false;
        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void NotifyFluentValidationErrors(BaseCommand request, ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                NotifyValidationError(request, error.ErrorMessage);
        }



        /// <summary>
        /// 
        /// </summary>
        private void NotifyDataAnnotationValidationErrors(BaseCommand request)
        {
            //try validate data annotations 
            if (request.Validate(out var results))
                return;

            //add data annotation errors to notifications
            foreach (var result in results)
                NotifyValidationError(request, result.ErrorMessage);
        }



        #endregion
    }
}