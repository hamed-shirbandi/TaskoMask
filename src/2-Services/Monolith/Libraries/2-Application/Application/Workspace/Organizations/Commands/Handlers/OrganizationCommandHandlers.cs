using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Monolith.Application.Commands.Handlers.Organizations
{
    public class OrganizationCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddOrganizationCommand, CommandResult>,
        IRequestHandler<UpdateOrganizationCommand, CommandResult>,
         IRequestHandler<DeleteOrganizationCommand, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        #endregion

        #region Ctors

        public OrganizationCommandHandlers(IOwnerAggregateRepository ownerAggregateRepository, IInMemoryBus inMemoryBus, IAuthenticatedUserService authenticatedUserService) : base(inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
            _authenticatedUserService = authenticatedUserService;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddOrganizationCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByIdAsync(request.OwnerId);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);


            var organization = Organization.CreateOrganization(request.Name, request.Description);
            owner.AddOrganization(organization);

            await _ownerAggregateRepository.UpdateAsync(owner);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Create_Success, organization.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.UpdateOrganization(request.Id, request.Name, request.Description, _authenticatedUserService);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.DeleteOrganization(request.Id, _authenticatedUserService);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);

        }

        #endregion

    }
}
