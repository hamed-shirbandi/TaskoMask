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
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Organizations;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.UpdateOrganization;

public class UpdateOrganizationUseCase : BaseCommandHandler, IRequestHandler<UpdateOrganizationRequest, CommandResult>
{
    #region Fields

    private readonly IOwnerAggregateRepository _ownerAggregateRepository;

    #endregion

    #region Ctors


    public UpdateOrganizationUseCase(
        IOwnerAggregateRepository ownerAggregateRepository,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher
    )
        : base(eventPublisher, requestDispatcher)
    {
        _ownerAggregateRepository = ownerAggregateRepository;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(UpdateOrganizationRequest request, CancellationToken cancellationToken)
    {
        var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.Id);
        if (owner == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Organization);

        var loadedVersion = owner.Version;

        owner.UpdateOrganization(request.Id, request.Name, request.Description);

        await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

        await PublishDomainEventsAsync(owner.DomainEvents);

        var organizationUpdated = MapToOrganizationUpdatedIntegrationEvent(owner.DomainEvents);

        await PublishIntegrationEventAsync(organizationUpdated);

        return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
    }

    #endregion

    #region Private Methods


    private OrganizationUpdated MapToOrganizationUpdatedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var organizationUpdatedDomainEvent = (OrganizationUpdatedEvent)
            domainEvents.FirstOrDefault(e => e.EventType == nameof(OrganizationUpdatedEvent));
        return new OrganizationUpdated(
            organizationUpdatedDomainEvent.Id,
            organizationUpdatedDomainEvent.Name,
            organizationUpdatedDomainEvent.Description
        );
    }

    #endregion
}
