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
    public class UpdateCardCommandHandler : BaseCommandHandler, IRequestHandler<UpdateCardCommand, Result<CommandResult>>
    {
        private readonly ICardRepository _projectRepository;
        private readonly IMediator _mediator;

        public UpdateCardCommandHandler(ICardRepository projectRepository, IMediator mediator) : base(mediator)
        {
            _projectRepository = projectRepository;
            _mediator = mediator;
        }

        public async Task<Result<CommandResult>> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                 await PublishValidationErrorsAsync(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

           
            var project = await _projectRepository.GetByIdAsync(request.Id);

            var exist = await _projectRepository.ExistByNameAsync(project.Id, request.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

            project.SetName(request.Name);
            project.SetDescription(request.Description);
            project.SetType(request.Type);

            await _projectRepository.UpdateAsync(project);
            return Result.Success(new CommandResult(project.Id, ApplicationMessages.Update_Success));

        }
    }
}
