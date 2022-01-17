﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Workspace.Members.Commands.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Workspace.Members.Data;
using TaskoMask.Domain.Workspace.Members.Entities;
using TaskoMask.Domain.Workspace.Members.ValueObjects;

namespace TaskoMask.Application.Workspace.Members.Commands.Handlers
{
    public class MemberCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateMemberCommand, CommandResult>,
        IRequestHandler<UpdateMemberCommand, CommandResult>
    {
        #region Fields

        private readonly IMemberAggregateRepository _memberRepository;

        #endregion

        #region Ctors


        public MemberCommandHandlers(IMemberAggregateRepository memberRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
        {
            _memberRepository = memberRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = Member.Create(request.Id,MemberDisplayName.Create(request.DisplayName), MemberEmail.Create(request.Email));

            await _memberRepository.CreateAsync(member);

            return new CommandResult(ApplicationMessages.Create_Success, member.Id.ToString());
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.Id);
            if (member == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Member);


            member.Update(
                MemberDisplayName.Create(request.DisplayName),
                MemberEmail.Create(request.Email));

            await _memberRepository.UpdateAsync(member);

            return new CommandResult(ApplicationMessages.Update_Success, member.Id.ToString());
        }


        #endregion

    }
}
