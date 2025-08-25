﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Data;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.MoveTaskToAnotherCard;

public class MoveTaskToAnotherCardUseCase : BaseCommandHandler, IRequestHandler<MoveTaskToAnotherCardRequest, CommandResult>
{
    #region Fields

    private readonly ITaskAggregateRepository _taskAggregateRepository;

    #endregion

    #region Ctors


    public MoveTaskToAnotherCardUseCase(
        ITaskAggregateRepository taskAggregateRepository,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher
    )
        : base(eventPublisher, requestDispatcher)
    {
        _taskAggregateRepository = taskAggregateRepository;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(MoveTaskToAnotherCardRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskAggregateRepository.GetByIdAsync(request.TaskId);
        if (task == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

        if (task.CardId.Value == request.CardId)
            return CommandResult.Create(ContractsMessages.Update_Success, request.TaskId);

        var loadedVersion = task.Version;

        task.MoveTaskToAnotherCard(request.CardId);

        await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

        await PublishDomainEventsAsync(task.DomainEvents);

        var taskMovedToAnotherCard = MapToTaskMovedToAnotherCardIntegrationEvent(task.DomainEvents);

        await PublishIntegrationEventAsync(taskMovedToAnotherCard);

        return CommandResult.Create(ContractsMessages.Update_Success, request.TaskId);
    }

    #endregion

    #region Private Methods


    private TaskMovedToAnotherCard MapToTaskMovedToAnotherCardIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var taskMovedToAnotherCardEvent = (TaskMovedToAnotherCardEvent)
            domainEvents.FirstOrDefault(e => e.EventType == nameof(TaskMovedToAnotherCardEvent));
        return new TaskMovedToAnotherCard(taskMovedToAnotherCardEvent.TaskId, taskMovedToAnotherCardEvent.CardId);
    }

    #endregion
}
