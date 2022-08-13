﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Workspace.Owners.Commands.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Owners.ValueObjects.Owners;

namespace TaskoMask.Application.Workspace.Owners.Commands.Handlers
{
    public class OwnerCommandHandlers : BaseCommandHandler,
        IRequestHandler<RegisterOwnerCommand, CommandResult>,
        IRequestHandler<UpdateOwnerProfileCommand, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;

        #endregion

        #region Ctors


        public OwnerCommandHandlers(IOwnerAggregateRepository ownerAggregateRepository, IInMemoryBus inMemoryBus) : base(inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(RegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = Owner.RegisterOwner(request.Id,request.DisplayName, request.Email);

            await _ownerAggregateRepository.CreateAsync(owner);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ApplicationMessages.Create_Success, owner.Id.ToString());
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateOwnerProfileCommand request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);

            var loadedVersion = owner.Version;

            owner.UpdateOwnerProfile(
                OwnerDisplayName.Create(request.DisplayName),
                OwnerEmail.Create(request.Email));

            await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, owner.Id.ToString());
        }



        #endregion

    }
}
