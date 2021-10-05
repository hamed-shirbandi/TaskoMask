using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Team.Members.Commands.Models;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Application.Team.Members.Commands.Handlers
{
    public class MemberCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateMemberCommand, CommandResult>,
        IRequestHandler<UpdateMemberCommand, CommandResult>
    {
        #region Fields

        private readonly IMemberRepository _memberRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors


        public MemberCommandHandlers(IMemberRepository memberRepository, IDomainNotificationHandler notifications, IEncryptionService encryptionService, IInMemoryBus _inMemoryBus) : base(notifications, _inMemoryBus)
        {
            _memberRepository = memberRepository;
            _encryptionService = encryptionService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var existMember = await _memberRepository.GetByUserNameAsync(request.Email);
            if (existMember != null)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var member = new Member(displayName: request.DisplayName, email: request.Email, password: request.Password, encryptionService: _encryptionService);
            if (!IsValid(member))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await PublishDomainEventsAsync(member.DomainEvents);

            await _memberRepository.CreateAsync(member);

            return new CommandResult(ApplicationMessages.Create_Success, member.Id.ToString());
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var existMember = await _memberRepository.GetByUserNameAsync(request.Email);
            if (existMember != null && existMember.Id.ToString() != request.Id)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed);
            }

            var member = await _memberRepository.GetByIdAsync(request.Id);
            if (member == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Member);


            member.Update(request.DisplayName, request.Email, request.Email);
            if (!IsValid(member))
                return new CommandResult(ApplicationMessages.Update_Failed);

            await _memberRepository.UpdateAsync(member);

            return new CommandResult(ApplicationMessages.Update_Success, member.Id.ToString());
        }


        #endregion

    }
}
