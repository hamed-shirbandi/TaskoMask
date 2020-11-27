using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Users;
using TaskoMask.Application.Resources;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Users
{
    public class UpdateUserCommandHandler : CommandHandler, IRequestHandler<UpdateUserCommand, Result<CommandResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMediator mediator) : base(mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<Result<CommandResult>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

           
            var user = await _userRepository.GetByIdAsync(request.Id);
            var exist = await _userRepository.ExistByNameAsync(user.Id, request.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            user.SetName(request.Name);
            user.SetDescription(request.Description);

            await _userRepository.UpdateAsync(user);
            return Result.Success(new CommandResult(user.Id, ApplicationMessages.Update_Success));

        }
    }
}
