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

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Projects.DeleteProject;

public class DeleteProjectUseCase : BaseCommandHandler, IRequestHandler<DeleteProjectRequest, CommandResult>
{
    #region Fields

    private readonly IOwnerAggregateRepository _ownerAggregateRepository;

    #endregion

    #region Ctors


    public DeleteProjectUseCase(
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
    public async Task<CommandResult> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
    {
        var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
        if (owner == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Project);

        var loadedVersion = owner.Version;

        owner.DeleteProject(request.Id);

        await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

        await PublishDomainEventsAsync(owner.DomainEvents);

        var projectDeleted = MapToProjectDeletedIntegrationEvent(owner.DomainEvents);

        await PublishIntegrationEventAsync(projectDeleted);

        return CommandResult.Create(ContractsMessages.Update_Success, request.Id);
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
