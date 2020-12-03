using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Boards;
using TaskoMask.Application.Resources;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Boards
{
    public class UpdateBoardCommandHandler : CommandHandler, IRequestHandler<UpdateBoardCommand, Result<CommandResult>>
    {
        private readonly IBoardRepository _projectRepository;
        private readonly IMediator _mediator;

        public UpdateBoardCommandHandler(IBoardRepository projectRepository, IMediator mediator) : base(mediator)
        {
            _projectRepository = projectRepository;
            _mediator = mediator;
        }

        public async Task<Result<CommandResult>> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
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

            await _projectRepository.UpdateAsync(project);
            return Result.Success(new CommandResult(project.Id, ApplicationMessages.Update_Success));

        }
    }
}
