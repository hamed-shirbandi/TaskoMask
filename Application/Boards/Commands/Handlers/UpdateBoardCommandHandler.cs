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
        private readonly IBoardRepository _boardRepository;
        private readonly IMediator _mediator;

        public UpdateBoardCommandHandler(IBoardRepository boardRepository, IMediator mediator) : base(mediator)
        {
            _boardRepository = boardRepository;
            _mediator = mediator;
        }

        public async Task<Result<CommandResult>> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

           
            var board = await _boardRepository.GetByIdAsync(request.Id);

            var exist = await _boardRepository.ExistByNameAsync(board.Id, request.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

            board.SetName(request.Name);
            board.SetDescription(request.Description);

            await _boardRepository.UpdateAsync(board);
            return Result.Success(new CommandResult(board.Id, ApplicationMessages.Update_Success));

        }
    }
}
