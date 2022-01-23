using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.Share.Services;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class OrganizationCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateOrganizationCommand, CommandResult>,
        IRequestHandler<UpdateOrganizationCommand, CommandResult>,
         IRequestHandler<DeleteOrganizationCommand, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        #endregion

        #region Ctors

        public OrganizationCommandHandlers(IOwnerAggregateRepository ownerAggregateRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus, IAuthenticatedUserService authenticatedUserService) : base(notifications, inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
            _authenticatedUserService = authenticatedUserService;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByIdAsync(request.OwnerId);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);


            var organization = Organization.CreateOrganization(request.Name, request.Description);
            owner.CreateOrganization(organization);
            await _ownerAggregateRepository.UpdateAsync(owner);

            //TODO publish domain events

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

            owner.UpdateOrganization(request.Id, request.Name, request.Description, _authenticatedUserService);

            await _ownerAggregateRepository.UpdateAsync(owner);

            //TODO publish domain events

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

            owner.DeleteOrganization(request.Id,_authenticatedUserService);

            await _ownerAggregateRepository.UpdateAsync(owner);
            return new CommandResult(ApplicationMessages.Update_Success, request.Id);

        }

        #endregion

    }
}
