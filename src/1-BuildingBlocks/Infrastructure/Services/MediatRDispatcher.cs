using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Infrastructure.Services;

/// <summary>
/// Implementation of IRequestDispatcher using MediatR.
/// </summary>
public class MediatRDispatcher : IRequestDispatcher
{
    #region Fields

    private readonly IMediator _mediator;
    private readonly INotificationService _notifications;

    #endregion

    #region Ctors

    public MediatRDispatcher(IMediator mediator, INotificationService notifications)
    {
        _mediator = mediator;
        _notifications = notifications;
    }

    #endregion

    #region Public Methods






    /// <summary>
    ///
    /// </summary>
    public async Task<Result<CommandResult>> SendCommand<TCommand>(TCommand cmd)
        where TCommand : BaseCommand
    {
        var result = await _mediator.Send(cmd);

        //get notification errors
        var errors = _notifications.GetList();

        //result is null when throw application or domain exception
        if (result == null)
            return Result.Failure<CommandResult>(errors);

        //if there is any notification error so result is failed
        if (errors.Count > 0)
            return Result.Failure<CommandResult>(errors, result.Message);

        return Result.Success(result, result.Message);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<TQueryResult>> SendQuery<TQueryResult>(BaseQuery<TQueryResult> query)
    {
        var result = await _mediator.Send(query);
        if (_notifications.HasAny())
            return Result.Failure<TQueryResult>(_notifications.GetList());

        return Result.Success(result);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task PublishEvent(DomainEvent @event)
    {
        await _mediator.Publish(@event);
    }

    #endregion

    #region Private Methods



    #endregion
}
