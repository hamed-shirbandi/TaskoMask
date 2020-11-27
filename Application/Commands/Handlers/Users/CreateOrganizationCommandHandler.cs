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
    public class CreateUserCommandHandler : CommandHandler, IRequestHandler<CreateUserCommand, Result<CommandResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<Result<CommandResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            var user = _mapper.Map<User>(request);

            var exist = await _userRepository.ExistByNameAsync(user.Id,user.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            await _userRepository.CreateAsync(user);

            return Result.Success(new CommandResult(user.Id, ApplicationMessages.Create_Success));
        }
    }
}
