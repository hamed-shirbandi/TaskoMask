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
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Organizations;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.AddOrganization;

public class AddOrganizationUseCase : BaseCommandHandler, IRequestHandler<AddOrganizationRequest, CommandResult>
{
    #region Fields

    private readonly IOwnerAggregateRepository _ownerAggregateRepository;

    #endregion

    #region Ctors


    public AddOrganizationUseCase(
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
    public async Task<CommandResult> Handle(AddOrganizationRequest request, CancellationToken cancellationToken)
    {
        var owner = await _ownerAggregateRepository.GetByIdAsync(request.OwnerId);
        if (owner == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

        var organization = Organization.CreateOrganization(request.Name, request.Description);

        owner.AddOrganization(organization);

        await _ownerAggregateRepository.UpdateAsync(owner);

        await PublishDomainEventsAsync(owner.DomainEvents);

        var organizationAdded = MapToOrganizationAddedIntegrationEvent(owner.DomainEvents);

        await PublishIntegrationEventAsync(organizationAdded);

        return CommandResult.Create(ContractsMessages.Create_Success, organization.Id);
    }

    #endregion

    #region Private Methods


    private OrganizationAdded MapToOrganizationAddedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
    {
        var organizationAddedDomainEvent = (OrganizationAddedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(OrganizationAddedEvent));
        return new OrganizationAdded(
            organizationAddedDomainEvent.Id,
            organizationAddedDomainEvent.Name,
            organizationAddedDomainEvent.Description,
            organizationAddedDomainEvent.OwnerId
        );
    }

    #endregion
}
