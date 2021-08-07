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
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Application.Boards.Commands.Handlers
{
    public class BoardsCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateBoardCommand, CommandResult>,
        IRequestHandler<UpdateBoardCommand, CommandResult>
    {
        private readonly IBoardRepository _boardRepository;

        public BoardsCommandHandlers(IBoardRepository boardRepository,IMediator mediator, IDomainNotificationHandler notifications) : base(mediator, notifications)
        {
            _boardRepository = boardRepository;
        }


        public async Task<CommandResult> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                PublishValidationError(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }


            //TODO move this validations type in all handlers to domain
            //TODO check by repository
            var existProjectId = true;
            if (!existProjectId)
                throw new ApplicationException(string.Format(ApplicationMessages.Invalid_ForeignKey,nameof(request.ProjectId)));

            //TODO move this validations type in all handlers to domain
            var exist = await _boardRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                PublishValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var board = new Board(name:request.Name,description:request.Description,projectId:request.ProjectId);
            if (_notifications.HasAny())
                return new CommandResult(ApplicationMessages.Create_Failed);


            await _boardRepository.CreateAsync(board);
            return new CommandResult(ApplicationMessages.Create_Success, board.Id);

        }


        public async Task<CommandResult> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                PublishValidationError(request);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }


            var board = await _boardRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist,  DomainMetadata.Board);

            var exist = await _boardRepository.ExistByNameAsync(board.Id, request.Name);
            if (exist)
            {
                PublishValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            board.Update(request.Name, request.Description);

            if (_notifications.HasAny())
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _boardRepository.UpdateAsync(board);
            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }

    }
}
