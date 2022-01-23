using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Workspace.Owners.Commands.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.ValueObjects;
using TaskoMask.Domain.WriteModel.Workspace.Owners.ValueObjects.Owners;

namespace TaskoMask.Application.Workspace.Owners.Commands.Handlers
{
    public class OwnerCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateOwnerCommand, CommandResult>,
        IRequestHandler<UpdateOwnerCommand, CommandResult>,
         IRequestHandler<DeleteOwnerCommand, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;

        #endregion

        #region Ctors


        public OwnerCommandHandlers(IOwnerAggregateRepository ownerAggregateRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = Owner.CreateOwner(request.Id,request.DisplayName, request.Email);

            await _ownerAggregateRepository.CreateAsync(owner);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ApplicationMessages.Create_Success, owner.Id.ToString());
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);


            owner.UpdateOwner(
                OwnerDisplayName.Create(request.DisplayName),
                OwnerEmail.Create(request.Email));

            await _ownerAggregateRepository.UpdateAsync(owner);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, owner.Id.ToString());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);

            owner.DeleteOwner();

            await _ownerAggregateRepository.UpdateAsync(owner);
            return new CommandResult(ApplicationMessages.Update_Success, request.Id);

        }


        #endregion

    }
}
