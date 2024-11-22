using System.Collections.Generic;
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
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Comments;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.UpdateComment;

public class UpdateCommentUseCase : BaseCommandHandler, IRequestHandler<UpdateCommentRequest, CommandResult>
{
    #region Fields

    private readonly ITaskAggregateRepository _taskAggregateRepository;

    #endregion

    #region Ctors


    public UpdateCommentUseCase(
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
    public async Task<CommandResult> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskAggregateRepository.GetByCommentIdAsync(request.Id);
        if (task == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Comment);

        var loadedVersion = task.Version;

        task.UpdateComment(request.Id, request.Content);

        await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

        await PublishDomainEventsAsync(task.DomainEvents);

        var commentUpdated = MapToCommentUpdatedIntegrationEvent(task.DomainEvents);

        await PublishIntegrationEventAsync(commentUpdated);

        return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
    }

    #endregion

    #region Private Methods


    private CommentUpdated MapToCommentUpdatedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var commentUpdatedDomainEvent = (CommentUpdatedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(CommentUpdatedEvent));
        return new CommentUpdated(commentUpdatedDomainEvent.Id, commentUpdatedDomainEvent.Content);
    }

    #endregion
}
