using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Users.Commands.Handlers
{
    public class UsersCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateUserCommand, CommandResult>,
        IRequestHandler<UpdateUserCommand, CommandResult>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctors


        public UsersCommandHandlers(IUserRepository userRepository, IDomainNotificationHandler notifications) : base(notifications)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request))
                return new CommandResult(ApplicationMessages.Create_Failed);

            var existUser = await _userRepository.GetByUserNameAsync(request.Email);
            if (existUser != null)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var user = new User(displayName: request.DisplayName, email: request.Email, userName: request.Email);
            if (!IsValid(user))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await _userRepository.CreateAsync(user);
          
            return new CommandResult(ApplicationMessages.Create_Success, user.Id.ToString());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!IsValid(request))
                return new CommandResult(ApplicationMessages.Update_Failed);


            var existUser = await _userRepository.GetByUserNameAsync(request.Email);
            if (existUser != null && existUser.Id.ToString() != request.Id)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed);
            }

            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);


            user.Update(request.DisplayName, request.Email, request.Email);
            if (!IsValid(user))
                return new CommandResult(ApplicationMessages.Update_Failed);

            await _userRepository.UpdateAsync(user);

            return new CommandResult(ApplicationMessages.Update_Success, user.Id.ToString());
        }


        #endregion

    }
}
