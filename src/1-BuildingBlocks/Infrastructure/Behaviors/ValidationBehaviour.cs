using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Extensions;

namespace TaskoMask.BuildingBlocks.Infrastructure.Behaviors;

/// <summary>
/// Automatic validation by checking data annotation and fluent validations (if any)
/// </summary>
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : BaseCommand
{
    #region Fields

    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly INotificationService _notifications;

    #endregion

    #region Ctors

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, INotificationService notifications)
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
            throw new Application.Exceptions.ValidationException();

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
            NotifyValidationError(result.ErrorMessage);

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
            NotifyValidationError(failure.ErrorMessage);

        return false;
    }

    /// <summary>
    /// add error to notifications
    /// </summary>
    protected void NotifyValidationError(string error)
    {
        _notifications.Add(error);
    }

    #endregion
}
