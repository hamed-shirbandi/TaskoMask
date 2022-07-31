using MediatR;
using System.Threading;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Events.Boards;

namespace TaskoMask.Application.Workspace.Boards.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class BoardEventHandles : 
        INotificationHandler<BoardCreatedEvent>,
        INotificationHandler<BoardUpdatedEvent>,
        INotificationHandler<BoardDeletedEvent>,
        INotificationHandler<BoardRecycledEvent>
    {
        #region Fields

        private readonly IBoardRepository _boardRepository;
        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors

        public BoardEventHandles(IBoardRepository boardRepository, IProjectRepository projectRepository)
        {
            _boardRepository = boardRepository;
            _projectRepository = projectRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardCreatedEvent createdBoard, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(createdBoard.ProjectId);

            var board = new Board(createdBoard.Id)
            {
                Name= createdBoard.Name,
                Description= createdBoard.Description,
                OrganizationId= project.OrganizationId,
                ProjectId = createdBoard.ProjectId,
                OwnerId= project.OwnerId,
            };
           await _boardRepository.CreateAsync(board);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardUpdatedEvent updatedBoard, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(updatedBoard.Id);

            board.Name = updatedBoard.Name;
            board.Description = updatedBoard.Description;

            board.SetAsUpdated();

            await _boardRepository.UpdateAsync(board);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardDeletedEvent deletedBoard, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(deletedBoard.Id);
            board.SetAsDeleted();
            await _boardRepository.UpdateAsync(board);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardRecycledEvent recycledBoard, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(recycledBoard.Id);
            board.SetAsRecycled();
            await _boardRepository.UpdateAsync(board);
        }

        #endregion






    }
}
