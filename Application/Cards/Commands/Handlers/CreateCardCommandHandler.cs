using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Cards.Commands.Handlers
{
    public class CreateCardCommandHandler : BaseCommandHandler, IRequestHandler<CreateCardCommand, Result<CommandResult>>
    {
        private readonly ICardRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCardCommandHandler(ICardRepository projectRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _projectRepository = projectRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<Result<CommandResult>> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                 await PublishValidationErrorsAsync(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }


            var project = _mapper.Map<Card>(request);

            var exist = await _projectRepository.ExistByNameAsync(project.Id, project.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            await _projectRepository.CreateAsync(project);
            return Result.Success(new CommandResult(project.Id, ApplicationMessages.Create_Success));

        }
    }
}
