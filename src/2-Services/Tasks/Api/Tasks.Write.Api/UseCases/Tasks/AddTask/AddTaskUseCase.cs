using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Data;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Tasks;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Services;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.AddTask;

public class AddTaskUseCase : BaseCommandHandler, IRequestHandler<AddTaskRequest, CommandResult>
{
    #region Fields

    private readonly ITaskAggregateRepository _taskAggregateRepository;
    private readonly ITaskValidatorService _taskValidatorService;

    #endregion

    #region Ctors


    public AddTaskUseCase(
        ITaskAggregateRepository taskAggregateRepository,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher,
        ITaskValidatorService taskValidatorService
    )
        : base(eventPublisher, requestDispatcher)
    {
        _taskAggregateRepository = taskAggregateRepository;
        _taskValidatorService = taskValidatorService;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(AddTaskRequest request, CancellationToken cancellationToken)
    {
        var task = Domain.Tasks.Entities.Task.AddTask(request.Title, request.Description, request.CardId, request.BoardId, _taskValidatorService);

        await _taskAggregateRepository.AddAsync(task);

        await PublishDomainEventsAsync(task.DomainEvents);

        var taskAdded = MapToTaskAddedIntegrationEvent(task.DomainEvents);

        await PublishIntegrationEventAsync(taskAdded);

        return CommandResult.Create(ContractsMessages.Create_Success, task.Id);
    }

    #endregion

    #region Private Methods


    private TaskAdded MapToTaskAddedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var taskAddedDomainEvent = (TaskAddedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(TaskAddedEvent));
        return new TaskAdded(
            taskAddedDomainEvent.Id,
            taskAddedDomainEvent.Title,
            taskAddedDomainEvent.Description,
            taskAddedDomainEvent.CardId,
            taskAddedDomainEvent.BoardId
        );
    }

    #endregion
}
