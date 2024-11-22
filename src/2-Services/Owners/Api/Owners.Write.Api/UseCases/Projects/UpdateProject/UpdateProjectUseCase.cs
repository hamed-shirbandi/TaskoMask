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
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Projects;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.UpdateProject;

public class UpdateProjectUseCase : BaseCommandHandler, IRequestHandler<UpdateProjectRequest, CommandResult>
{
    #region Fields

    private readonly IOwnerAggregateRepository _ownerAggregateRepository;

    #endregion

    #region Ctors


    public UpdateProjectUseCase(
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
    public async Task<CommandResult> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
    {
        var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
        if (owner == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Project);

        var loadedVersion = owner.Version;

        owner.UpdateProject(request.Id, request.Name, request.Description);

        await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

        await PublishDomainEventsAsync(owner.DomainEvents);

        var projectUpdated = MapToProjectUpdatedIntegrationEvent(owner.DomainEvents);

        await PublishIntegrationEventAsync(projectUpdated);

        return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
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
