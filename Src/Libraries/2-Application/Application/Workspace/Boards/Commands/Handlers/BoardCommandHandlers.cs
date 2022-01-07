using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Workspace.Data;
using TaskoMask.Domain.Workspace.Entities;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Team.Data;

namespace TaskoMask.Application.Workspace.Boards.Commands.Handlers
{
    public class BoardCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateBoardCommand, CommandResult>,
        IRequestHandler<UpdateBoardCommand, CommandResult>
    {
        #region Fields

        private readonly IBoardRepository _boardRepository;
        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors


        public BoardCommandHandlers(IBoardRepository boardRepository, IDomainNotificationHandler notifications, IProjectRepository projectRepository, IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
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


            var board = new Board(name: request.Name, description: request.Description, projectId: request.ProjectId, organizationId: project.OrganizationId);

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

            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);


            board.Update(request.Name, request.Description, request.ProjectId, project.OrganizationId);

            await _boardRepository.UpdateAsync(board);
            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }


        #endregion

    }
}
