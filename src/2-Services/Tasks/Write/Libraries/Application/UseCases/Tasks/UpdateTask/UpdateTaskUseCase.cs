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

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.UpdateTask
{
    public class UpdateTaskUseCase : BaseCommandHandler, IRequestHandler<UpdateTaskRequest, CommandResult>

    {
        #region Fields

        private readonly ITaskAggregateRepository _taskAggregateRepository;
        private readonly ITaskValidatorService _taskValidatorService;

        #endregion

        #region Ctors


        public UpdateTaskUseCase(ITaskAggregateRepository taskAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus, ITaskValidatorService taskValidatorService) : base(messageBus, inMemoryBus)
        {
            _taskAggregateRepository = taskAggregateRepository;
            _taskValidatorService = taskValidatorService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.UpdateTask(request.Title, request.Description, _taskValidatorService);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            var taskUpdated = MapToTaskUpdatedIntegrationEvent(task.DomainEvents);

            await PublishIntegrationEventAsync(taskUpdated);

            return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private TaskUpdated MapToTaskUpdatedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var taskUpdatedDomainEvent = (TaskUpdatedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(TaskUpdatedEvent));
            return new TaskUpdated(taskUpdatedDomainEvent.Id, taskUpdatedDomainEvent.Title, taskUpdatedDomainEvent.Description);
        }


        #endregion
    }
}
