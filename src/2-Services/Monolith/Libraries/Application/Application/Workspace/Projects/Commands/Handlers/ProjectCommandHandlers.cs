using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Handlers
{
    public class ProjectCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddProjectCommand, CommandResult>,
         IRequestHandler<UpdateProjectCommand, CommandResult>,
         IRequestHandler<DeleteProjectCommand, CommandResult>
    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;


        #endregion

        #region Ctors

        public ProjectCommandHandlers(IOwnerAggregateRepository ownerAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus) : base(messageBus,inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.OrganizationId);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var project = Project.Create(request.Name, request.Description);
            owner.AddProject(request.OrganizationId, project);

            await _ownerAggregateRepository.UpdateAsync(owner);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Create_Success, project.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.UpdateProject(request.Id, request.Name, request.Description);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByProjectIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.DeleteProject(request.Id);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);

        }



        #endregion

    }
}
