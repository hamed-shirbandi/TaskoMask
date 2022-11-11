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
using TaskoMask.Services.Owners.Write.Domain.ValueObjects.Owners;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Projects.UpdateProject
{
    public class UpdateProjectUseCase : BaseCommandHandler, IRequestHandler<UpdateProjectRequest, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;

        #endregion

        #region Ctors


        public UpdateProjectUseCase(IOwnerAggregateRepository ownerAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.UpdateProject(request.Id, request.Name, request.Description);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            var projectUpdated = MapToProjectUpdatedIntegrationEvent(owner.DomainEvents);

            await PublishIntegrationEventAsync(projectUpdated);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private ProjectUpdated MapToProjectUpdatedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var projectUpdatedDomainEvent = (ProjectUpdatedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(ProjectUpdatedEvent));
            return new ProjectUpdated(projectUpdatedDomainEvent.Id, projectUpdatedDomainEvent.Name, projectUpdatedDomainEvent.Description);
        }



        #endregion

    }
}
