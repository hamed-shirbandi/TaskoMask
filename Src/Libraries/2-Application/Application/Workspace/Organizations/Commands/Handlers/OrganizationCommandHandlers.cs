using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class OrganizationCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddOrganizationToOwnerWorkspaceCommand, CommandResult>,
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
        public async Task<CommandResult> Handle(AddOrganizationToOwnerWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByIdAsync(request.OwnerId);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);


            var organization = Organization.CreateOrganization(request.Name, request.Description);
            owner.AddOrganizationToOwnerWorkspace(organization);

            await _ownerAggregateRepository.UpdateAsync(owner);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ApplicationMessages.Create_Success, organization.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.UpdateOrganization(request.Id, request.Name, request.Description, _authenticatedUserService);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, request.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.DeleteOrganization(request.Id, _authenticatedUserService);

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, request.Id);

        }

        #endregion

    }
}
