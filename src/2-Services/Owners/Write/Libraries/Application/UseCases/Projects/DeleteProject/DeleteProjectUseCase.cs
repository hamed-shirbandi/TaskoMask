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
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Events.Projects;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Projects.DeleteProject
{
    public class DeleteProjectUseCase : BaseCommandHandler, IRequestHandler<DeleteProjectRequest, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;

        #endregion

        #region Ctors


        public DeleteProjectUseCase(IOwnerAggregateRepository ownerAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.DeleteProject(request.Id);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            var projectDeleted = MapToProjectDeletedIntegrationEvent(owner.DomainEvents);

            await PublishIntegrationEventAsync(projectDeleted);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private ProjectDeleted MapToProjectDeletedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var projectDeletedDomainEvent = (ProjectDeletedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(ProjectDeletedEvent));
            return new ProjectDeleted(projectDeletedDomainEvent.Id);
        }


        #endregion

    }
}
