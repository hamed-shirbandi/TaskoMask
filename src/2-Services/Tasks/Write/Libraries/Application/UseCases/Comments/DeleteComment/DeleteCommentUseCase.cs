using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Write.Domain.Data;
using TaskoMask.Services.Tasks.Write.Domain.Events.Comments;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Comments.DeleteComment
{
    public class DeleteCommentUseCase : BaseCommandHandler, IRequestHandler<DeleteCommentRequest, CommandResult>

    {
        #region Fields

        private readonly ITaskAggregateRepository _taskAggregateRepository;

        #endregion

        #region Ctors


        public DeleteCommentUseCase(ITaskAggregateRepository taskAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _taskAggregateRepository = taskAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByCommentIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Card);

            var loadedVersion = task.Version;

            task.DeleteComment(request.Id);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            var commentDeleted = MapToCommentDeletedIntegrationEvent(task.DomainEvents);

            await PublishIntegrationEventAsync(commentDeleted);

            return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private CommentDeleted MapToCommentDeletedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var commentDeletedDomainEvent = (CommentDeletedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(CommentDeletedEvent));
            return new CommentDeleted(commentDeletedDomainEvent.Id);
        }


        #endregion

    }
}
