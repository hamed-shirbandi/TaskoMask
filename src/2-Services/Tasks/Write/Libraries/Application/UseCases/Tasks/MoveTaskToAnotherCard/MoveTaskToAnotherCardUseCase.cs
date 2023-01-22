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
using TaskoMask.Services.Tasks.Write.Domain.Services;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.MoveTaskToAnotherCard
{
    public class MoveTaskToAnotherCardUseCase : BaseCommandHandler, IRequestHandler<MoveTaskToAnotherCardRequest, CommandResult>

    {
        #region Fields

        private readonly ITaskAggregateRepository _taskAggregateRepository;
        private readonly ITaskValidatorService _taskValidatorService;

        #endregion

        #region Ctors


        public MoveTaskToAnotherCardUseCase(ITaskAggregateRepository taskAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus, ITaskValidatorService taskValidatorService) : base(messageBus, inMemoryBus)
        {
            _taskAggregateRepository = taskAggregateRepository;
            _taskValidatorService = taskValidatorService;
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
            var taskMovedToAnotherCardEvent = (TaskMovedToAnotherCardEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(TaskMovedToAnotherCardEvent));
            return new TaskMovedToAnotherCard(taskMovedToAnotherCardEvent.TaskId, taskMovedToAnotherCardEvent.CardId);
        }


        #endregion
    }
}
