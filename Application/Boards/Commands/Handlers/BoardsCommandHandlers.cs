using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;

namespace TaskoMask.Application.Boards.Commands.Handlers
{
    public class BoardsCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateBoardCommand, CommandResult>,
        IRequestHandler<UpdateBoardCommand, CommandResult>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardsCommandHandlers(IBoardRepository boardRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _boardRepository = boardRepository;
            _mapper = mapper;
        }


        public async Task<CommandResult> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }


            var board = _mapper.Map<Board>(request);

            //TODO check by repository
            var hasProjectId = true;
            if (!hasProjectId)
                throw new ApplicationException(string.Format(ApplicationMessages.Invalid_ForeignKey,nameof(request.ProjectId)));

            //TODO move this validations type to domain
            var exist = await _boardRepository.ExistByNameAsync(board.Id, board.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Create_Failed);
            }


            await _boardRepository.CreateAsync(board);
            return new CommandResult(ApplicationMessages.Create_Success, board.Id);

        }


        public async Task<CommandResult> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }


            var board = await _boardRepository.GetByIdAsync(request.Id);

            var exist = await _boardRepository.ExistByNameAsync(board.Id, request.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            board.SetName(request.Name);
            board.SetDescription(request.Description);

            await _boardRepository.UpdateAsync(board);
            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }

    }
}
