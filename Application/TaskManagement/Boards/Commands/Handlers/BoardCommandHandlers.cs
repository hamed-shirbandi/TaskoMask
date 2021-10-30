using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.TaskManagement.Boards.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.TaskManagement.Data;
using TaskoMask.Domain.TaskManagement.Entities;

namespace TaskoMask.Application.TaskManagement.Boards.Commands.Handlers
{
    public class BoardCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateBoardCommand, CommandResult>,
        IRequestHandler<UpdateBoardCommand, CommandResult>
    {
        #region Fields

        private readonly IBoardRepository _boardRepository;
        private readonly IBoardRepository _projectRepository;

        #endregion

        #region Ctors


        public BoardCommandHandlers(IBoardRepository boardRepository, IDomainNotificationHandler notifications, IBoardRepository projectRepository, IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
        {
            _boardRepository = boardRepository;
            _projectRepository = projectRepository;
        }


        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            //TODO move this validations type in all handlers to domain
            var exist = await _boardRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);


            var board = new Board(name: request.Name, description: request.Description, projectId: request.ProjectId,organizationId: project.OrganizationId);
            if (!IsValid(board))
                return new CommandResult(ApplicationMessages.Create_Failed);


            await _boardRepository.CreateAsync(board);
            return new CommandResult(ApplicationMessages.Create_Success, board.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            var exist = await _boardRepository.ExistByNameAsync(board.Id, request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            board.Update(request.Name, request.Description);

            if (!IsValid(board))
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _boardRepository.UpdateAsync(board);
            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }


        #endregion

    }
}
