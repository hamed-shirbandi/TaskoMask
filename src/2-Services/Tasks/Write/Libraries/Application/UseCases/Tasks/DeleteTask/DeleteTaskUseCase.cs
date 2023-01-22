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
using TaskoMask.Services.Tasks.Write.Domain.Events.Tasks;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.DeleteTask
{
    public class DeleteTaskUseCase : BaseCommandHandler, IRequestHandler<DeleteTaskRequest, CommandResult>

    {
        #region Fields

        private readonly ITaskAggregateRepository _taskAggregateRepository;

        #endregion

        #region Ctors


        public DeleteTaskUseCase(ITaskAggregateRepository taskAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _taskAggregateRepository = taskAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            task.DeleteTask();

            await _taskAggregateRepository.DeleteAsync(task.Id);

            await PublishDomainEventsAsync(task.DomainEvents);

            var taskDeleted = MapToTaskDeletedIntegrationEvent(task.DomainEvents);

            await PublishIntegrationEventAsync(taskDeleted);

            return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private TaskDeleted MapToTaskDeletedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var taskDeletedDomainEvent = (TaskDeletedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(TaskDeletedEvent));
            return new TaskDeleted(taskDeletedDomainEvent.Id);
        }


        #endregion

    }
}
