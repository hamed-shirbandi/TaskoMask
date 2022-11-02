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
using TaskoMask.Services.Owners.Write.Domain.Events.Organizations;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.DeleteOrganization
{
    public class DeleteOrganizationUseCase : BaseCommandHandler, IRequestHandler<DeleteOrganizationRequest, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;
        private readonly IOwnerValidatorService _ownerValidatorService;

        #endregion

        #region Ctors


        public DeleteOrganizationUseCase(IOwnerAggregateRepository ownerAggregateRepository, IMessageBus messageBus, IOwnerValidatorService ownerValidatorService, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
            _ownerValidatorService = ownerValidatorService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteOrganizationRequest request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.DeleteOrganization(request.Id);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            var organizationDeleted = MapOrganizationDeletedIntegrationEvent(owner.DomainEvents);

            await PublishIntegrationEventAsync(organizationDeleted);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);
        }

        #endregion

        #region Private Methods


        private OrganizationDeleted MapOrganizationDeletedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var organizationDeletedDomainEvent = (OrganizationDeletedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(OrganizationDeletedEvent));
            return new OrganizationDeleted(organizationDeletedDomainEvent.Id);
        }


        #endregion

    }
}
