using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Boards.Commands.Handlers
{
    public class BoardsCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateBoardCommand, Result<CommandResult>>,
        IRequestHandler<UpdateBoardCommand, Result<CommandResult>>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BoardsCommandHandler(IBoardRepository boardRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _boardRepository = boardRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<Result<CommandResult>> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
               await PublishValidationErrorsAsync(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }


            var board = _mapper.Map<Board>(request);

            var exist = await _boardRepository.ExistByNameAsync(board.Id, board.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            await _boardRepository.CreateAsync(board);
            return Result.Success(new CommandResult(board.Id, ApplicationMessages.Create_Success));

        }
    
    
        public async Task<Result<CommandResult>> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                 await PublishValidationErrorsAsync(request);
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
