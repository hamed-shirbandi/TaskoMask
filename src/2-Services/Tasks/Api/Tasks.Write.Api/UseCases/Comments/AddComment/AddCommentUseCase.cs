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
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Events.Comments;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Comments.AddComment;

public class AddCommentUseCase : BaseCommandHandler, IRequestHandler<AddCommentRequest, CommandResult>
{
    #region Fields

    private readonly ITaskAggregateRepository _taskAggregateRepository;

    #endregion

    #region Ctors


    public AddCommentUseCase(ITaskAggregateRepository taskAggregateRepository, IEventPublisher eventPublisher, IRequestDispatcher requestDispatcher)
        : base(eventPublisher, requestDispatcher)
    {
        _taskAggregateRepository = taskAggregateRepository;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(AddCommentRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskAggregateRepository.GetByIdAsync(request.TaskId);
        if (task == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

        var comment = Comment.Create(request.Content);
        task.AddComment(comment);

        await _taskAggregateRepository.UpdateAsync(task);

        await PublishDomainEventsAsync(task.DomainEvents);

        var commentAdded = MapToCommentAddedIntegrationEvent(task.DomainEvents);

        await PublishIntegrationEventAsync(commentAdded);

        return CommandResult.Create(ContractsMessages.Create_Success, comment.Id);
    }

    #endregion

    #region Private Methods


    private CommentAdded MapToCommentAddedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var commentAddedDomainEvent = (CommentAddedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(CommentAddedEvent));

        return new CommentAdded(commentAddedDomainEvent.Id, commentAddedDomainEvent.Content, commentAddedDomainEvent.TaskId);
    }

    #endregion
}
