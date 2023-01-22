using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Events.Projects;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject
{
    public class AddProjectUseCase : BaseCommandHandler, IRequestHandler<AddProjectRequest, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;

        #endregion

        #region Ctors


        public AddProjectUseCase(IOwnerAggregateRepository ownerAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus, inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddProjectRequest request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.OrganizationId);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Organization);

            var project = Project.Create(request.Name, request.Description);
            owner.AddProject(request.OrganizationId, project);

            await _ownerAggregateRepository.UpdateAsync(owner);

            await PublishDomainEventsAsync(owner.DomainEvents);

            var projectAdded = MapToProjectAddedIntegrationEvent(owner);

            await PublishIntegrationEventAsync(projectAdded);

            return CommandResult.Create(ContractsMessages.Create_Success, project.Id);
        }



        #endregion

        #region Private Methods


        private ProjectAdded MapToProjectAddedIntegrationEvent(Owner owner)
        {
            var projectAddedDomainEvent = (ProjectAddedEvent)owner.DomainEvents.FirstOrDefault(e => e.EventType == nameof(ProjectAddedEvent));

            var organization = owner.GetOrganizationById(projectAddedDomainEvent.OrganizationId);

            return new ProjectAdded(projectAddedDomainEvent.Id, projectAddedDomainEvent.Name, projectAddedDomainEvent.Description, projectAddedDomainEvent.OrganizationId, organization.Name.Value, projectAddedDomainEvent.OwnerId);
        }


        #endregion 

    }
}
