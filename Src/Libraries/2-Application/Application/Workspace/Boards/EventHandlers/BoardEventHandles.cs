using MediatR;
using System.Threading;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
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

        #endregion

        #region Ctors

        public BoardEventHandles(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardCreatedEvent createdBoard, CancellationToken cancellationToken)
        {
            var board = new Board(createdBoard.Id)
            {
                Name= createdBoard.Name,
                Description= createdBoard.Description,
                OrganizationId= createdBoard.OrganizationId,
                ProjectId = createdBoard.ProjectId,
                
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
            board.SetAsDeleteed();
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
