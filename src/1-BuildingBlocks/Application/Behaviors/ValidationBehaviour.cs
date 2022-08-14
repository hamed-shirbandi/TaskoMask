using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Extensions;
using TaskoMask.BuildingBlocks.Application.Notifications;

namespace TaskoMask.BuildingBlocks.Application.Behaviors
{
    /// <summary>
    /// automatic command validation by check annotation and fluent validation (if exist)
    /// </summary>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : BaseCommand
    {
        #region Fields

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IDomainNotificationHandler _notifications;

        #endregion

        #region Ctors

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, IDomainNotificationHandler notifications)
        {
            _validators = validators;
            _notifications = notifications;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Check fluent validations
            var isValidFluentValidation = !_validators.Any() || await ValidateFluentValidation(request, cancellationToken);

            //Check data annotation validations
            var isValidDataAnnotationValidation = ValidateDataAnnotationValidation(request);

            if (!isValidFluentValidation || !isValidDataAnnotationValidation)
                throw new Exceptions.ValidationException();

            return await next();

        }



        #endregion

        #region Private Methods




        /// <summary>
        /// 
        /// </summary>
        private bool ValidateDataAnnotationValidation(BaseCommand request)
        {
            //try validate data annotations 
            if (request.Validate(out var results))
                return true;

            // add data annotation errors to notifications
            foreach (var result in results)
                NotifyValidationError(request, result.ErrorMessage);

            return false;
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<bool> ValidateFluentValidation(TRequest request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            if (failures.Count == 0)
                return true;

            // add data annotation errors to notifications
            foreach (var failure in failures)
                NotifyValidationError(request, failure.ErrorMessage);

            return false;

        }



        /// <summary>
        /// add error to notifications
        /// </summary>
        protected void NotifyValidationError(BaseCommand request, string error)
        {
            _notifications.Add(request.GetType().Name, error);
        }


        #endregion
    }
}
